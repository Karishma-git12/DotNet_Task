using Developer_Task.Models;

namespace Developer_Task.Repository.IRepository
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        void Update(Student student);
    }
}
