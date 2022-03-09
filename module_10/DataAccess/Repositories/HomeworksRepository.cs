using AutoMapper;
using DataAccess.ModelsDb;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    internal class HomeworksRepository : IHomeworksRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeworksRepository(ApplicationDbContext homeworksDbContext, IMapper mapper)
        {
            _context = homeworksDbContext;
            _mapper = mapper;
        }

        public IEnumerable<Homework> GetAll()
        {
            var homeworkDb = _context.Homeworks
                             .Include(l => l.Lecture)
                             .ToList();

            return _mapper.Map<IReadOnlyCollection<Homework>>(homeworkDb);
        }

        public Homework? Get(int id)
        {
            var homeworkDb = _context.Homeworks.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Homework?>(homeworkDb);
        }

        public int New(Homework homework)
        {
            var homeworkDb = _mapper.Map<HomeworkDb>(homework);
            var result = _context.Homeworks.Add(homeworkDb);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(int id, Homework homework)
        {
            if (_context.Homeworks.Find(id) is HomeworkDb homeworkInDb)
            {
                homeworkInDb.Subject = homework.Subject;
                homeworkInDb.LectureId = homework.LectureId;

                _context.Entry(homeworkInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var homeworkToDelete = _context.Homeworks.Find(id);
            if (homeworkToDelete is not null)
            {
                _context.Entry(homeworkToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }
    }
}