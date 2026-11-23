namespace Exam.App.Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAllAsync();
        Task <Animal> GetByIdAsync(int id);
        Task<Animal> AddAsync(Animal animal);
        Task <Animal> UpdateAsync(Animal animal);
        Task <bool> DeleteAsync(int id);
    }
}
