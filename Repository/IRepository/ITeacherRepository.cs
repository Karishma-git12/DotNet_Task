using Developer_Task.Models;

namespace Developer_Task.Repository.IRepository
{
    public interface ITeacherRepository: IGenericRepository<Teacher>
    {
        void Update(Teacher teacher);
    }
}
