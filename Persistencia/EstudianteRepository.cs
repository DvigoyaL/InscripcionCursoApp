using DTO;
using Entidades;
using Microsoft.Data.Sqlite;
using Persistencia;


public class EstudianteRepository
{
    private readonly EstudianteFactory estudianteFactory = new EstudianteFactory();
    private DatabaseContext dbContext = new DatabaseContext();

    public List<EstudianteDTO> ObtenerTodos()
    {
        List<EstudianteDTO> estudiantes = new List<EstudianteDTO>();
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Estudiantes";
            SqliteCommand command = new SqliteCommand(query, connection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EstudianteDTO estudiante = new EstudianteDTO()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Documento = reader["Documento"].ToString(),
                    ProgramaId = Convert.ToInt32(reader["ProgramaId"])
                };
                estudiantes.Add(estudiante);
            }
        }
        return estudiantes;
    }

    public EstudianteDTO ObtenerPorId(int id)
    {
        EstudianteDTO estudiante = null;
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Estudiantes WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                estudiante = new EstudianteDTO()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Documento = reader["Documento"].ToString(),
                    ProgramaId = Convert.ToInt32(reader["ProgramaId"])
                };
            }
        }
        return estudiante;
    }

    public void Agregar(EstudianteDTO estudianteDTO)
    {
        // Usar la fábrica para crear una instancia de la entidad Estudiante
        Estudiante estudiante = estudianteFactory.CrearEstudiante(estudianteDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO Estudiantes (Nombre, Documento, ProgramaId) VALUES (@Nombre, @Documento, @ProgramaId)";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Documento", estudiante.Documento);
            command.Parameters.AddWithValue("@ProgramaId", estudiante.ProgramaId);
            command.ExecuteNonQuery();
        }
    }

    public void Actualizar(EstudianteDTO estudianteDTO)
    {
        // Usar la fábrica para crear una instancia de la entidad Estudiante
        Estudiante estudiante = estudianteFactory.CrearEstudiante(estudianteDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "UPDATE Estudiantes SET Nombre = @Nombre, Documento = @Documento, ProgramaId = @ProgramaId WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Documento", estudiante.Documento);
            command.Parameters.AddWithValue("@ProgramaId", estudiante.ProgramaId);
            command.Parameters.AddWithValue("@Id", estudiante.Id);
            command.ExecuteNonQuery();
        }
    }

    public void Eliminar(int id)
    {
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM Estudiantes WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
