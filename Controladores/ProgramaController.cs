using DTO;
using FabricaObjetosRepository;
using LogicaNegocio;

namespace Controladores
{
    public class ProgramaController
    {
        private readonly ProgramaServicio programaServicio;

        public ProgramaController()
        {
            var fabricaRepository = new ProgramaRepositoryFactory();
            programaServicio = new ProgramaServicio(fabricaRepository);
        }

        public void CrearPrograma(ProgramaDTO programaDTO)
        {
            programaServicio.AgregarPrograma(programaDTO);
            Console.WriteLine("Programa creado exitosamente.");
        }

        public void ActualizarPrograma(ProgramaDTO programaDTO)
        {
            programaServicio.ActualizarPrograma(programaDTO);
            Console.WriteLine("Programa actualizado exitosamente.");
        }

        public void EliminarPrograma(int id)
        {
            programaServicio.EliminarPrograma(id);
            Console.WriteLine("Programa eliminado exitosamente.");
        }

        public List<ProgramaDTO> MostrarTodosLosProgramas()
        {
            var programas = programaServicio.ObtenerTodos();
            foreach (var programa in programas)
            {
                Console.WriteLine($"{programa.Id} - {programa.Nombre}");
            }
            return programas;
        }

        public ProgramaDTO MostrarProgramaPorId(int id)
        {
            var programa = programaServicio.ObtenerPorId(id);
            if (programa != null)
            {
                Console.WriteLine($"ID: {programa.Id}, Nombre: {programa.Nombre}, Descripción: {programa.Descripcion}");
            }
            else
            {
                Console.WriteLine("Programa no encontrado.");
            }
            return programa;
        }
    }

}
