using Developer_Task.Models;

namespace Developer_Task.Repository.IRepository
{
    public interface IStudentClassRepository : IGenericRepository<StudentClass>
    {
        void Update(StudentClass studentClass);
    }
}
