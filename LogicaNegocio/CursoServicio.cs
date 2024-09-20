using DTO;
using FabricaObjetosRepository;
using System.Collections.Generic;

public class CursoServicio
{
    private readonly CursoRepository cursoRepository;

    public CursoServicio(IFabricaRepository<CursoRepository> fabricaRepository)
    {
        // Usar la fábrica para crear el repositorio
        this.cursoRepository = fabricaRepository.CrearRepository();
    }

    public List<CursoDTO> ObtenerTodos()
    {
        return cursoRepository.ObtenerTodos();
    }

    public CursoDTO ObtenerPorId(int id)
    {
        return cursoRepository.ObtenerPorId(id);
    }

    public void AgregarCurso(CursoDTO cursoDTO)
    {
        cursoRepository.Agregar(cursoDTO);
    }

    public void ActualizarCurso(CursoDTO cursoDTO)
    {
        CursoDTO cursoExistente = cursoRepository.ObtenerPorId(cursoDTO.Id);
        if (cursoExistente != null)
        {
            cursoRepository.Actualizar(cursoDTO);
        }
    }

    public void EliminarCurso(int id)
    {
        cursoRepository.Eliminar(id);
    }
}
