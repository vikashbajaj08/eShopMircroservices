namespace Authication.Infrastructure.UnitOfWork
{
    public interface IWork : IDisposable
    {
        void Commit();

        void Rollback();

        new void Dispose();
    }
}
