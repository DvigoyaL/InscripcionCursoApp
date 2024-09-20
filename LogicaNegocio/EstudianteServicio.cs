using DTO;
using Entidades;
using FabricaObjetosRepository;
using System.Collections.Generic;

public class EstudianteServicio
{
    private readonly EstudianteRepository estudianteRepository;

    public EstudianteServicio(IFabricaRepository<EstudianteRepository> fabricaRepository)
    {
        // Usar la fábrica para crear el repositorio
        this.estudianteRepository = fabricaRepository.CrearRepository();
    }

    public List<EstudianteDTO> ObtenerTodos()
    {
        return estudianteRepository.ObtenerTodos();
    }

    public EstudianteDTO ObtenerPorId(int id)
    {
        return estudianteRepository.ObtenerPorId(id);
    }

    public void AgregarEstudiante(EstudianteDTO estudianteDTO)
    {
        estudianteRepository.Agregar(estudianteDTO);
    }

    public void ActualizarEstudiante(EstudianteDTO estudianteDTO)
    {
        EstudianteDTO estudianteExistente = estudianteRepository.ObtenerPorId(estudianteDTO.Id);
        if (estudianteExistente != null)
        {
            estudianteRepository.Actualizar(estudianteDTO);
        }
    }

    public void EliminarEstudiante(int id)
    {
        estudianteRepository.Eliminar(id);
    }
}
