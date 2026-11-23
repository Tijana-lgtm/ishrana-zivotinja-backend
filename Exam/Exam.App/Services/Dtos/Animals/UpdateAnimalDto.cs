namespace Exam.App.Services.Dtos.Animals
{
    public class UpdateAnimalDto
    {
        public required string Name { get; set; }
        public double Mass { get; set; }
        public int AnimalSpeciesId { get; set; }
        public int? CageId { get; set; }
    }
}
