using DTO;
using FabricaObjetosRepository;

namespace Controladores
{
    public class EstudianteController
    {
        private readonly EstudianteServicio estudianteServicio;

        public EstudianteController()
        {
            var fabricaRepository = new EstudianteRepositoryFactory();
            estudianteServicio = new EstudianteServicio(fabricaRepository);
        }

        public void CrearEstudiante(EstudianteDTO estudianteDTO)
        {
            estudianteServicio.AgregarEstudiante(estudianteDTO);
            Console.WriteLine("Estudiante creado exitosamente.");
        }

        public void ActualizarEstudiante(EstudianteDTO estudianteDTO)
        {
            estudianteServicio.ActualizarEstudiante(estudianteDTO);
            Console.WriteLine("Estudiante actualizado exitosamente.");
        }

        public void EliminarEstudiante(int id)
        {
            estudianteServicio.EliminarEstudiante(id);
            Console.WriteLine("Estudiante eliminado exitosamente.");
        }

        public List<EstudianteDTO> MostrarTodosLosEstudiantes()
        {
            var estudiantes = estudianteServicio.ObtenerTodos();
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"{estudiante.Id} - {estudiante.Nombre} - {estudiante.Documento}");
            }
            return estudiantes;
        }

        public EstudianteDTO MostrarEstudiantePorId(int id)
        {
            var estudiante = estudianteServicio.ObtenerPorId(id);
            if (estudiante != null)
            {
                Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}, Documento: {estudiante.Documento}");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
            return estudiante;
        }
    }

}
