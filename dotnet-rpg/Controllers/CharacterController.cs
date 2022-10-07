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
        private static Character knight = new Character();

        [HttpGet]
        public ActionResult<Character> Get() {
             //return NotFound() 
            //return BadRequest()//
            return Ok(knight);// status code: 200
        }
    }
}