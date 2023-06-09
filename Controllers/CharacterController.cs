using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet7rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto UpdatedCharacter){
            var response = await _characterService.UpdateCharacter(UpdatedCharacter);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
    }
}