namespace VistaConsola
{
    using Controladores;
    using DTO;
    using SistemaClientes;
    using System;

    public class VistaConsole
    {
        private readonly ClientesController clientesController;
        private readonly CursoController cursoController;
        private readonly EstudianteController estudianteController;
        private readonly ProgramaController programaController;
        private readonly DocumentosController documentosController;

        public VistaConsole()
        {
            clientesController = new ClientesController();
            cursoController = new CursoController();
            estudianteController = new EstudianteController();
            programaController = new ProgramaController();
            documentosController = new DocumentosController();
        }

        public void IniciarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu Principal =====");
                Console.WriteLine("1. Gestionar Clientes");
                Console.WriteLine("2. Gestionar Cursos");
                Console.WriteLine("3. Gestionar Estudiantes");
                Console.WriteLine("4. Gestionar Programas");
                Console.WriteLine("5. Gestionar Documentos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuCursos();
                        break;
                    case 3:
                        MenuEstudiantes();
                        break;
                    case 4:
                        MenuProgramas();
                        break;
                    case 5:
                        MenuDocumentos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }

        private void MenuClientes()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Clientes ===");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Actualizar Cliente");
            Console.WriteLine("3. Eliminar Cliente");
            Console.WriteLine("4. Mostrar Todos los Clientes");
            Console.WriteLine("5. Mostrar Cliente por ID");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearCliente();
                    break;
                case 2:
                    ActualizarCliente();
                    break;
                case 3:
                    EliminarCliente();
                    break;
                case 4:
                    MostrarTodosLosClientes();
                    break;
                case 5:
                    MostrarClientePorId();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void CrearCliente()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el documento del cliente: ");
            string documento = Console.ReadLine();
            Console.Write("Ingrese el correo del cliente: ");
            string correo = Console.ReadLine();
            Console.Write("Ingrese el teléfono del cliente: ");
            string telefono = Console.ReadLine();

