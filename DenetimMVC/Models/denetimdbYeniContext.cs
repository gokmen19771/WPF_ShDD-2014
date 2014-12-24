using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DenetimMVC.Models
{
    public partial class denetimdbYeniContext : DbContext
    {
        static denetimdbYeniContext()
        {
            Database.SetInitializer<denetimdbYeniContext>(null);
        }

        public denetimdbYeniContext()
            : base("Name=denetimdbYeniContext")
        {

        }

 
        public DbSet<EvrakKayıtEski> EvrakKayıtEski { get; set; }

        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<KonuBasliklari> KonuBaşlıkları { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DosyaKayıt> DosyaKayıt { get; set; }
    }
}
