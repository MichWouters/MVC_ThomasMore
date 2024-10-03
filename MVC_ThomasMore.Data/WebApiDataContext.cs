using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data.Entities;

namespace MVC_ThomasMore.Data
{
    public class WebApiDataContext : DbContext
    {
        public WebApiDataContext(DbContextOptions<WebApiDataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Producten { get; set; }

        //public DbSet<Job> Jobs { get; set; }
        public DbSet<KlantEntitity> Klanten { get; set; }

        public DbSet<CategorieEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetTables(modelBuilder);
            SetRelationships(modelBuilder);
            GenerateDummyData(modelBuilder);
        }

        private void GenerateDummyData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieEntity>()
                .HasData(
                new CategorieEntity
                {
                    Id = 1,
                    Name = "Pc Software",
                    DatumToegevoegd = DateTime.Now
                },
                new CategorieEntity
                {
                    Id = 2,
                    Name = "Pc Hardware",
                    DatumToegevoegd = DateTime.Now
                });

            modelBuilder.Entity<ProductEntity>()
                .HasData(
                new ProductEntity
                {
                    Id = 1,
                    CategorieId = 1,
                    Naam = "Baldur's gate",
                    Prijs = 49.99,
                    DatumToegevoegd = DateTime.Today,
                },
                new ProductEntity
                {
                    Id = 2,
                    CategorieId = 1,
                    Naam = "Hello Kitty, Island adventure",
                    Prijs = 69.99,
                    DatumToegevoegd = DateTime.Today,
                },
                new ProductEntity
                {
                    Id = 3,
                    CategorieId = 2,
                    Naam = "Geforce RTX 4080",
                    Prijs = 699.99,
                    DatumToegevoegd = DateTime.Today,
                });

            modelBuilder.Entity<KlantEntitity>()
                .HasData(new KlantEntitity
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

            modelBuilder.Entity<BestellingEntity>()
                .HasData(new BestellingEntity
                {
                    Id = 1,
                    KlantId = 1,
                });

            modelBuilder.Entity<OrderLijnEntity>()
                .HasData(new OrderLijnEntity
                {
                    Id = 1,
                    ProductID = 1,
                    BestellingId = 1,
                    Aantal = 1,
                },
                new OrderLijnEntity
                {
                    Id = 2,
                    ProductID = 2,
                    BestellingId = 1,
                    Aantal = 200,
                });
        }

        private void SetTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLijnEntity>().ToTable("Orderlijnen");
            modelBuilder.Entity<BestellingEntity>().ToTable("Bestellingen");

            modelBuilder.Entity<KlantEntitity>()
                .ToTable("Klanten")
                .Property(x => x.Naam)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<ProductEntity>()
            .ToTable("Producten")
            .Property(p => p.Prijs)
            .HasColumnType("decimal(18,2)");
        }

        private void SetRelationships(ModelBuilder modelBuilder)
        {
            // Set relationships
            //One to many
            modelBuilder.Entity<BestellingEntity>()
                .HasOne(x => x.Klant)
                .WithMany(x => x.Bestellingen)
                .HasForeignKey(x => x.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<CategorieEntity>()
                .HasMany(x => x.Producten)
                .WithOne(x => x.Categorie)
                .HasForeignKey(x => x.CategorieId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Many to many
            modelBuilder.Entity<OrderLijnEntity>()
                .HasOne(x => x.Bestelling)
                .WithMany(x => x.Orderlijnen)
                .HasForeignKey(x => x.BestellingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<OrderLijnEntity>()
               .HasOne(x => x.Product)
               .WithMany(x => x.OrderLijnen)
               .HasForeignKey(x => x.ProductID)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}