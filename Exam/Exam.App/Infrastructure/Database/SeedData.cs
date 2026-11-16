using Exam.App.Domain;
using Microsoft.AspNetCore.Identity;

namespace Exam.App.Infrastructure.Database;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

        var admin = await userManager.FindByNameAsync("marko.admin");
        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "marko.admin",
                Email = "marko.jovanovic@zoo.rs",
                Name = "Marko",
                Surname = "Jovanovic",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, "Marko123!");
            await userManager.AddToRoleAsync(admin, "Administrator");
        }

        var nutritionist = await userManager.FindByNameAsync("ana.nutritionist");
        if (nutritionist == null)
        {
            nutritionist = new ApplicationUser
            {
                UserName = "ana.nutritionist",
                Email = "ana.kojic@zoo.rs",
                Name = "Ana",
                Surname = "Kojic",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(nutritionist, "Ana12345!");
            await userManager.AddToRoleAsync(nutritionist, "Nutricionista");
        }

        var caretaker = await userManager.FindByNameAsync("petar.negovatelj");
        if (caretaker == null)
        {
            caretaker = new ApplicationUser
            {
                UserName = "petar.negovatelj",
                Email = "petar.petrovic@zoo.rs",
                Name = "Petar",
                Surname = "Petrovic",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(caretaker, "Petar123!");
            await userManager.AddToRoleAsync(caretaker, "Negovatelj");
        }

        if (!dbContext.Animals.Any())
        {
            dbContext.Animals.AddRange(
                new Animal
                {
                    Name = "Simba",
                    Mass = 190,
                    AnimalSpeciesId = 1, // Lav
                    CageId = 1           // A1-SAVANA
                },
                new Animal
                {
                    Name = "Dambo",
                    Mass = 5400,
                    AnimalSpeciesId = 3, // Slon
                    CageId = 1           // A1-SAVANA
                },
                new Animal
                {
                    Name = "Šir Kan",
                    Mass = 220,
                    AnimalSpeciesId = 2, // Tigar
                    CageId = 2           // A2-DŽUNGLA
                },
                new Animal
                {
                    Name = "Pingo",
                    Mass = 25,
                    AnimalSpeciesId = 15 // Pingvin - nije razvrstan
                },
                new Animal
                {
                    Name = "Baloo",
                    Mass = 300,
                    AnimalSpeciesId = 9  // Medved - nije razvrstan
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}