using System;
using System.Threading;
/*using System.Windows.Forms;
using VistaEscritorio;*/
using VistaConsola;

namespace ComponenteInicio
{


    namespace ComponenteInicio
    {
        static class Program
        {
            [STAThread]
            /*static void Main()
            {
                // Crear e iniciar el hilo para la interfaz de consola
                Thread consolaThread = new Thread(IniciarConsola);
                consolaThread.Start();

                // Ejecutar la interfaz de escritorio en el hilo principal
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain()); // Cambia FormMain por el formulario principal de la VistaEscritorio

                // Esperar a que el hilo de consola termine (opcional)
                consolaThread.Join();
            }*/

            static void IniciarConsola()
            {
                VistaConsole consola = new VistaConsole();
                consola.IniciarMenu();
            }
        }
    }

}
