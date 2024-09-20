using DTO;
using Entidades;

public class ProgramaFactory
{
    public Programa CrearPrograma(ProgramaDTO programaDTO)
    {
        return new Programa
        {
            Id = programaDTO.Id,
            Nombre = programaDTO.Nombre,
            Descripcion = programaDTO.Descripcion
        };
    }
}
