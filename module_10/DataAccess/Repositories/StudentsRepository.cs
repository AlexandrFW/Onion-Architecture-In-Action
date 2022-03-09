using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using DataAccess.ModelsDb;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccess.Repositories
{
    internal class StudentsRepository : IStudentsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentsRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            this._mapper = mapper;
        }

        public IEnumerable<Student> GetAll()
        {
            var studentsDb = _context.Students.ToList();
            return _mapper.Map<IReadOnlyCollection<Student>>(studentsDb);
        }

        public Student? Get(int id)
        {
            var studentDb = _context.Students.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Student?>(studentDb);
        }

        public int New(Student student)
        {
            var studentDb = _mapper.Map<StudentDb>(student);
            studentDb.CreateDate = DateTime.Now;
            var result = _context.Students.Add(studentDb);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(int id, Student student)
        {
            if (_context.Students.Find(id) is StudentDb studentInDb)
            {
                studentInDb.Name = student.Name;
                studentInDb.Email = student.Email;
                studentInDb.Age = student.Age;
                studentInDb.Phone = student.Phone;

                _context.Entry(studentInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var studentToDelete = _context.Students.Find(id);
            if (studentToDelete is not null)
            {
                _context.Entry(studentToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }
    }
}