using System.Threading.Tasks;
using Character.BLL.Dtos.Character;
using Character.BLL.Dtos.Wepon;
using Character.BLL.Model;

namespace Character.BLL.Interface
{
    public interface IWeaponService
    {
         Task<ServiceResponse<GetCharacterDto>> AddWepon(AddWeaponDto AddWeponDto, int UserId);
    }
}