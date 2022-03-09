using System;

namespace Domain.Models
{
    public class HomeworksStudents : IComparable<HomeworksStudents>
    {
        public int StudentId { get; set; }
        public int HomeworkId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is HomeworksStudents homeworksStudents)
            {
                return (StudentId == homeworksStudents.StudentId && HomeworkId == homeworksStudents.HomeworkId);
            }

            return false;
        }

        public int CompareTo(HomeworksStudents? otherLectureStudent)
        {
            if (otherLectureStudent is HomeworksStudents)
            {
                return otherLectureStudent.HomeworkId.CompareTo(HomeworkId);
            }

            return -1;
        }
    }
}