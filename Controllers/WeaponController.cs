using System.Security.Claims;
using System.Threading.Tasks;
using Character.BLL.Dtos.Character;
using Character.BLL.Dtos.Wepon;
using Character.BLL.Interface;
using Character.BLL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
         private readonly IWeaponService _weaponService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeaponController(IWeaponService weaponService,IHttpContextAccessor httpContextAccessor)
        {
            _weaponService = weaponService;
            _httpContextAccessor = httpContextAccessor;
        }     
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
   
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weaponService.AddWepon(newWeapon,GetUserId()));
        }
    }
}