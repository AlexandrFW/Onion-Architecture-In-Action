namespace Domain.Interfaces.Extentions
{
    public interface IStudentCheckHomework
    {
        public bool IsStudentHasHomework(int lectureId, int studentId);
    }
}