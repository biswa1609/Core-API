using System.Collections.Generic;
using System.Threading.Tasks;
using Character.BLL.Dtos.Character;
using Character.BLL.Model;

namespace Character.BLL.Interface
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAll(int userId);
         Task<ServiceResponse<GetCharacterDto>> GetById(int id, int userId);
         Task<ServiceResponse<List<GetCharacterDto>>> Addcharecter(AddCharacterDto Character, int userId);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto Character, int userId);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id, int userId);

    }
}