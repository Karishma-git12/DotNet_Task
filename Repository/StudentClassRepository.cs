using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class StudentClassRepository:GenericRepository<StudentClass>, IStudentClassRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentClassRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(StudentClass studentClass)
        {
            _context.StudentClasses.Update(studentClass);
        }

       
    }
}
