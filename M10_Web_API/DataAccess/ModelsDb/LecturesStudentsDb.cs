namespace DataAccess.ModelsDb
{
    internal class LecturesStudentsDb
    {
        public int LectureId { get; set; }
        public LectureDb Lecture { get; set; }

        public int StudentId { get; set; }
        public StudentDb Student { get; set; }

        public DateTime LectureDate { get; set; }

        public int Grade { get; set; }

        public bool IsStudentWasAttended { get; set; }        
    }
}