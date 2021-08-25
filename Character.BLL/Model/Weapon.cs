namespace Character.BLL.Model
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage{get;set;}
        public CharacterModel CharacterModel { get; set; }
        public int CharacterModelId{get;set;}
    }
}