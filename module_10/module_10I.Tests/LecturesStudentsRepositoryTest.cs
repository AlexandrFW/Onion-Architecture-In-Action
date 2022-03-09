using AutoMapper;
using DataAccess.Repositories;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using module_10.MockData.Repositories;
using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace module_10.Tests
{
    public class LecturesStudentsRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly LecturesStudentsRepository _lecturesStudentsRepositoty;

        public LecturesStudentsRepositoryTest()
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

            _lecturesStudentsRepositoty = new LecturesStudentsRepository(_context, _mapper);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Test, Order(1)]
        public void Check_GetAll_Test()
        {
            // Arrange            

            // Act
            var listForCompare = LecturesStudentsData.GetAll().ToList();
            var list = _lecturesStudentsRepositoty.GetAll().ToList();

            listForCompare.Sort();
            list.Sort();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test, Order(2)]
        [TestCase("2_1")]
        public void Check_Get_One_Entity_Test(string id)
        {
            // Arrange

            // Act
            var lectureStudentMock = LecturesStudentsData.Get(id);
            var lectureStudent = _lecturesStudentsRepositoty.Get(id);

            // Assert
            Assert.That(lectureStudentMock, Is.EqualTo(lectureStudent));
        }

        [Test, Order(3)]
        [TestCase("7_1")]
        public void Check_If_Entity_Not_Exist_Test(string id)
        {
            // Arrange


            // Act
            var lectureStudent = _lecturesStudentsRepositoty.Get(id);

            // Assert
            Assert.That(lectureStudent, Is.Null);
        }

        [Test, Order(4)]
        [TestCase(5, 5, ExpectedResult = "5_5")]
        public string Check_If_New_Entity_Added_Test(int lectureId, int studentId)
        {
            // Arrange
            var lectureStudent =  new LecturesStudents
            {
                LectureId = lectureId,
                LectureName = "English",
                StudentId = studentId,
                StudentName = "Dmitry Nevedof",
                Grade = 0,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"
            };

            // Act
            return _lecturesStudentsRepositoty.New(lectureStudent);

            // Assert
        }

        [Test, Order(5)]
        [TestCase("2_5", 4, true)]
        public void Check_If_New_Entity_Edited_Test(string currentId, int grade, bool isStudentAttended)
        {
            // Arrange
            var lectureStudentChanged = new LecturesStudents
            {
                LectureId = 0,
                LectureName = "",
                StudentId = 0,
                StudentName = "",
                Grade = grade,
                IsStudentAttended = isStudentAttended,
                LectureDate = DateTime.Now,
                LectorName = "Anatoly Vladimirovich Smolny"
            };

            // Act
            _lecturesStudentsRepositoty.Edit(currentId, lectureStudentChanged);
            var lectureStudent = _lecturesStudentsRepositoty.Get(currentId);

            // Assert
            Assert.That(lectureStudent.Grade, Is.EqualTo(grade));
            Assert.That(lectureStudent.IsStudentAttended, Is.EqualTo(isStudentAttended));
        }

        [Test]
        [TestCase("2_2")]
        public void Check_If_Entity_Deleted_Test(string id)
        {
            // Arrange

            // Act
            _lecturesStudentsRepositoty.Delete(id);
            var lectureStudent = _lecturesStudentsRepositoty.Get(id);

            // Assert
            Assert.That(lectureStudent, Is.Null);
        }
    }
}