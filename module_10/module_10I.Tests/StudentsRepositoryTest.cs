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
    public class StudentsRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentsRepository _studentsRepositoty;

        public StudentsRepositoryTest()
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

            _studentsRepositoty = new StudentsRepository(_context, _mapper);
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
            var listForCompare = StudentsData.GetAll().ToList();
            var list = _studentsRepositoty.GetAll().ToList();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test]
        [TestCase(1)]
        public void Check_Get_One_Entity_Test(int id)
        {
            // Arrange


            // Act
            var studentMock = StudentsData.Get(id);
            var student = _studentsRepositoty.Get(id);

            // Assert
            Assert.That(studentMock, Is.EqualTo(student));
        }

        [Test]
        [TestCase(9)]
        public void Check_If_Entity_Not_Exist_Test(int id)
        {
            // Arrange


            // Act
            var student = _studentsRepositoty.Get(id);

            // Assert
            Assert.That(student, Is.Null);
        }

        [Test]
        [TestCase(6, "Nikolay Alferov", 18, "n.alferov@gmail.com", "+79042453321", ExpectedResult = 6)]
        public int Check_If_New_Entity_Added_Test(int id, string name, int age, string email, string phone)
        {
            // Arrange
            var student = new Student() { Id = id, Name = name, Age = age, Email = email, Phone = phone };

            // Act
            return _studentsRepositoty.New(student);

            // Assert
        }

        [Test]
        [TestCase(2, "Nikolay Alferov", 18, "n.alferov@gmail.com", "+79042453321")]
        public void Check_If_New_Entity_Edited_Test(int id, string name, int age, string email, string phone)
        {
            // Arrange
            var studentChanged = new Student() { Id = id, Name = name, Age = age, Email = email, Phone = phone };

           // Act
            _studentsRepositoty.Edit(id, studentChanged);
            var student = _studentsRepositoty.Get(id);

            // Assert
            Assert.That(student.Name, Is.EqualTo(name));
            Assert.That(student.Age, Is.EqualTo(age));
            Assert.That(student.Email, Is.EqualTo(email));
            Assert.That(student.Phone, Is.EqualTo(phone));
        }

        [Test]
        [TestCase(1)]
        public void Check_If_Entity_Deleted_Test(int id)
        {
            // Arrange

            // Act
            _studentsRepositoty.Delete(id);
            var homework = _studentsRepositoty.Get(id);

            // Assert
            Assert.That(homework, Is.Null);
        }
    }
}