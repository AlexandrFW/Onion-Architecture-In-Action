using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.BusinessServices
{
    internal class HomeworksService : IHomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;
        private readonly ILogger<HomeworksService> _logger;

        public HomeworksService(IHomeworksRepository homeworksRepository, ILogger<HomeworksService> logger)
        {
            _homeworksRepository = homeworksRepository;
            _logger = logger;
        }

        public void Delete(int id)
        {
            _homeworksRepository.Delete(id);
        }

        public int Edit(Homework homework)
        {
            _homeworksRepository.Edit(homework);
            return homework.Id;
        }

        public Homework? Get(int id)
        {
            return _homeworksRepository.Get(id);
        }

        public IReadOnlyCollection<Homework> GetAll()
        {
            return _homeworksRepository.GetAll().ToArray();
        }

        public int New(Homework homework)
        {
            return _homeworksRepository.New(homework);
        }
    }
}