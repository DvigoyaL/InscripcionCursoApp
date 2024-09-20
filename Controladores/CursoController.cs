using DTO;
using Entidades;
using FabricaObjetosRepository;

namespace Controladores
{
    public class CursoController
    {
        private readonly CursoServicio cursoServicio;

        public CursoController()
        {
            var fabricaRepository = new CursoRepositoryFactory();
            cursoServicio = new CursoServicio(fabricaRepository);
        }

        public void CrearCurso(CursoDTO cursoDTO)
        {
            cursoServicio.AgregarCurso(cursoDTO);
            Console.WriteLine("Curso creado exitosamente.");
        }

        public void ActualizarCurso(CursoDTO cursoDTO)
        {
            cursoServicio.ActualizarCurso(cursoDTO);
            Console.WriteLine("Curso actualizado exitosamente.");
        }

        public void EliminarCurso(int id)
        {
            cursoServicio.EliminarCurso(id);
            Console.WriteLine("Curso eliminado exitosamente.");
        }

        public List<CursoDTO> MostrarTodosLosCursos()
        {
            var cursos = cursoServicio.ObtenerTodos();
            foreach (var curso in cursos)
            {
                Console.WriteLine($"{curso.Id} - {curso.Nombre} - {curso.Creditos} créditos");
            }
            return cursos;
        }

        public CursoDTO MostrarCursoPorId(int id)
        {
            var curso = cursoServicio.ObtenerPorId(id);
            if (curso != null)
            {
                Console.WriteLine($"ID: {curso.Id}, Nombre: {curso.Nombre}, Créditos: {curso.Creditos}");
                return curso;
            }
            else
            {
                Console.WriteLine("Curso no encontrado.");
                return null;
            }
        }
    }


}
