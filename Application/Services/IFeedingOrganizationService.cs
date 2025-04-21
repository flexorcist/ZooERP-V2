using Application.DTOs;

namespace Application.Services
{
    public interface IFeedingOrganizationService
    {
        FeedingScheduleDto Schedule(CreateFeedingScheduleRequest request);
        void MarkAsDone(Guid scheduleId);
        void Reschedule(Guid scheduleId, DateTimeOffset newTime);
    }
}
