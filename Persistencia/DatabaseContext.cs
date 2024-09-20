using Microsoft.Data.Sqlite;
using System;

namespace Persistencia
{

    public class DatabaseContext
    {
        private string connectionString = "Data Source=inscripcion_academica.db";

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }

}
