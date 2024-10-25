using Developer_Task.Models;

namespace Developer_Task.Repository.IRepository
{
    public interface ILanguageRepository: IGenericRepository<Language>
    {
        void Update(Language language);
    }
}
