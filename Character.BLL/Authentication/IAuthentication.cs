using System.Threading.Tasks;
using Character.BLL.Model;

namespace Character.BLL.Authentication
{
    public interface IAuthentication
    {
         Task<ServiceResponse<int>> Register(User User, string Password);

         Task<ServiceResponse<string>> Login(string userName, string Password);
         Task<bool> AlreadyExist (string userName);


    }
}