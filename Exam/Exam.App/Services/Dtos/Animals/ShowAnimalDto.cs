namespace Exam.App.Services.Dtos.Animals
{
    public class ShowAnimalDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Mass { get; set; }

        public int AnimalSpeciesId { get; set; }
        public required string AnimalSpeciesName { get; set; }
        public int? CageId { get; set; }
        public string? CageCode { get; set; }
    }
}
