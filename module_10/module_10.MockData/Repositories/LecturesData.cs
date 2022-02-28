using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public class LecturesData
    {
        private static List<Lecture> _lectures = new()
        {
            new Lecture { Id = 1, LectorId = 1, LectureName = "Philosophy" },
            new Lecture { Id = 2, LectorId = 2, LectureName = "Information technology" },
            new Lecture { Id = 3, LectorId = 1, LectureName = "Psychology" },
            new Lecture { Id = 4, LectorId = 3, LectureName = "Mathematics" },
            new Lecture { Id = 5, LectorId = 4, LectureName = "English" },
            new Lecture { Id = 6, LectorId = 5, LectureName = "Cybernetics" },
            new Lecture { Id = 7, LectorId = 2, LectureName = "Electronics" }
        };

        public static IEnumerable<Lecture> GetAll() => _lectures;

        public static Lecture Get(int id)
        {
            return GetAll().ToList().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}