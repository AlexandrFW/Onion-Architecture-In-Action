using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.BusinessServices
{
    internal class LectureService : ILecturesService
    {
        private readonly ILecturesRepository _lecturesRepository;

        public LectureService(ILecturesRepository lecturesRepository)
        {
            _lecturesRepository = lecturesRepository;
        }

        public void Delete(int id)
        {
            _lecturesRepository.Delete(id);
        }

        public int Edit(Lecture lecture)
        {
            _lecturesRepository.Edit(lecture);
            return lecture.Id;
        }

        public Lecture? Get(int id)
        {
            return _lecturesRepository.Get(id);
        }

        public IReadOnlyCollection<Lecture> GetAll()
        {
            return _lecturesRepository.GetAll().ToArray();
        }

        public int New(Lecture lecture)
        {
            return _lecturesRepository.New(lecture);
        }
    }
}