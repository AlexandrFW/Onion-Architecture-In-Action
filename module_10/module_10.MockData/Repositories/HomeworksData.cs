using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public static class HomeworksData
    {
        private static List<Homework> _homeworks = new()
        {
             new Homework { Id = 1, Subject = "Philosophy of ancient Rome", LectureId = 1 },
             new Homework { Id = 2, Subject = "Theory of Algorithms", LectureId = 2 },
             new Homework { Id = 3, Subject = "Passive voice", LectureId = 5 },
             new Homework { Id = 4, Subject = "Transistors in modern electronics", LectureId = 7 },
             new Homework { Id = 5, Subject = "Mathematical modeling", LectureId = 6 },
             new Homework { Id = 6, Subject = "What a philosophy is: subject, object and subject of science, methods", LectureId = 1 },
             new Homework { Id = 7, Subject = "Mathematical modeling. Part 2", LectureId = 6 }
        };

        public static IEnumerable<Homework> GetAll() => _homeworks;

        public static Homework Get(int id)
        {
            return GetAll().ToList().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}