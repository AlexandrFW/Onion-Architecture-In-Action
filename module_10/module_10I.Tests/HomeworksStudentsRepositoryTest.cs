using AutoMapper;
using DataAccess.Repositories;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using module_10.MockData.Repositories;
using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace module_10.Tests
{
    public class HomeworksStudentsRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly HomeworksStudentsRepository _homeworksStudentsRepositoty;

        public HomeworksStudentsRepositoryTest()
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

            _homeworksStudentsRepositoty = new HomeworksStudentsRepository(_context, _mapper);
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
            var listForCompare = HomeworksStudentsData.GetAll().ToList();
            var list = _homeworksStudentsRepositoty.GetAll().ToList();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test]
        [TestCase("2_1")]
        public void Check_Get_One_Entity_Test(string id)
        {
            // Arrange


            // Act
            var homeworkStudentMock = HomeworksStudentsData.Get(id);
            var homeworkStudent = _homeworksStudentsRepositoty.Get(id);

            // Assert
            Assert.That(homeworkStudentMock, Is.EqualTo(homeworkStudent));
        }

        [Test]
        [TestCase("7_1")]
        public void Check_If_Entity_Not_Exist_Test(string id)
        {
            // Arrange


            // Act
            var student = _homeworksStudentsRepositoty.Get(id);

            // Assert
            Assert.That(student, Is.Null);
        }

        [Test]
        [TestCase(6, 5, ExpectedResult = "5_6")]
        public string Check_If_New_Entity_Added_Test(int homeworkId, int studentId)
        {
            // Arrange
            var homeworkStudent = new HomeworksStudents() { HomeworkId = homeworkId, StudentId = studentId };

            // Act
            return _homeworksStudentsRepositoty.New(homeworkStudent);

            // Assert
        }

        [Test]
        [TestCase("2_4", 6, 2)]
        public void Check_If_New_Entity_Edited_Test(string currentId, int homeworkId, int studentId)
        {
            // Arrange
            var homeworkStudentChanged = new HomeworksStudents() { HomeworkId = homeworkId, StudentId = studentId };
            var id = $"{studentId}_{homeworkId}";

            // Act
            _homeworksStudentsRepositoty.Edit(currentId, homeworkStudentChanged);
            var homeworkStudent = _homeworksStudentsRepositoty.Get(id);

            // Assert
            Assert.That(homeworkStudent.StudentId, Is.EqualTo(studentId));
            Assert.That(homeworkStudent.HomeworkId, Is.EqualTo(homeworkId));
        }

        [Test]
        [TestCase("2_1")]
        public void Check_If_Entity_Deleted_Test(string id)
        {
            // Arrange

            // Act
            _homeworksStudentsRepositoty.Delete(id);
            var homework = _homeworksStudentsRepositoty.Get(id);

            // Assert
            Assert.That(homework, Is.Null);
        }
    }
}