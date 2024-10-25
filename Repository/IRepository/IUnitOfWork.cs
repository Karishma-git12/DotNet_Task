namespace Developer_Task.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get;}
        IStudentClassRepository StudentClass { get;}
        ITeacherRepository Teacher { get; }
        ISubjectRepository Subject { get; }
        ILanguageRepository Language { get; }
        void Save();
    }
}
