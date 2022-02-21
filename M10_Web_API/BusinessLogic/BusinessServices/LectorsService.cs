using Domain.Interfaces.Repositories;
using Domain.Interfaces.BusinessLogicServices;
using Domain.Models;

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

        public int Edit(Lector lector)
        {
            _lectorsRepository.Edit(lector);
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