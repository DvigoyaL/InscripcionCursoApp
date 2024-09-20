using DTO;
using Entidades;

public class EstudianteFactory
{
    public Estudiante CrearEstudiante(EstudianteDTO estudianteDTO)
    {
        return new Estudiante
        {
            Id = estudianteDTO.Id,
            Nombre = estudianteDTO.Nombre,
            Documento = estudianteDTO.Documento,
            ProgramaId = estudianteDTO.ProgramaId
        };
    }
}

