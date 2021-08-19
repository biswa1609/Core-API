using System.Collections.Generic;
using System.Linq;
using Character.BLL.Model;
using Character.BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Character.BLL.Dtos.Character;

namespace Core_API.Controllers
{
   [ApiController]
   [Route("[controller]")]
    public class CharacterController:ControllerBase
    {
        public readonly ICharacterService _CharacterService;
        public CharacterController(ICharacterService CharacterService)
        {
            _CharacterService = CharacterService;    
        }
       
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _CharacterService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get(int id)
        {
            return Ok(await _CharacterService.GetById(id));
        }
        [HttpPost("Addcharecter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Addcharecter(AddCharacterDto characters)
        {
            return Ok(await _CharacterService.Addcharecter(characters));
        }
        [HttpPut("Updatecharecter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Updatecharecter(UpdateCharacterDto characters)
        {
            return Ok(await _CharacterService.UpdateCharacter(characters));
        }
        [HttpDelete("Deletecharecter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Deletecharecter(int id)
        {
            return Ok(await _CharacterService.DeleteCharacter(id));
        }

    }
}