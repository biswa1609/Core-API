using Character.BLL.Model;

namespace Character.BLL.Dtos.Wepon
{
    public class AddWeaponDto
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
    }
}