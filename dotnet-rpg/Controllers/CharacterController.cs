using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;
        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get()
        {

            return Ok(await characterService.GetAllCharacters());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Delete(int id)
        {
             var response = await characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

         [HttpGet("{id}")]
        public async  Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {

            return Ok(await characterService.GetCharacterById(id));
        }




        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto UpdatedCharacter)
        {
            var response = await characterService.UpdateCharacter(UpdatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}