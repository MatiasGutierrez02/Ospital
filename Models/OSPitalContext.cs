using Microsoft.EntityFrameworkCore;

namespace OSpital.Models
{
    public class OSPitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            //poner nombre de la BD que corra la app
            option.UseSqlServer("Data Source=DESKTOP-AL8NGAE\\SQLEXPRESS; Initial Catalog=TP_Final_PNT1_Bossio_Gonzalez_Gutierrez; Integrated Security=true");

        }

        //poner entidades de la BD
        //public DbSet<OSpital> OSpital { get; set; }
        //public DbSet<Workers> Workers { get; set; }
        //public DbSet<Patient> Patient { get; set; }
        //public DbSet<SystemAccess> SystemAccess { get; set; }


    }
}