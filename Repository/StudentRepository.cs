using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
