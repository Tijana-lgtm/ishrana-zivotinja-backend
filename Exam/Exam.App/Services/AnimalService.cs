using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos.Animals;
using Exam.App.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace Exam.App.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalService (IAnimalRepository animalRepository, IMapper mapper) 
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<List<ShowAnimalDto>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            return _mapper.Map<List<ShowAnimalDto>>(animals);
        }

        public async Task<ShowAnimalDto> GetByIdAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
                throw new NotFoundException(id);

            return _mapper.Map<ShowAnimalDto>(animal);
        }

        public async Task<ShowAnimalDto> CreateAsync(CreateAnimalDto dto)
        {
            var animal = _mapper.Map<Animal>(dto);
            await _animalRepository.AddAsync(animal);
            
            var fullyloaded = await _animalRepository.GetByIdAsync(animal.Id);
            return _mapper.Map<ShowAnimalDto>(fullyloaded);
        }

        public async Task<ShowAnimalDto> UpdateAsync(int id, UpdateAnimalDto dto)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
                throw new NotFoundException(id);

            _mapper.Map(dto, animal);
            await _animalRepository.UpdateAsync(animal);

            var fullyloaded = await _animalRepository.GetByIdAsync(animal.Id);
            return _mapper.Map<ShowAnimalDto>(fullyloaded);
        }

        public async Task DeleteAsync (int id)
        {
            var animal = await _animalRepository.GetByIdAsync (id);
            if (animal == null)
                throw new NotFoundException(id);

            await _animalRepository.DeleteAsync(id);
        }
    }
}
