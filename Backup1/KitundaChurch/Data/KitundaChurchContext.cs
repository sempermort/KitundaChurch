using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;

namespace KitundaChurch.Models
{
    public class KitundaChurchContext : DbContext
    {
        public KitundaChurchContext (DbContextOptions<KitundaChurchContext> options)
            : base(options)
        {

            // Sets the command timeout for all the commands
            this.Database.SetCommandTimeout(380);
        }
        //this.System.Configuration.LazyLoadingEnabled = false;
        public DbSet<KitundaChurch.Models.ChurchMembers> ChurchMembers { get; set; }

        public DbSet<KitundaChurch.Models.Matoleo> Matoleo { get; set; }
        public DbSet<KitundaChurch.Models.Mengineyo> Mengineyo { get; set; }
        public DbSet<KitundaChurch.Models.Album> Album { get; set; }
        public DbSet<KitundaChurch.Models.Song> Songs { get; set; }
        public DbSet<KitundaChurch.Models.News> News { get; set; }
        public DbSet<KitundaChurch.Models.Event> Events { get; set; }
        public DbSet<KitundaChurch.Models.Matumizi> Matumizi { get; set; }
        public DbSet<KitundaChurch.Models.Department> Department { get; set; }
        public DbSet<KitundaChurch.Models.Category> Category { get; set; }
        public DbSet<KitundaChurch.Models.Gallery> Gallery { get; set; }
        public DbSet<KitundaChurch.Models.UserImageFile> UserImageFile { get; set; }
    }

}
