using AutoMapper;
using DataAccess.ModelsDb;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    internal class LecturesStudentsRepository : ILecturesStudentsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LecturesStudentsRepository(ApplicationDbContext lecturesDbContext, IMapper mapper)
        {
            _context = lecturesDbContext;
            _mapper = mapper;
        }

        public void Delete(string id)
        {
            if (id is not null)
            {
                string[] arrKeys = id.Split('_');

                var lectureStringToDelete = _context.Homeworks.Find(arrKeys[0], arrKeys[1]);
                if (lectureStringToDelete is not null)
                {
                    _context.Entry(lectureStringToDelete).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
        }

        public void Edit(LecturesStudents lecturesStudents)
        {
            if (_context.LecturesStudents.Find(lecturesStudents.LectureId, lecturesStudents.StudentId) is LecturesStudentsDb lecturesStudentsInDb)
            {
                lecturesStudentsInDb.IsStudentWasAttended = lecturesStudents.IsStudentWasAttended;
                lecturesStudentsInDb.Grade = lecturesStudents.Grade;
                lecturesStudentsInDb.LectureDate = DateTime.Now;

                _context.Entry(lecturesStudentsInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public LecturesStudents? Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string[] arrKeys = id.Split('_');
                var lectureStudentsDb = _context.LecturesStudents
                                                        .Include(s => s.Student)
                                                        .Include(l => l.Lecture)
                                                        .ThenInclude(lr => lr.Lector)
                                                        .Where(x => x.LectureId == int.Parse(arrKeys[0]))
                                                        .FirstOrDefault(y => y.StudentId == int.Parse(arrKeys[1]));

                return _mapper.Map<LecturesStudents?>(lectureStudentsDb);
            }

            return null;
        }

        public IEnumerable<LecturesStudents> GetAll()
        {
            var lectureStudentsDb = _context.LecturesStudents
                                            .Include(s => s.Student)
                                            .Include(l => l.Lecture)
                                            .ThenInclude(lr => lr.Lector)
                                            .ToList();

            return _mapper.Map<IReadOnlyCollection<LecturesStudents>>(lectureStudentsDb);
        }

        public string New(LecturesStudents lecturesStudents)
        {
            var lectureStudentsDb = _mapper.Map<LecturesStudentsDb>(lecturesStudents);
            var result = _context.LecturesStudents.Add(lectureStudentsDb);
            _context.SaveChanges();

            return $"{result.Entity.LectureId}_{result.Entity.StudentId}";
        }
    }
}