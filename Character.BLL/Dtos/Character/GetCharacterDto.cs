using Character.BLL.Dtos.Wepon;
using Character.BLL.Model;

namespace Character.BLL.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
       /* public User User { get; set; }
        
        public List<Skill> Skills { get; set; }*/
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }   
    }
}