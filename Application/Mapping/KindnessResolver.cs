using AutoMapper;
using Application.DTOs;
using Domain.Animals;

namespace Application.Mappings
{
    public class KindnessResolver : IValueResolver<Animal, AnimalDto, int?>
    {
        public int? Resolve(Animal source, AnimalDto destination, int? destMember, ResolutionContext context)
        {
            return (source as Herbivore)?.Kindness;
        }
    }
}
