using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository.IRepository;

namespace Developer_Task.Repository
{
    public class LanguageRepository:GenericRepository<Language>,ILanguageRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Language language)
        {
          _context.Languages.Update(language);
        }
    }
}
