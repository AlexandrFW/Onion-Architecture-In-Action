namespace Domain.Models
{
    public record Lecture
    {
        public int Id { get; set; }

        public string LectureName { get; set; } = string.Empty;

        public int LectorId { get; set; }
    }
}