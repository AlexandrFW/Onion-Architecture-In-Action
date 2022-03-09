using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.BusinessServices
{
    internal class HomeworksStudentsService : IHomeworksStudentsService
    {

        private readonly IHomeworksStudentsRepository _homeworksStudentsRepository;
        private readonly ILogger<HomeworksStudentsService> _logger;

        public HomeworksStudentsService(IHomeworksStudentsRepository homeworksStudentsRepository,
                                        ILogger<HomeworksStudentsService> logger)
        {
            _homeworksStudentsRepository = homeworksStudentsRepository;
            _logger = logger;
        }

        public void Delete(string id)
{
            _homeworksStudentsRepository.Delete(id);
        }

        public string Edit(string id, HomeworksStudents homeworksStudents)
{
            _homeworksStudentsRepository.Edit(id, homeworksStudents);

            return $"{homeworksStudents.StudentId}_{homeworksStudents.HomeworkId}";
        }

        public HomeworksStudents? Get(string id)
{
            return _homeworksStudentsRepository.Get(id);
        }

        public IReadOnlyCollection<HomeworksStudents> GetAll()
{
            return _homeworksStudentsRepository.GetAll().ToArray();
        }

        public string New(HomeworksStudents homeworksStudents)
        {
            return _homeworksStudentsRepository.New(homeworksStudents);
        }
    }
}