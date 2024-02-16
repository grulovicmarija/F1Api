using F1GrandPrixApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1GrandPrixApi.Data
{
    public class DataContext : DbContext
    {
        //DataContext > klasa za komunikaciju sa bazom

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //prosledjuju se opcije kao sto je konekcioni string
        }


        //tabele u bazi
        public DbSet<Drzava> drzave { get; set; }
        public DbSet<Grad> gradovi { get; set; }
        public DbSet<Kupac> kupci { get; set; }
        public DbSet<Rezervacija> rezervacije { get; set; }
        public DbSet<Trka> trke { get; set; }
        public DbSet<Ucesce> ucesca { get; set; }
        public DbSet<Ucesnik> ucesnici { get; set; }
        public DbSet<Zona> zone { get; set; }


        //OnModelCreating metoda za konfiguraciju specificnosti u bazi
        //ovde konfigurisemo many-to-many veze za EntityFramework

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ucesce>()
                .HasKey(u => new { u.UcesnikId, u.TrkaId });
            modelBuilder.Entity<Ucesce>()
                .HasOne(u => u.ucesnik)
                .WithMany( uc => uc.ucesca)
                .HasForeignKey(u => u.UcesnikId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ucesce>()
                .HasOne(u => u.trka)
                .WithMany(t => t.ucesca)
                .HasForeignKey(u => u.TrkaId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Rezervacija>()
                .HasKey(r => new {r.KupacId, r.TrkaId, r.aktivna });
            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.kupac)
                .WithMany(k => k.rezervacije)
                .HasForeignKey(r => r.KupacId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.trka)
                .WithMany(t => t.rezervacije)
                .HasForeignKey(r => r.TrkaId)
                .OnDelete(DeleteBehavior.NoAction);


            //konfig. decimal vrednosti 

         

            modelBuilder.Entity<Rezervacija>()
                .Property(r => r.konacnaCena)
                .HasColumnType("decimal(10,4)");

            modelBuilder.Entity<Zona>()
                .Property(z => z.cenaKarte)
                .HasColumnType("decimal(10,4)");

        }

    }
}
