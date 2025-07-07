using MySql.Data.MySqlClient;

namespace BankingSystem.Services
{
    public class Database
    {
        private const string connectionString = "server=localhost;port=3306;user=root;password=;database=banking system";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
