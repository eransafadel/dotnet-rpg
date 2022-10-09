using AutoMapper;
using dotnet_rpg.Dtos.Character;
namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id=1, Name ="Sam"}
        }
      ;
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            Character? character = characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
            {
                response.Success = false;
                response.Message = "The Id is not been found";
                return response;
            }
            characters.Remove(character);

            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;

        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> { Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character? character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            if (character == null)
            {
                response.Success = false;
                response.Message = "The Id is not been found";
                return response;
            }

            //_mapper.Map(updatedCharacter,character);

            character.Name = updatedCharacter.Name;
            character.Strength = updatedCharacter.Strength;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Defense = updatedCharacter.Defense;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;
            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;

        }
    }
}