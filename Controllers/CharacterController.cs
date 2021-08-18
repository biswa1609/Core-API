using System.Collections.Generic;
using System.Linq;
using Core_API.Model;
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
        public List<character> characters = new List<character>{
                new character(),
                new character{Name = "Sam"},
                new character{Id = 1}
            };
        [HttpGet("GetAll")]
        public ActionResult<List<character>> Get()
        {
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult<List<character>> Get(int id)
        {
            return Ok(characters.Where(x=>x.Id == id).FirstOrDefault());
        }
        [HttpPost("Addcharecter")]
        public ActionResult<List<character>> Addcharecter(character cha)
        {
            characters.Add(cha);
            return Ok(characters);
        }

    }
}