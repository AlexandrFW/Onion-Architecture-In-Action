using AutoMapper;
using DataAccess.Repositories;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using module_10.MockData.Repositories;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;

namespace module_10.Tests
{
    public class LectorsRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly LectorsRepository _lectorsRepositoty;

        public LectorsRepositoryTest()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase("ApplicationDbContext")
                                      .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                      .Options;
            _context = new ApplicationDbContext(_contextOptions);

            var mapperProfileConf = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper _mapper = new Mapper(mapperProfileConf);

            _lectorsRepositoty = new LectorsRepository(_context, _mapper);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

        [Test]
        public void Check_GetAll_Test()
        {
            // Arrange            

            // Act
            var listForCompare = LectorsData.GetAll().ToList();
            var list = _lectorsRepositoty.GetAll().ToList();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test]
        [TestCase(1)]
        public void Check_Get_One_Entity_Test(int id)
        {
            // Arrange


            // Act
            var lectorMock = LectorsData.Get(id);
            var lector = _lectorsRepositoty.Get(id);

            // Assert
            Assert.That(lectorMock, Is.EqualTo(lector));
        }

        [Test]
        [TestCase(9)]
        public void Check_If_Entity_Not_Exist_Test(int id)
        {
            // Arrange


            // Act
            var lector = _lectorsRepositoty.Get(id);

            // Assert
            Assert.That(lector, Is.Null);
        }

        [Test]
        [TestCase(6, "Vitaly Genadievich Gromov", 45, "vitaly.gromov@universitat.ru", "+79010078912", ExpectedResult = 6)]
        public int Check_If_New_Entity_Added_Test(int id, string name, int age, string email, string phone)
        {

            // Arrange
            var lector = new Lector() { Id = id, Name = name, Age = age, Email = email, Phone = phone };

            // Act
            return _lectorsRepositoty.New(lector);

            // Assert
        }

        [Test]
        [TestCase(1, "Vitaly Alexandrovich Gromov", 39, "vitaly.gromov@universitat.ru", "+79101079912")]
        public void Check_If_New_Entity_Edited_Test(int id, string name, int age, string email, string phone)
        {
            // Arrange
            var lectorChanged = new Lector() { Id = id, Name = name, Age = age, Email = email, Phone = phone };

            // Act
            _lectorsRepositoty.Edit(id, lectorChanged);
            var lector = _lectorsRepositoty.Get(id);

            // Assert
            Assert.That(lector.Name, Is.EqualTo(name));
            Assert.That(lector.Age, Is.EqualTo(age));
            Assert.That(lector.Email, Is.EqualTo(email));
            Assert.That(lector.Phone, Is.EqualTo(phone));
        }

        [Test]
        [TestCase(2)]
        public void Check_If_Entity_Deleted_Test(int id)
        {
            // Arrange

            // Act
            _lectorsRepositoty.Delete(id);
            var lector = _lectorsRepositoty.Get(id);

            // Assert
            Assert.That(lector, Is.Null);
        }
    }
}