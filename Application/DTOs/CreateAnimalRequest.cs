namespace Application.DTOs
{
    public class CreateAnimalRequest
    {
        public string Species { get; set; }
        public string Name { get; set; }
        public int FoodConsumption { get; set; }
        public bool IsHealthy { get; set; }
        public int? Kindness { get; set; }
    }
}
