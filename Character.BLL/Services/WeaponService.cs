using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Character.BLL.Data;
using Character.BLL.Dtos.Character;
using Character.BLL.Dtos.Wepon;
using Character.BLL.Interface;
using Character.BLL.Model;
using Microsoft.EntityFrameworkCore;

namespace Character.BLL.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly  IMapper _mapper;
        private readonly DataContext _context;
        public WeaponService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWepon(AddWeaponDto newWeapon, int UserId)
        {
             var service = new ServiceResponse<GetCharacterDto>();
            try
            {
                var characterDetail = await _context.CharacterModels
                                        .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                                        c.User.Id == UserId);

                if(characterDetail == null)
                {
                    service.Response = false;
                    service.Message = "User not found";
                    return service;
                }

                var weapon = new Weapon()
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    CharacterModel = characterDetail
                };
                await _context.AddAsync(weapon);
                await _context.SaveChangesAsync();
                service.Data = _mapper.Map<GetCharacterDto>(characterDetail);
            
                
            }
            catch (Exception ex)
            {
                service.Response = false;
                service.Message = ex.Message;
            }
            return service;

        }
    }
}