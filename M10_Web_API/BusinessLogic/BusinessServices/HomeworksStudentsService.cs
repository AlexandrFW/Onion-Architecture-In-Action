using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
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

        public string Edit(HomeworksStudents homeworksStudents)
{
            _homeworksStudentsRepository.Edit(homeworksStudents);

            return $"{homeworksStudents.HomeworkId}_{homeworksStudents.StudentId}";
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