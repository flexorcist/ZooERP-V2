using Application.DTOs;

namespace Application.Services
{
    public interface IZooStatisticsService
    {
        ZooStatisticsDto GetStatistics();
    }
}
