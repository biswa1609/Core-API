using System.Threading.Tasks;
using Character.BLL.Data;
using Character.BLL.Model;
using Microsoft.EntityFrameworkCore;

namespace Character.BLL.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly DataContext _dataContext;
        public Authentication(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<bool> AlreadyExist(string userName)
        {
            if(await _dataContext.Users.AnyAsync(x=> x.UserName.ToLower() == userName.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<string>> Login(string User, string Password)
        {
            var response = new ServiceResponse<string>();
            var userDetails = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == User);
            if(userDetails == null)
            {
                 response.Response = false;
                 response.Message = "User Not found";
            }
            else if( !ValidatePassword(Password,userDetails.PasswordHash, userDetails.PasswodSalt))
            {
                response.Response = false;
                response.Message = "Password  Mismatch";
            }
            else
            {
                response.Data = userDetails.Id.ToString();
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User User, string Password)
        {
            if(await AlreadyExist(User.UserName))
            {
                return new ServiceResponse<int>(){
                  Response = false,
                  Message= "User already Exist in the System"
                };
            }
            CreatePassword(Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            User.PasswordHash = PasswordHash;
            User.PasswodSalt = PasswordSalt;
            _dataContext.Add(User);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<int>(){
                Data = User.Id
            };


        }

        private void CreatePassword(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        private bool ValidatePassword(string Password,  byte[] PasswordHash,  byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for(int i = 0; i< PasswordHash.Length; i++)
                {
                    if(PasswordHash[i] == computedHash[i])
                        return false;
                }
                return true;
            }
            
        }
    }
}