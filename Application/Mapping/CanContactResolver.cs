using AutoMapper;
using Application.DTOs;
using Domain.Animals;

namespace Application.Mappings
{
    public class CanContactResolver : IValueResolver<Animal, AnimalDto, bool?>
    {
        public bool? Resolve(Animal source, AnimalDto destination, bool? destMember, ResolutionContext context)
        {
            return (source as Herbivore)?.CanContact;
        }
    }
}
