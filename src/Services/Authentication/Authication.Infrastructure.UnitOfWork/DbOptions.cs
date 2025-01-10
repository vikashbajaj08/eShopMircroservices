namespace Authication.Infrastructure.UnitOfWork
{
    public class DbOptions
    {
        private string dbConnection = string.Empty;
        public string DatabaseConnection
        {
            get => dbConnection;

            set
            {
                var builder = new SqlConnection(value);

                dbConnection = builder.ConnectionString;
            }
        }
    }
}
