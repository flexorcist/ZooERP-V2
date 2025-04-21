using Microsoft.Extensions.DependencyInjection;
using Application.Services;

namespace Application.DI
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mappings.DomainToDtoProfile).Assembly);

            services.AddScoped<ISpeciesService, SpeciesService>();

            services.AddScoped<IAnimalManagementService, AnimalManagementService>();
            services.AddScoped<IEnclosureManagementService, EnclosureManagementService>();

            services.AddScoped<IAnimalTransferService, AnimalTransferService>();
            services.AddScoped<IFeedingOrganizationService, FeedingOrganizationService>();
            services.AddScoped<IZooStatisticsService, ZooStatisticsService>();

            return services;
        }
    }
}
