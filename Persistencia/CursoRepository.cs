using DTO;
using Entidades;
using Microsoft.Data.Sqlite;
using Persistencia;


public class CursoRepository
{
    private DatabaseContext dbContext = new DatabaseContext();
    private readonly CursoFactory cursoFactory = new CursoFactory();

    public List<CursoDTO> ObtenerTodos()
    {
        List<CursoDTO> cursos = new List<CursoDTO>();
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Cursos";
            SqliteCommand command = new SqliteCommand(query, connection);
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CursoDTO curso = new CursoDTO
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Creditos = Convert.ToInt32(reader["Creditos"]),
                    ProgramaId = Convert.ToInt32(reader["ProgramaId"])
                };
                cursos.Add(curso);
            }
        }
        return cursos;
    }

    public CursoDTO ObtenerPorId(int id)
    {
        CursoDTO curso = null;
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Cursos WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                curso = new CursoDTO
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Creditos = Convert.ToInt32(reader["Creditos"]),
                    ProgramaId = Convert.ToInt32(reader["ProgramaId"])
                };
            }
        }
        return curso;
    }

    public void Agregar(CursoDTO cursoDTO)
    {
        Curso curso = cursoFactory.CrearCurso(cursoDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO Cursos (Nombre, Creditos, ProgramaId) VALUES (@Nombre, @Creditos, @ProgramaId)";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", curso.Nombre);
            command.Parameters.AddWithValue("@Creditos", curso.Creditos);
            command.Parameters.AddWithValue("@ProgramaId", curso.ProgramaId);
            command.ExecuteNonQuery();
        }
    }

    public void Actualizar(CursoDTO cursoDTO)
    {
        Curso curso = cursoFactory.CrearCurso(cursoDTO);

        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "UPDATE Cursos SET Nombre = @Nombre, Creditos = @Creditos, ProgramaId = @ProgramaId WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", curso.Nombre);
            command.Parameters.AddWithValue("@Creditos", curso.Creditos);
            command.Parameters.AddWithValue("@ProgramaId", curso.ProgramaId);
            command.Parameters.AddWithValue("@Id", curso.Id);
            command.ExecuteNonQuery();
        }
    }

    public void Eliminar(int id)
    {
        using (var connection = dbContext.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM Cursos WHERE Id = @Id";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
