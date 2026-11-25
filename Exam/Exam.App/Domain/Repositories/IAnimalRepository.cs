namespace Exam.App.Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAllAsync(int? animalSpeciesId, int? cageId, bool unassigned);
        Task <Animal> GetByIdAsync(int id);
        Task<Animal> AddAsync(Animal animal);
        Task <Animal> UpdateAsync(Animal animal);
        Task <bool> DeleteAsync(int id);

        Task <List<AnimalSpecies>> GetAllSpeciesAsync();
        Task <List<Cage>> GetAllCagesAsync();
    }
}
