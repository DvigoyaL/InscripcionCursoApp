using DTO;
using Entidades;
using Microsoft.Data.Sqlite;
using Persistencia;


public class ProgramaRepository
{
    private DatabaseContext dbContext = new DatabaseContext();
    private readonly ProgramaFactory programaFactory = new ProgramaFactory();

    public List<ProgramaDTO> ObtenerTodos()
    {
        List<ProgramaDTO> programas = new List<ProgramaDTO>();
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Programas";
            SqliteCommand command = new SqliteCommand(query, connection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProgramaDTO programa = new ProgramaDTO()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Descripcion = reader["Descripcion"].ToString()
                };
                programas.Add(programa);
            }
        }
        return programas;
    }

    public ProgramaDTO ObtenerPorId(int id)
    {
        ProgramaDTO programa = null;
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Programas WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                programa = new ProgramaDTO()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Descripcion = reader["Descripcion"].ToString()
                };
            }
        }
        return programa;
    }

    public void Agregar(ProgramaDTO programaDTO)
    {
        Programa programa = programaFactory.CrearPrograma(programaDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO Programas (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", programa.Nombre);
            command.Parameters.AddWithValue("@Descripcion", programa.Descripcion);
            command.ExecuteNonQuery();
        }
    }

    public void Actualizar(ProgramaDTO programaDTO)
    {
        Programa programa = programaFactory.CrearPrograma(programaDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "UPDATE Programas SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", programa.Nombre);
            command.Parameters.AddWithValue("@Descripcion", programa.Descripcion);
            command.Parameters.AddWithValue("@Id", programa.Id);
            command.ExecuteNonQuery();
        }
    }

    public void Eliminar(int id)
    {
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM Programas WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
