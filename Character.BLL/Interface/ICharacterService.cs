using System.Collections.Generic;
using Character.BLL.Model;

namespace Character.BLL.Interface
{
    public interface ICharacterService
    {
         List<CharacterModel> GetAll();
         CharacterModel GetById(int id);
         List<CharacterModel> Addcharecter(CharacterModel Character);

    }
}