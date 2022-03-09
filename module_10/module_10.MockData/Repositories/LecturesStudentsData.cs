using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public class LecturesStudentsData
    {
        private static readonly List<LecturesStudents> _lecturesStudents = new()
        {
            new LecturesStudents
            {
                LectureId = 2,
                LectureName = "Information technology",
                StudentId = 3,
                StudentName = "Anna Antonova",
                Grade = 4,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"

            },
            new LecturesStudents
            {
                LectureId = 2,
                LectureName = "Information technology",
                StudentId = 2,
                StudentName = "Grigory Sidorov",
                Grade = 0,
                IsStudentAttended = false,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"
            },
            new LecturesStudents
            {
                LectureId = 3,
                LectureName = "Psychology",
                StudentId = 5,
                StudentName = "Dmitry Nevedof",
                Grade = 3,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = "Vitaly Genadievich Gromov"
            },
            new LecturesStudents
            {
                LectureId = 3,
                LectureName = "Psychology",
                StudentId = 4,
                StudentName = "Svatlana Vasileva",
                Grade = 5,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = "Vitaly Genadievich Gromov"
            },
            new LecturesStudents
            {
                LectureId = 2,
                LectureName = "Information technology",
                StudentId = 4,
                StudentName = "Svatlana Vasileva",
                Grade = 0,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"
            },
            new LecturesStudents
            {
                LectureId = 2,
                LectureName = "Information technology",
                StudentId = 5,
                StudentName = "Dmitry Nevedof",
                Grade = 0,
                IsStudentAttended = false,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"
            }
        };

        public static IEnumerable<LecturesStudents> GetAll() => _lecturesStudents;

        public static LecturesStudents? Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var arrKeys = id.Split('_');
                return GetAll().ToList().Where(x => x.LectureId == Convert.ToInt32(arrKeys[0]))
                                        .Where(y => y.StudentId == Convert.ToInt32(arrKeys[1]))
                                        .FirstOrDefault();
            }

            return null;
        }
    }
}