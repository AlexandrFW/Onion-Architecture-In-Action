using System;

namespace Domain.Models
{
    [Serializable]
    public class LecturesStudents : IComparable<LecturesStudents>
    {
        public int LectureId { get; set; }

        public string LectureName { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime LectureDate { get; set; }

        public int Grade { get; set; }

        public bool IsStudentAttended { get; set; }

        public string LectorName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is LecturesStudents lecturesStudents)
            {
                return (LectureId == lecturesStudents.LectureId && StudentId == lecturesStudents.StudentId);
            }

            return false;
        }

        public int CompareTo(LecturesStudents? otherLectureStudent)
        {
            if (otherLectureStudent is LecturesStudents)
            {
                return otherLectureStudent.LectureId.CompareTo(LectureId);
            }

            return -1;
        }
    }
}