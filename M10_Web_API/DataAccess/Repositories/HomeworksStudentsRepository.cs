using AutoMapper;
using DataAccess.ModelsDb;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class HomeworksStudentsRepository : IHomeworksStudentsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeworksStudentsRepository(ApplicationDbContext lecturesDbContext, IMapper mapper)
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

        public void Edit(HomeworksStudents homeworksStudents)
        {
            if (_context.HomeworksStudents.Find(homeworksStudents.HomeworkId, homeworksStudents.StudentId) is HomeworksStudentsDb homeworksStudentsInDb)
            {
                homeworksStudentsInDb.HomeworkId = homeworksStudents.HomeworkId;
                homeworksStudentsInDb.StudentId = homeworksStudents.StudentId;

                _context.Entry(homeworksStudentsInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public HomeworksStudents? Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string[] arrKeys = id.Split('_');
                var homeworkStudentsDb = _context.HomeworksStudents.Where(x => x.HomeworkId == int.Parse(arrKeys[0]))
                                                                 .FirstOrDefault(y => y.StudentId == int.Parse(arrKeys[1]));
                return _mapper.Map<HomeworksStudents?>(homeworkStudentsDb);
            }

            return null;
        }

        public IEnumerable<HomeworksStudents> GetAll()
        {
            var homeworkStudentsDb = _context.HomeworksStudents.ToList();
            return _mapper.Map<IReadOnlyCollection<HomeworksStudents>>(homeworkStudentsDb);
        }

        public string New(HomeworksStudents lecturesStudents)
        {
            var homeworkStudentsDb = _mapper.Map<HomeworksStudentsDb>(lecturesStudents);
            var result = _context.HomeworksStudents.Add(homeworkStudentsDb);
            _context.SaveChanges();

            return $"{result.Entity.HomeworkId}_{result.Entity.StudentId}";
        }
    }
}