            ClienteDTO nuevoCliente = new ClienteDTO { Nombre = nombre, Documento = documento, CorreoElectronico = correo, Telefono = telefono };
            clientesController.CrearCliente(nuevoCliente);
        }

        private void ActualizarCliente()
        {
            Console.Write("Ingrese el ID del cliente a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el nuevo documento del cliente: ");
            string documento = Console.ReadLine();
            Console.Write("Ingrese el nuevo correo del cliente: ");
            string correo = Console.ReadLine();
            Console.Write("Ingrese el nuevo teléfono del cliente: ");
            string telefono = Console.ReadLine();

            ClienteDTO clienteActualizado = new ClienteDTO { Id = id, Nombre = nombre, Documento = documento, CorreoElectronico = correo, Telefono = telefono };
            clientesController.ActualizarCliente(clienteActualizado);
        }

        private void EliminarCliente()
        {
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            clientesController.EliminarCliente(id);
        }

        private void MostrarTodosLosClientes()
        {
            clientesController.MostrarTodosLosClientes();
        }

        private void MostrarClientePorId()
        {
            Console.Write("Ingrese el ID del cliente a mostrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            clientesController.MostrarClientePorId(id);
        }

        private void MenuCursos()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Cursos ===");
            Console.WriteLine("1. Crear Curso");
            Console.WriteLine("2. Actualizar Curso");
            Console.WriteLine("3. Eliminar Curso");
            Console.WriteLine("4. Mostrar Todos los Cursos");
            Console.WriteLine("5. Mostrar Curso por ID");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearCurso();
                    break;
                case 2:
                    ActualizarCurso();
                    break;
                case 3:
                    EliminarCurso();
                    break;
                case 4:
                    MostrarTodosLosCursos();
                    break;
                case 5:
                    MostrarCursoPorId();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void CrearCurso()
        {
            Console.Write("Ingrese el nombre del curso: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese los créditos del curso: ");
            int creditos = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el ID del programa asociado: ");
            int programaId = Convert.ToInt32(Console.ReadLine());

            CursoDTO nuevoCurso = new CursoDTO { Nombre = nombre, Creditos = creditos, ProgramaId = programaId };
            cursoController.CrearCurso(nuevoCurso);
        }

        private void ActualizarCurso()
        {
            Console.Write("Ingrese el ID del curso a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo nombre del curso: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese los nuevos créditos del curso: ");
            int creditos = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo ID del programa asociado: ");
            int programaId = Convert.ToInt32(Console.ReadLine());

            CursoDTO cursoActualizado = new CursoDTO { Id = id, Nombre = nombre, Creditos = creditos, ProgramaId = programaId };
            cursoController.ActualizarCurso(cursoActualizado);
        }

        private void EliminarCurso()
        {
            Console.Write("Ingrese el ID del curso a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            cursoController.EliminarCurso(id);
        }

        private void MostrarTodosLosCursos()
        {
            cursoController.MostrarTodosLosCursos();
        }

        private void MostrarCursoPorId()
        {
            Console.Write("Ingrese el ID del curso a mostrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            cursoController.MostrarCursoPorId(id);
        }

        private void MenuEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Estudiantes ===");
            Console.WriteLine("1. Crear Estudiante");
            Console.WriteLine("2. Actualizar Estudiante");
            Console.WriteLine("3. Eliminar Estudiante");
            Console.WriteLine("4. Mostrar Todos los Estudiantes");
            Console.WriteLine("5. Mostrar Estudiante por ID");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearEstudiante();
                    break;
                case 2:
                    ActualizarEstudiante();
                    break;
                case 3:
                    EliminarEstudiante();
                    break;
                case 4:
                    MostrarTodosLosEstudiantes();
                    break;
                case 5:
                    MostrarEstudiantePorId();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void CrearEstudiante()
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el documento del estudiante: ");
            string documento = Console.ReadLine();
            Console.Write("Ingrese el ID del programa asociado: ");
            int programaId = Convert.ToInt32(Console.ReadLine());

            EstudianteDTO nuevoEstudiante = new EstudianteDTO { Nombre = nombre, Documento = documento, ProgramaId = programaId };
            estudianteController.CrearEstudiante(nuevoEstudiante);
        }

        private void ActualizarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el nuevo documento del estudiante: ");
            string documento = Console.ReadLine();
            Console.Write("Ingrese el nuevo ID del programa asociado: ");
            int programaId = Convert.ToInt32(Console.ReadLine());

            EstudianteDTO estudianteActualizado = new EstudianteDTO { Id = id, Nombre = nombre, Documento = documento, ProgramaId = programaId };
            estudianteController.ActualizarEstudiante(estudianteActualizado);
        }

        private void EliminarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            estudianteController.EliminarEstudiante(id);
        }

        private void MostrarTodosLosEstudiantes()
        {
            estudianteController.MostrarTodosLosEstudiantes();
        }

        private void MostrarEstudiantePorId()
        {
            Console.Write("Ingrese el ID del estudiante a mostrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            estudianteController.MostrarEstudiantePorId(id);
        }

        private void MenuProgramas()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Programas ===");
            Console.WriteLine("1. Crear Programa");
            Console.WriteLine("2. Actualizar Programa");
            Console.WriteLine("3. Eliminar Programa");
            Console.WriteLine("4. Mostrar Todos los Programas");
            Console.WriteLine("5. Mostrar Programa por ID");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearPrograma();
                    break;
                case 2:
                    ActualizarPrograma();
                    break;
                case 3:
                    EliminarPrograma();
                    break;
                case 4:
                    MostrarTodosLosProgramas();
                    break;
                case 5:
                    MostrarProgramaPorId();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void CrearPrograma()
        {
            Console.Write("Ingrese el nombre del programa: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la descripción del programa: ");
            string descripcion = Console.ReadLine();

            ProgramaDTO nuevoPrograma = new ProgramaDTO { Nombre = nombre, Descripcion = descripcion };
            programaController.CrearPrograma(nuevoPrograma);
        }

        private void ActualizarPrograma()
        {
            Console.Write("Ingrese el ID del programa a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo nombre del programa: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la nueva descripción del programa: ");
            string descripcion = Console.ReadLine();

            ProgramaDTO programaActualizado = new ProgramaDTO { Id = id, Nombre = nombre, Descripcion = descripcion };
            programaController.ActualizarPrograma(programaActualizado);
        }

        private void EliminarPrograma()
        {
            Console.Write("Ingrese el ID del programa a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            programaController.EliminarPrograma(id);
        }

        private void MostrarTodosLosProgramas()
        {
            programaController.MostrarTodosLosProgramas();
        }

        private void MostrarProgramaPorId()
        {
            Console.Write("Ingrese el ID del programa a mostrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            programaController.MostrarProgramaPorId(id);
        }

        private void MenuDocumentos()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Documentos ===");
            Console.WriteLine("1. Imprimir Documento");
            Console.WriteLine("2. Guardar Documento");
            Console.WriteLine("3. Enviar Documento por Correo");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ImprimirDocumento();
                    break;
                case 2:
                    GuardarDocumento();
                    break;
                case 3:
                    EnviarDocumentoPorCorreo();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void ImprimirDocumento()
        {
            Console.Write("Ingrese el nombre del documento: ");
            string nombre = Console.ReadLine();
            documentosController.ImprimirDocumento(nombre);
        }

        private void GuardarDocumento()
        {
            Console.Write("Ingrese el nombre del documento: ");
            string nombre = Console.ReadLine();
            documentosController.GuardarDocumento(nombre);
        }

        private void EnviarDocumentoPorCorreo()
        {
            Console.Write("Ingrese el nombre del documento: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el correo del destinatario: ");
            string correo = Console.ReadLine();

            documentosController.EnviarDocumentoPorCorreo(nombre, correo);
        }
    }

}
