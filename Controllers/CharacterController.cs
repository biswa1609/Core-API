using System.Collections.Generic;
using System.Linq;
using Character.BLL.Model;
using Character.BLL.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<CharacterModel>> Get()
        {
            return Ok(_CharacterService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<CharacterModel> Get(int id)
        {
            return Ok(_CharacterService.GetById(id));
        }
        [HttpPost("Addcharecter")]
        public ActionResult<List<CharacterModel>> Addcharecter(CharacterModel characters)
        {
            return Ok(_CharacterService.Addcharecter(characters));
        }

    }
}