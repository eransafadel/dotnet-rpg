using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id=1, Name ="Sam"}
        }
        ;

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get() {
             //return NotFound() 
            //return BadRequest()//
            return Ok(characters);// status code: 200
        }

          [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id) {
             //return NotFound() 
            //return BadRequest()//
            return Ok(characters.FirstOrDefault(c=> c.Id == id)); // status code: 200
        }
    }
}