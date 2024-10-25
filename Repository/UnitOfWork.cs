using Developer_Task.Data;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Student = new StudentRepository(_context);
            StudentClass=new StudentClassRepository(_context);
            Teacher= new TeacherRepository(_context);
            Subject = new SubjectRepository(_context);
            Language=new LanguageRepository(_context);

        }
        public IStudentRepository Student { get; private set; }
        public IStudentClassRepository StudentClass { get; private set; }
        public ITeacherRepository Teacher { get; private set; }
        public ISubjectRepository Subject { get; private set; }
        public ILanguageRepository Language { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
