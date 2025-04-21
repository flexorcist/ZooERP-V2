namespace Application.DTOs
{
    public class FeedingScheduleDto
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public DateTimeOffset Time { get; set; }
        public string FoodType { get; set; }
        public bool IsCompleted { get; set; }
    }
}
