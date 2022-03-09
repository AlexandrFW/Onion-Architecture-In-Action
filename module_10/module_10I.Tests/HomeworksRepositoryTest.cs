using AutoMapper;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using module_10.MockData.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace module_10.Tests
{
    public class HomeworksRepositoryTest : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly HomeworksRepository _homeworksRepositoty; 

        public HomeworksRepositoryTest()
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

            _homeworksRepositoty = new HomeworksRepository(_context, _mapper);
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
            var listForCompare = HomeworksData.GetAll().ToList();
            var list = _homeworksRepositoty.GetAll().ToList();

            //Assert
            Assert.That(listForCompare.SequenceEqual(list), Is.True);
        }

        [Test]
        [TestCase(1)]
        public void Check_Get_One_Entity_Test(int id)
        {
            // Arrange


            // Act
            var homeworkMock = HomeworksData.Get(id);
            var homework = _homeworksRepositoty.Get(id);

            // Assert
            Assert.That(homeworkMock, Is.EqualTo(homework));
        }

        [Test]
        [TestCase(9)]
        public void Check_If_Entity_Not_Exist_Test(int id)
        {
            // Arrange


            // Act
            var homework = _homeworksRepositoty.Get(id);

            // Assert
            Assert.That(homework, Is.Null);
        }

        [Test]
        [TestCase(8, "Philosophy of Kant", ExpectedResult = 8)]
        public int Check_If_New_Entity_Added_Test(int id, string subject)
        {

            // Arrange
            var homework = new Homework() { Id = id, Subject = subject, LectureId = 1 };

            // Act
            return _homeworksRepositoty.New(homework);

            // Assert
        }

        [Test]
        [TestCase(2, "Philosophy of Kant")]
        public void Check_If_New_Entity_Edited_Test(int id, string subject)
        {
            // Arrange
            var homeworkChanged = new Homework() { Id = id, Subject = subject, LectureId = 1 };

            // Act
            _homeworksRepositoty.Edit(id, homeworkChanged);
            var homework = _homeworksRepositoty.Get(id);

            // Assert
            Assert.That(homework.Subject, Is.EqualTo(subject));
        }

        [Test]
        [TestCase(1)]
        public void Check_If_Entity_Deleted_Test(int id)
        {
            // Arrange

            // Act
            _homeworksRepositoty.Delete(id);
            var homework = _homeworksRepositoty.Get(id);

            // Assert
            Assert.That(homework, Is.Null);
        }
    }
}