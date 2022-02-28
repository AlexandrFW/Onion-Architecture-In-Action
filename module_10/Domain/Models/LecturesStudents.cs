using System;

namespace Domain.Models
{
    [Serializable]
    public class LecturesStudents
    {
        public int LectureId { get; set; }

        public string LectureName { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime LectureDate { get; set; }

        public int Grade { get; set; }

        public bool IsStudentAttended { get; set; }

        public string LectorName { get; set; }
    }
}