using AutoMapper;
using DataAccess.ModelsDb;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!string.IsNullOrWhiteSpace(id))
            {
                var homeworksStudentsStringToDelete = GetHomeworksStudents(id);

                if (homeworksStudentsStringToDelete is not null)
                {
                    _context.Entry(homeworksStudentsStringToDelete).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
        }

        public void Edit(string id, HomeworksStudents homeworksStudents)
        {
            var homeworksStudentsInDb = GetHomeworksStudents(id);

            if (homeworksStudentsInDb is not null)
            {
                Delete(id);
                New(homeworksStudents);
            }
        }

        public HomeworksStudents? Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var homeworkStudentsDb = GetHomeworksStudents(id);

                if (homeworkStudentsDb is not null)
                    return _mapper.Map<HomeworksStudents?>(homeworkStudentsDb);
                else
                    return null;
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

            return $"{result.Entity.StudentId}_{result.Entity.HomeworkId}";
        }

        private HomeworksStudentsDb? GetHomeworksStudents(string id)
        {
            string[] arrKeys = id.Split('_');

            if (_context is not null)
                return _context.HomeworksStudents.Where(x => x.StudentId == int.Parse(arrKeys[0]))
                                                 .FirstOrDefault(y => y.HomeworkId == int.Parse(arrKeys[1]));
            else
                return null;
        }
    }
}