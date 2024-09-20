using VistaConsola;

namespace ComponenteInicio
{
    static class Program
    {
        static void Main()
        {
             // Ejecutar la vista de consola
            IniciarConsola();
        }

        static void IniciarConsola()
        {
            VistaConsole consola = new VistaConsole();
            consola.IniciarMenu();
        }
    }
}

