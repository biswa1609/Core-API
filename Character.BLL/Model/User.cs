using System.Collections.Generic;

namespace Character.BLL.Model
{
    public class User
    {
        public int Id {get;set;}
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswodSalt { get; set; }
        public List<CharacterModel> CharacterModels { get; set; }
    }
}