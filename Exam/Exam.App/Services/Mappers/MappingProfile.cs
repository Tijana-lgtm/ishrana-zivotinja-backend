using AutoMapper;
using Exam.App.Domain;
using Exam.App.Services.Dtos;
using Exam.App.Services.Dtos.Animals;

namespace Exam.App.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ProfileDto>();

            CreateMap<CreateAnimalDto, Animal>()
                .ForMember(dest => dest.AnimalSpecies, opt => opt.Ignore())
                .ForMember(dest => dest.Cage, opt => opt.Ignore());

            CreateMap<UpdateAnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AnimalSpecies, opt => opt.Ignore())
                .ForMember(dest => dest.Cage, opt => opt.Ignore());

            CreateMap<Animal, ShowAnimalDto>()
                .ForMember(dest => dest.AnimalSpeciesName, opt => opt.MapFrom(src => src.AnimalSpecies.Name))
                .ForMember(dest => dest.CageCode, opt => opt.MapFrom(src => src.Cage!.Code));

            CreateMap<AnimalSpecies, AnimalSpeciesDto>();

            CreateMap<Cage, CageDto>();
        }
    }
}