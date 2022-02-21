using Domain.Models;
using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;

namespace BusinessLogic.BusinessServices
{
    internal class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public void Delete(int id)
        {
            _studentsRepository.Delete(id);
        }

        public int Edit(Student student)
        {
            _studentsRepository.Edit(student);
            return student.Id;
        }

        public Student? Get(int id)
        {
            return _studentsRepository.Get(id);
        }

        public IReadOnlyCollection<Student> GetAll()
        {
            return _studentsRepository.GetAll().ToArray();
        }

        public int New(Student Student)
        {
            return _studentsRepository.New(Student);
        }
    }
}