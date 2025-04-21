namespace Application.DTOs
{
    public class EnclosureDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Size { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<Guid> AnimalIds { get; set; }
    }
}
