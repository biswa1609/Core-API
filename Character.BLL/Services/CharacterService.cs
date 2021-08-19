using System.Collections.Generic;
using System.Linq;
using Character.BLL.Model;
using Character.BLL.Interface;

namespace Character.BLL.Services
{
    public class CharacterService:ICharacterService
    {
         public List<CharacterModel> characters = new List<CharacterModel>{
                new CharacterModel(),
                new CharacterModel{Name = "Sam"},
                new CharacterModel{Id = 1}
            };

        public List<CharacterModel> GetAll()
        {
            return characters;
        }
        public CharacterModel GetById(int id)
        {
            return characters.Where(x=>x.Id == id).FirstOrDefault();
        }
        public List<CharacterModel> Addcharecter(CharacterModel Character)
        {
             characters.Add(Character);
             return characters;
        }
    }
}