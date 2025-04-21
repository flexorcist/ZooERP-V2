namespace Application.DTOs
{
    public class CreateFeedingScheduleRequest
    {
        public Guid AnimalId { get; set; }
        public DateTimeOffset Time { get; set; }
        public string FoodType { get; set; }
    }
}
