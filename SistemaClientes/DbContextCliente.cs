using Microsoft.Data.Sqlite;

namespace SistemaClientes
{

    public class DbContextCliente
    {
        private string connectionString = "Data Source=clientes.db;Version=3;";

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }

}
