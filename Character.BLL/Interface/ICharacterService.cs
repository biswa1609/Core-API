using System.Collections.Generic;
using System.Threading.Tasks;
using Character.BLL.Dtos.Character;
using Character.BLL.Model;

namespace Character.BLL.Interface
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAll();
         Task<ServiceResponse<GetCharacterDto>> GetById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> Addcharecter(AddCharacterDto Character);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto Character);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}