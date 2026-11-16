namespace Exam.App.Domain
{
    public class Animal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Mass { get; set; }
        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; } = null!;
        public int? CageId { get; set; }
        public Cage? Cage { get; set; }
    }
}
