namespace Domain.ServiceTools
{
    public class ReportFilterCriteria
    {
        public string Format { get; set; } = string.Empty;   // json or xml
        public string Criteria { get; set; } = string.Empty; // Student or Lecture
        public int Id { get; set; }
    }
}