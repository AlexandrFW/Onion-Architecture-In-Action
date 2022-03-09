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
    internal class LectorsRepository : ILectorsRepository 
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LectorsRepository(ApplicationDbContext lectorsDbContext, IMapper mapper)
        {
            _context = lectorsDbContext;
            _mapper = mapper;
        }

        public IEnumerable<Lector> GetAll()
        {
            var lectorsDb = _context.Lectors.ToList();
            return _mapper.Map<IReadOnlyCollection<Lector>>(lectorsDb);
        }

        public Lector? Get(int id)
        {
            var lectorDb = _context.Lectors.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Lector?>(lectorDb);
        }

        public int New(Lector lector)
        {
            var lectorDb = _mapper.Map<LectorDb>(lector);
            lectorDb.CreateDate = DateTime.Now;
            var result = _context.Lectors.Add(lectorDb);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(int id, Lector lector)
        {
            if (_context.Lectors.Find(id) is LectorDb lectorInDb)
            {
                lectorInDb.Name = lector.Name;
                lectorInDb.Email = lector.Email;
                lectorInDb.Age = lector.Age;
                lectorInDb.Phone = lector.Phone;

                _context.Entry(lectorInDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var lectorToDelete = _context.Lectors.Find(id);
            if (lectorToDelete is not null)
            {
                _context.Entry(lectorToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }
    }
}