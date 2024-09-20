using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace SistemaClientes
{
    
    public class ClientesRepository
    {
        private DbContextCliente dbContext = new DbContextCliente();

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Clientes";
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Documento = reader["Documento"].ToString(),
                        CorreoElectronico = reader["CorreoElectronico"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Clientes WHERE Id = @Id";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                SqliteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Documento = reader["Documento"].ToString(),
                        CorreoElectronico = reader["CorreoElectronico"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };
                }
            }
            return cliente;
        }

        public void Agregar(Cliente cliente)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Clientes (Nombre, Documento, CorreoElectronico, Telefono) VALUES (@Nombre, @Documento, @CorreoElectronico, @Telefono)";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Clientes SET Nombre = @Nombre, Documento = @Documento, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE Id = @Id";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Clientes WHERE Id = @Id";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}
