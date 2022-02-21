namespace Domain.Models
{
    public class LecturesStudents
    {
        public int LectureId { get; set; }

        public int StudentId { get; set; }

        public int Grade { get; set; }

        public bool IsStudentWasAttended { get; set; }
    }
}