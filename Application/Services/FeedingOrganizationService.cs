using System;
using Domain.Repositories;
using Domain.Feeding;
using Application.DTOs;
using AutoMapper;

namespace Application.Services
{
    public class FeedingOrganizationService : IFeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _schedRepo;
        private readonly IMapper _mapper;

        public FeedingOrganizationService(
            IFeedingScheduleRepository schedRepo,
            IMapper mapper)
        {
            _schedRepo = schedRepo;
            _mapper = mapper;
        }

        public FeedingScheduleDto Schedule(CreateFeedingScheduleRequest request)
        {
            var id = FeedingScheduleId.CreateNew();
            var animalId = Domain.Animals.AnimalId.From(request.AnimalId);
            var time = new FeedingTime(request.Time);
            var food = new FoodType(request.FoodType);

            var schedule = new FeedingSchedule(id, animalId, time, food);
            _schedRepo.Add(schedule);

            return _mapper.Map<FeedingScheduleDto>(schedule);
        }

        public void MarkAsDone(Guid scheduleId)
        {
            var id = FeedingScheduleId.From(scheduleId);
            var schedule = _schedRepo.GetById(id);
            schedule.MarkAsDone();
        }

        public void Reschedule(Guid scheduleId, DateTimeOffset newTime)
        {
            var id = FeedingScheduleId.From(scheduleId);
            var schedule = _schedRepo.GetById(id);
            schedule.Reschedule(new FeedingTime(newTime));
        }
    }
}
