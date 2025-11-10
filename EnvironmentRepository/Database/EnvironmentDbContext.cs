using EnvironmentRepository.Models.Config;
using EnvironmentRepository.Models.Dynamic;
using EnvironmentRepository.Models.Kullanici;
using EnvironmentRepository.Models.Musteri;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentRepository.Database
{
    public class EnvironmentDbContext : IdentityDbContext<Kullanici, Rol, int>
    {
        public EnvironmentDbContext(DbContextOptions<EnvironmentDbContext> options) : base(options){}
        //Musteri
        #region Musteri
        public DbSet<Adres> Adres { get; set; }
        public DbSet<AdresTip> AdresTip { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<MusteriTip> MusteriTip { get; set; }
        public DbSet<MusteriKategori> MusteriKategori { get; set; }
        public DbSet<MusteriSektor> MusteriSektor { get; set; }
        public DbSet<MusteriKaynak> MusteriKaynak { get; set; }
        public DbSet<Ulke> Ulke { get; set; }
        #endregion

        //Config
        #region Config
        public DbSet<Sirket> Sirket { get; set; }
        #endregion

        //Dynamic
        #region Dynamic
        public DbSet<VeriListesi> VeriListesi { get; set; }
        #endregion

        //Kullanici
        public DbSet<RefreshToken> RefreshToken { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Musteri
            #region Musteri
            modelBuilder.Entity<Musteri>().HasOne(x => x.Adres).WithOne();
            modelBuilder.Entity<Musteri>().HasOne(x => x.Tip).WithOne();
            modelBuilder.Entity<Musteri>().HasOne(x => x.Kategori).WithOne();
            modelBuilder.Entity<Musteri>().HasOne(x => x.Kaynak).WithOne();
            modelBuilder.Entity<Musteri>().HasOne(x => x.Sektor).WithOne();
            modelBuilder.Entity<Adres>().HasOne(x => x.Ulke).WithOne();
            modelBuilder.Entity<Adres>().HasOne(x => x.Tip).WithOne();
            modelBuilder.Entity<Musteri>().HasOne(x => x.Sirket).WithOne().OnDelete(DeleteBehavior.NoAction);
            #endregion

            //Kullanici
            modelBuilder.Entity<Kullanici>().HasMany(x => x.Sirketler).WithMany();
            modelBuilder.Entity<RefreshToken>().HasOne(x => x.Kullanici).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
