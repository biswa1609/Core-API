using System.Collections.Generic;
using System.Linq;
using Character.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
   [ApiController]
   [Route("[controller]")]
    public class CharacterController:ControllerBase
    {
        public CharacterController()
        {
            
        }
        public List<CharacterModel> characters = new List<CharacterModel>{
                new CharacterModel(),
                new CharacterModel{Name = "Sam"},
                new CharacterModel{Id = 1}
            };
        [HttpGet("GetAll")]
        public ActionResult<List<CharacterModel>> Get()
        {
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult<List<CharacterModel>> Get(int id)
        {
            return Ok(characters.Where(x=>x.Id == id).FirstOrDefault());
        }
        [HttpPost("Addcharecter")]
        public ActionResult<List<CharacterModel>> Addcharecter(CharacterModel cha)
        {
            characters.Add(cha);
            return Ok(characters);
        }

    }
}