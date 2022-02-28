using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public static class HomeworksStudentsData
    {
        private static readonly List<HomeworksStudents> _homeworkStudents = new()
        {
            new HomeworksStudents() { StudentId = 1, HomeworkId = 2 },
            new HomeworksStudents() { StudentId = 2, HomeworkId = 2 },
            new HomeworksStudents() { StudentId = 3, HomeworkId = 2 },
            new HomeworksStudents() { StudentId = 4, HomeworkId = 2 },
            new HomeworksStudents() { StudentId = 5, HomeworkId = 2 },
            new HomeworksStudents() { StudentId = 1, HomeworkId = 1 },
            new HomeworksStudents() { StudentId = 2, HomeworkId = 1 },
            new HomeworksStudents() { StudentId = 3, HomeworkId = 1 },
            new HomeworksStudents() { StudentId = 4, HomeworkId = 1 },
            new HomeworksStudents() { StudentId = 5, HomeworkId = 1 },
            new HomeworksStudents() { StudentId = 1, HomeworkId = 3 },
            new HomeworksStudents() { StudentId = 2, HomeworkId = 3 },
            new HomeworksStudents() { StudentId = 3, HomeworkId = 3 },
            new HomeworksStudents() { StudentId = 4, HomeworkId = 3 },
            new HomeworksStudents() { StudentId = 5, HomeworkId = 3 },
            new HomeworksStudents() { StudentId = 1, HomeworkId = 4 },
            new HomeworksStudents() { StudentId = 2, HomeworkId = 4 },
            new HomeworksStudents() { StudentId = 3, HomeworkId = 4 },
            new HomeworksStudents() { StudentId = 4, HomeworkId = 4 },
            new HomeworksStudents() { StudentId = 5, HomeworkId = 4 }
        };

        public static IEnumerable<HomeworksStudents> GetAll() => _homeworkStudents;

        public static HomeworksStudents? Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var arrKeys = id.Split('_');
                return GetAll().ToList().Where(x => x.StudentId == Convert.ToInt32(arrKeys[0]))
                                        .Where(y => y.HomeworkId == Convert.ToInt32(arrKeys[1]))
                                        .FirstOrDefault();
            }

            return null;
        }
    }
}