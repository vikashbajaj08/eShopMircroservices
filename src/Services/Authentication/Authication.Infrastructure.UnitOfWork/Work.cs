

namespace Authication.Infrastructure.UnitOfWork
{
    public class Work : IWork
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction transaction;

        public Work(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public void Commit()
        {
            transaction.Commit();
            connection.Close();
        }

        public void Dispose()
        {
           connection.Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
            connection.Close();
        }
    }
}
