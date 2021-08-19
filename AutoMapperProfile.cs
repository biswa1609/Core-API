using AutoMapper;
using Character.BLL.Dtos.Character;
using Character.BLL.Model;

namespace Core_API
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacterModel,GetCharacterDto>();
            CreateMap<AddCharacterDto,CharacterModel>();
            CreateMap<UpdateCharacterDto,CharacterModel>();
        }
        
    }
}