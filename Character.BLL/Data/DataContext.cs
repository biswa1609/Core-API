using Character.BLL.Model;
using Microsoft.EntityFrameworkCore;

namespace Character.BLL.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
           
        }
         public DbSet<CharacterModel> CharacterModels { get; set; }
         public DbSet<User> Users { get; set; }
         public DbSet<Weapon> Weapons { get; set; }
        
    }
}