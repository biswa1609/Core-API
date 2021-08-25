using System.Collections.Generic;
using System.Linq;
using Character.BLL.Model;
using Character.BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Character.BLL.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core_API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public readonly ICharacterService _CharacterService;
        private readonly IHttpContextAccessor _httpContextAccessor ;
        public CharacterController(ICharacterService CharacterService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _CharacterService = CharacterService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {

            return Ok(await _CharacterService.GetAll(GetUserId()));
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get(int id)
        {
            return Ok(await _CharacterService.GetById(id,GetUserId()));
        }
        [HttpPost("Addcharecter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Addcharecter(AddCharacterDto characters)
        {
            return Ok(await _CharacterService.Addcharecter(characters,GetUserId()));
        }
        [HttpPut("Updatecharecter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Updatecharecter(UpdateCharacterDto characters)
        {
            return Ok(await _CharacterService.UpdateCharacter(characters,GetUserId()));
        }
        [HttpDelete("Deletecharecter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Deletecharecter(int id)
        {
            return Ok(await _CharacterService.DeleteCharacter(id,GetUserId()));
        }

    }
}