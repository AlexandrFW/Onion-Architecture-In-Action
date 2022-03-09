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
    public class LecturesRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly LecturesRepository _lecturesRepositoty;

        public LecturesRepositoryTest()
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

            _lecturesRepositoty = new LecturesRepository(_context, _mapper);
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
            var listForCompare = LecturesData.GetAll().ToList();
            var list = _lecturesRepositoty.GetAll().ToList();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test]
        [TestCase(1)]
        public void Check_Get_One_Entity_Test(int id)
        {
            // Arrange


            // Act
            var lectureMock = LecturesData.Get(id);
            var lecture = _lecturesRepositoty.Get(id);

            // Assert
            Assert.That(lectureMock, Is.EqualTo(lecture));
        }

        [Test]
        [TestCase(9)]
        public void Check_If_Entity_Not_Exist_Test(int id)
        {
            // Arrange


            // Act
            var homework = _lecturesRepositoty.Get(id);

            // Assert
            Assert.That(homework, Is.Null);
        }

        [Test]
        [TestCase(8, 2, "Worlds economy", ExpectedResult = 8)] // if already exists
        public int Check_If_New_Entity_Added_Test(int id, int lectorId, string lectureName)
        {

            // Arrange
            var lecture = new Lecture() { Id = id, LectorId = lectorId, LectureName = lectureName };

            // Act
            return _lecturesRepositoty.New(lecture);

            // Assert
        }

        [Test]
        [TestCase(2, 3, "Worlds economy")]
        public void Check_If_New_Entity_Edited_Test(int id, int lectorId, string lectureName)
        {
            // Arrange
            var lectureChanged = new Lecture() { Id = id, LectorId = lectorId, LectureName = lectureName };

            // Act
            _lecturesRepositoty.Edit(id, lectureChanged);
            var lecture = _lecturesRepositoty.Get(id);

            // Assert
            Assert.That(lecture.LectureName, Is.EqualTo(lectureName));
            Assert.That(lecture.LectorId, Is.EqualTo(lectorId));
        }

        [Test]
        [TestCase(1)]
        public void Check_If_Entity_Deleted_Test(int id)
        {
            // Arrange

            // Act
            _lecturesRepositoty.Delete(id);
            var lecture = _lecturesRepositoty.Get(id);

            // Assert
            Assert.That(lecture, Is.Null);
        }
    }
}