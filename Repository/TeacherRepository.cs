using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            
        }
    }
}
