using Developer_Task.Models;

namespace Developer_Task.Repository.IRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        void Update(Subject subject);
    }
}
