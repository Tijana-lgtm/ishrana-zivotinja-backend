using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _context;

        public AnimalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> GetAllAsync()
        {
            return await _context.Animals
                .Include(a => a.AnimalSpecies)
                .Include(a => a.Cage)
                .ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _context.Animals
                .Include (a => a.AnimalSpecies)
                .Include(a => a.Cage)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Animal> AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task <bool> DeleteAsync (int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
                return false;

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
