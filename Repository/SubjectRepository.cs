using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class SubjectRepository: GenericRepository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
    }
}
