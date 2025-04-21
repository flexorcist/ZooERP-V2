using Microsoft.Extensions.DependencyInjection;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Domain.Animals;

namespace Infrastructure.DI
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Репозитории
            services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
            services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
            services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();

            // Cервисы
            services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
            services.AddSingleton<IAnimalFactory, AnimalFactory>();

            return services;
        }
    }
}
