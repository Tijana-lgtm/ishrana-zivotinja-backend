using Exam.App.Services.Dtos.Animals;

namespace Exam.App.Services
{
    public interface IAnimalService
    {
        Task <List<ShowAnimalDto>> GetAllAsync (int? animalSpeciesId, int? cageId, bool unassigned);
        Task <ShowAnimalDto> GetByIdAsync (int id);
        Task<ShowAnimalDto> CreateAsync(CreateAnimalDto dto);
        Task<ShowAnimalDto> UpdateAsync (int id, UpdateAnimalDto dto);
        Task DeleteAsync (int id); 

        Task <List<AnimalSpeciesDto>> GetSpeciesAsync ();
        Task <List<CageDto>> GetCagesAsync ();
    }
}
