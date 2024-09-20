using DTO;
using Entidades;

public class CursoFactory
{
    public Curso CrearCurso(CursoDTO cursoDTO)
    {
        return new Curso
        {
            Id = cursoDTO.Id,
            Nombre = cursoDTO.Nombre,
            Creditos = cursoDTO.Creditos,
            ProgramaId = cursoDTO.ProgramaId
        };
    }
}

