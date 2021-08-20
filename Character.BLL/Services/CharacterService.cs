using System.Collections.Generic;
using System.Linq;
using Character.BLL.Interface;
using System.Threading.Tasks;
using Character.BLL.Model;
using Character.BLL.Dtos.Character;
using AutoMapper;
using Character.BLL.Data;
using Microsoft.EntityFrameworkCore;

namespace Character.BLL.Services
{
    public class CharacterService : ICharacterService
    {
        public DataContext _dataContext { get; }

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            return new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = await _dataContext.CharacterModels.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync()
            };
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {
             return new ServiceResponse<GetCharacterDto>()
            {
                Data = _mapper.Map<GetCharacterDto>(await _dataContext.CharacterModels.Where(x => x.Id == id).FirstOrDefaultAsync())
            };
            //return characters.Where(x=>x.Id == id).FirstOrDefault();
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> Addcharecter(AddCharacterDto Character)
        {

            var result = _mapper.Map<CharacterModel>(Character);
            _dataContext.CharacterModels.Add(result);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<GetCharacterDto>>()
            {
                Data =  await _dataContext.CharacterModels.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto Character)
        {
            CharacterModel result = _dataContext.CharacterModels.FirstOrDefault(x => x.Id == Character.Id);
            //result = _mapper.Map<CharacterModel>(Character);
            result.Id = Character.Id;
            result.Name = Character.Name;
           // _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<GetCharacterDto>()
            {
                Data = _mapper.Map<GetCharacterDto>(result)
            };
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var result = await _dataContext.CharacterModels.FirstOrDefaultAsync(x => x.Id == id);
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = _dataContext.CharacterModels.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }
    }
}