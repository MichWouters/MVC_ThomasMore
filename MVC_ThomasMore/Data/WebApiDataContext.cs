using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public class WebApiDataContext : DbContext
    {
        public WebApiDataContext(DbContextOptions<WebApiDataContext> options) : base(options) { }

        public DbSet<Product> Producten { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetTables(modelBuilder);
            SetRelationships(modelBuilder);
            GenerateDummyData(modelBuilder);
        }

        private void GenerateDummyData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .HasData(
                new Categorie
                {
                    Id = 1,
                    Name = "Pc Software",
                    DatumToegevoegd = DateTime.Now
                },
                new Categorie
                {
                    Id = 2,
                    Name = "Pc Hardware",
                    DatumToegevoegd = DateTime.Now
                });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    CategorieId =1,
                    Naam = "Baldur's gate",
                    Prijs = 49.99,
                    DatumToegevoegd = DateTime.Today,
                },
                new Product
                {
                    Id = 2,
                    CategorieId = 1,
                    Naam = "Hello Kitty, Island adventure",
                    Prijs = 69.99,
                    DatumToegevoegd = DateTime.Today,
                },
                new Product
                {
                    Id = 3,
                    CategorieId = 2,
                    Naam = "Geforce RTX 4080",
                    Prijs = 699.99,
                    DatumToegevoegd = DateTime.Today,
                });

            modelBuilder.Entity<Klant>()
                .HasData(new Klant
                {
                    Id = 1,
                    Naam = "Wouters",
                    Voornaam = "Michiel",
                    BankrekeningNummer = "123",
                    Gemeente = "Antwerpen",
                    PostCode = "3390",
                    Straat = "Steenweg",
                    Huisnummer = 12
                });

            modelBuilder.Entity<Bestelling>()
                .HasData(new Bestelling
                {
                    Id = 1,
                    KlantId = 1,
                });

            modelBuilder.Entity<Orderlijn>()
                .HasData(new Orderlijn
                {
                    Id = 1,
                    ProductID = 1,
                    BestellingId = 1,
                    Aantal = 1,
                },
                new Orderlijn
                {
                    Id = 2,
                    ProductID = 2,
                    BestellingId = 1,
                    Aantal = 200,
                });

        }

        private void SetTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orderlijn>().ToTable("Orderlijnen");
            modelBuilder.Entity<Bestelling>().ToTable("Bestellingen");

            modelBuilder.Entity<Klant>()
                .ToTable("Klanten")
                .Property(x => x.Naam)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
            .ToTable("Producten")
            .Property(p => p.Prijs)
            .HasColumnType("decimal(18,2)");
        }

        private void SetRelationships(ModelBuilder modelBuilder)
        {
            // Set relationships
            //One to many
            modelBuilder.Entity<Bestelling>()
                .HasOne(x => x.Klant)
                .WithMany(x => x.Bestellingen)
                .HasForeignKey(x => x.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Categorie>()
                .HasMany(x => x.Producten)
                .WithOne(x => x.Categorie)
                .HasForeignKey(x => x.CategorieId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Many to many
            modelBuilder.Entity<Orderlijn>()
                .HasOne(x => x.Bestelling)
                .WithMany(x => x.Orderlijnen)
                .HasForeignKey(x => x.BestellingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Orderlijn>()
               .HasOne(x => x.Product)
               .WithMany(x => x.OrderLijnen)
               .HasForeignKey(x => x.ProductID)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
