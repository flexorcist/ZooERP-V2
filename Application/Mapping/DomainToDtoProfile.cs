using AutoMapper;
using Domain.Animals;
using Domain.Enclosures;
using Domain.Feeding;
using Application.DTOs;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Animal, AnimalDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value))
                .ForMember(d => d.Species, opt => opt.MapFrom(s => s.Species.Name))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Value))
                .ForMember(d => d.FoodConsumption, opt => opt.MapFrom(s => s.Food.KilogramsPerDay))
                .ForMember(d => d.IsHealthy, opt => opt.MapFrom(s => s.IsHealthy))
                .ForMember(d => d.Kindness, opt => opt.MapFrom<KindnessResolver>())
                .ForMember(d => d.CanContact, opt => opt.MapFrom<CanContactResolver>());

            CreateMap<Enclosure, EnclosureDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Size.SquareMeters))
                .ForMember(d => d.Capacity, opt => opt.MapFrom(s => s.Capacity))
                .ForMember(d => d.AnimalIds, opt => opt.MapFrom(s => s.AnimalIds.Select(a => a.Value)));

            CreateMap<FeedingSchedule, FeedingScheduleDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value))
                .ForMember(d => d.AnimalId, opt => opt.MapFrom(s => s.AnimalId.Value))
                .ForMember(d => d.Time, opt => opt.MapFrom(s => s.Time.When))
                .ForMember(d => d.FoodType, opt => opt.MapFrom(s => s.Food.Name))
                .ForMember(d => d.IsCompleted, opt => opt.MapFrom(s => s.IsCompleted));
        }
    }
}
