using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using DataAccess.ModelsDb;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    internal class LecturesRepository : ILecturesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LecturesRepository(ApplicationDbContext lecturesDbContext, IMapper mapper)
        {
            _context = lecturesDbContext;
            _mapper = mapper;
        }

        public IEnumerable<Lecture> GetAll()
        {
            var lectureDb = _context.Lectures.ToList();
            return _mapper.Map<IReadOnlyCollection<Lecture>>(lectureDb);
        }

        public Lecture? Get(int id)
        {
            var lectureDb = _context.Lectures.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Lecture?>(lectureDb);
        }

        public int New(Lecture lecture)
        {
            var lectureDb = _mapper.Map<LectureDb>(lecture);
            var result = _context.Lectures.Add(lectureDb);
            _context.SaveChanges();
            return result.Entity.Id;
}

        public void Edit(Lecture lecture)
        {
            if (_context.Lectures.Find(lecture.Id) is LectureDb lectureInDb)
            {
                lectureInDb.LectureName = lecture.LectureName;
                _context.Entry(lectureInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var lectureToDelete = _context.Lectures.Find(id);
            if (lectureToDelete is not null)
            {
                _context.Entry(lectureToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }
    }
}