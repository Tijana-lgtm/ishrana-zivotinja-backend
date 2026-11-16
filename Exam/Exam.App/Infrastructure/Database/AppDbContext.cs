using Exam.App.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam.App.Infrastructure.Database;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet <Cage> Cages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "b1c4c3f8-4d2f-4e62-9a4b-8e3a2a9e8a01", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            new IdentityRole { Id = "3e7a9c12-5b4d-4f8e-a1c6-9d2b7e4f3a10", Name = "Nutricionista", NormalizedName = "NUTRICIONISTA" },
            new IdentityRole { Id = "8f2d4b6a-7c1e-4a3b-9e5d-1c8f6a2b4d20", Name = "Negovatelj", NormalizedName = "NEGOVATELJ" }
        );

        modelBuilder.Entity<AnimalSpecies>(e =>
        {
            e.HasData(
              new AnimalSpecies { Id = 1, Name = "Lav" },
              new AnimalSpecies { Id = 2, Name = "Tigar" },
              new AnimalSpecies { Id = 3, Name = "Slon" },
              new AnimalSpecies { Id = 4, Name = "Žirafa" },
              new AnimalSpecies { Id = 5, Name = "Zebra" },
              new AnimalSpecies { Id = 6, Name = "Nosorog" },
              new AnimalSpecies { Id = 7, Name = "Gepard" },
              new AnimalSpecies { Id = 8, Name = "Hijena" },
              new AnimalSpecies { Id = 9, Name = "Medved" },
              new AnimalSpecies { Id = 10, Name = "Vuk" },
              new AnimalSpecies { Id = 11, Name = "Lisica" },
              new AnimalSpecies { Id = 12, Name = "Sova" },
              new AnimalSpecies { Id = 13, Name = "Orao" },
              new AnimalSpecies { Id = 14, Name = "Krokodil" },
              new AnimalSpecies { Id = 15, Name = "Pingvin" },
              new AnimalSpecies { Id = 16, Name = "Flamingo" },
              new AnimalSpecies { Id = 17, Name = "Kengur" },
              new AnimalSpecies { Id = 18, Name = "Panda" },
              new AnimalSpecies { Id = 19, Name = "Lemur" },
              new AnimalSpecies { Id = 20, Name = "Morski lav" }
            );
        });

        modelBuilder.Entity<Cage>(e =>
        {
            e.HasData(
              new Cage { Id = 1, Code = "A1-SAVANA" },
              new Cage { Id = 2, Code = "A2-DŽUNGLA" },
              new Cage { Id = 3, Code = "A3-PLANINA" },
              new Cage { Id = 4, Code = "B1-PTICE" },
              new Cage { Id = 5, Code = "B2-REPTILI" },
              new Cage { Id = 6, Code = "C1-VODENI" },
              new Cage { Id = 7, Code = "C2-NOĆNI" }
            );
        });

        modelBuilder.Entity <Animal> ()
            .HasOne(a=>a.AnimalSpecies)
            .WithMany()
            .HasForeignKey (a=>a.AnimalSpeciesId)
            .OnDelete (DeleteBehavior.Restrict);

        modelBuilder.Entity<Animal> ()
            .HasOne (a=>a.Cage)
            .WithMany()
            .HasForeignKey (a=>a.CageId)
            .OnDelete (DeleteBehavior.Restrict);
    }
}
