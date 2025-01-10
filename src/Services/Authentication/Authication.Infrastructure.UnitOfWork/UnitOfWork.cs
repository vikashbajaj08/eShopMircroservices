using Microsoft.Extensions.Options;

namespace Authication.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbOptions options;

        private IDbTransaction transaction;

        private IDbConnection connection;

        public UnitOfWork(IOptions<DbOptions> options)
        {
            this.options = options.Value ?? throw new ArgumentNullException(nameof(options    ));
        }
        public IDbTransaction Transaction
        {
            get
            {
                return transaction ?? throw new InvalidOperationException("You must call Begin() to start the transaction");
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return connection ?? throw new InvalidOperationException("You must call Begin() to start the Unit of work");
            }
        }
        public IWork Begin()
        {
            connection = new SqlConnection(options.DatabaseConnection);
            connection.Open();
            transaction= connection.BeginTransaction();
            return new Work(connection, transaction);
        }
    }
}
