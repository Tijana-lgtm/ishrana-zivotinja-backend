using Exam.App.Services.Dtos.Animals;

namespace Exam.App.Services
{
    public interface IAnimalService
    {
        Task <List<ShowAnimalDto>> GetAllAsync ();
        Task <ShowAnimalDto> GetByIdAsync (int id);
        Task<ShowAnimalDto> CreateAsync(CreateAnimalDto dto);
        Task<ShowAnimalDto> UpdateAsync (int id, UpdateAnimalDto dto);
        Task DeleteAsync (int id); 
    }
}
