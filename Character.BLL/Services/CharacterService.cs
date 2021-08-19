using System.Collections.Generic;
using System.Linq;
using Character.BLL.Interface;
using System.Threading.Tasks;
using Character.BLL.Model;
using Character.BLL.Dtos.Character;
using AutoMapper;

namespace Character.BLL.Services
{
    public class CharacterService:ICharacterService
    {

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
         public List<CharacterModel> characters = new List<CharacterModel>{
                new CharacterModel(),
                new CharacterModel{Name = "Sam"},
                new CharacterModel{Id = 1}
            };

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            return new ServiceResponse<List<GetCharacterDto>>(){
                Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {
            return new ServiceResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(characters.Where(x=>x.Id == id).FirstOrDefault())
            };
            //return characters.Where(x=>x.Id == id).FirstOrDefault();
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> Addcharecter(AddCharacterDto Character)
        {

             var result = _mapper.Map<CharacterModel>(Character);
             result.Id = characters.Max(x=>x.Id) +1;
             characters.Add(result);
             
             return new ServiceResponse<List<GetCharacterDto>>(){
                Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto Character)
        {
                var result = characters.FirstOrDefault(x=>x.Id == Character.Id);
                result = _mapper.Map<CharacterModel>(Character);
            return new ServiceResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(result)
            };
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var result = characters.FirstOrDefault(x=>x.Id == id);
            characters.Remove(result);
            return new ServiceResponse<List<GetCharacterDto>>(){
                Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }
    }
}