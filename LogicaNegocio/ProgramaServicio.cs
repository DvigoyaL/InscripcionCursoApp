using DTO;
using Entidades;
using FabricaObjetosRepository;
using System.Collections.Generic;

namespace LogicaNegocio
{
    
    public class ProgramaServicio
    {
        private readonly ProgramaRepository programaRepository;

        public ProgramaServicio(IFabricaRepository<ProgramaRepository> fabricaRepository)
        {
            this.programaRepository = fabricaRepository.CrearRepository();
        }

        public List<ProgramaDTO> ObtenerTodos()
        {
            return programaRepository.ObtenerTodos();
        }

        public ProgramaDTO ObtenerPorId(int id)
        {
            return programaRepository.ObtenerPorId(id);
        }

        public void AgregarPrograma(ProgramaDTO programaDTO)
        {
            programaRepository.Agregar(programaDTO);
        }

        public void ActualizarPrograma(ProgramaDTO programaDTO)
        {
            ProgramaDTO programaExistente = programaRepository.ObtenerPorId(programaDTO.Id);
            if (programaExistente != null)
            {
                programaRepository.Actualizar(programaDTO);
            }
        }

        public void EliminarPrograma(int id)
        {
            programaRepository.Eliminar(id);
        }
    }

}
