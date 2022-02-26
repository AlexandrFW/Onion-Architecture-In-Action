using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ILecturesStudentsRepository : ILectureStudentsHomeworksRepository<LecturesStudents>
    {
    }
}