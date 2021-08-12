using System.Collections.Generic;
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
                new character{Name = "Sam"}
            };
        [HttpGet("GetAll")]
        public ActionResult<List<character>> Get()
        {
            return Ok(characters);
        }

    }
}