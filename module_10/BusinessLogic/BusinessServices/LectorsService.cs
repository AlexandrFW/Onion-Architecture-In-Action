using Domain.Interfaces.Repositories;
using Domain.Interfaces.BusinessLogicServices;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.BusinessServices
{
    internal class LectorsService : ILectorsService
    {
        private readonly ILectorsRepository _lectorsRepository;

        public LectorsService(ILectorsRepository lectorsRepository)
        {
            _lectorsRepository = lectorsRepository;
        }

        public void Delete(int id)
        {
            _lectorsRepository.Delete(id);
        }

        public int Edit(int id, Lector lector)
        {
            _lectorsRepository.Edit(id, lector);
            return lector.Id;
        }

        public Lector? Get(int id)
        {
            return _lectorsRepository.Get(id);
        }

        public IReadOnlyCollection<Lector> GetAll()
        {
            return _lectorsRepository.GetAll().ToArray();
        }

        public int New(Lector lector)
        {
            return _lectorsRepository.New(lector);
        }
    }
}