namespace Application.DTOs
{
    public class TransferAnimalRequest
    {
        public Guid AnimalId { get; set; }
        public Guid FromEnclosureId { get; set; }
        public Guid ToEnclosureId { get; set; }
    }
}
