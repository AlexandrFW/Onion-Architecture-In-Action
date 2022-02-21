namespace Domain.Models
{
    public record Homework
    {
        public int Id { get; set; }

        public string Subject { get; set; } = string.Empty;
        
        public int LectureId { get; set; }
    }
}