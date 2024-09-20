using GestorDocumentos;
using SistemaClientes;

namespace Fachada
{
    public class SistemaFachada
    {
        private ClientesServicio clientesServicio;
        private ServiciosDocumentos gestorDocumentos;

        public SistemaFachada()
        {
            clientesServicio = new ClientesServicio();
            gestorDocumentos = new ServiciosDocumentos();
        }

        // Métodos relacionados con el sistema de clientes
        public void CrearCliente(ClienteDTO clienteDTO)
        {
            clientesServicio.AgregarCliente(clienteDTO);
            Console.WriteLine("Cliente creado exitosamente.");
        }

        public void ActualizarCliente(ClienteDTO clienteDTO)
        {
            clientesServicio.ActualizarCliente(clienteDTO);
            Console.WriteLine("Cliente actualizado exitosamente.");
        }

        public void EliminarCliente(int id)
        {
            clientesServicio.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }

        public List<ClienteDTO> MostrarTodosLosClientes()
        {
            return clientesServicio.ObtenerTodos();
            
        }

        public void ImprimirDocumento(string nombreDocumento)
        {
            gestorDocumentos.ImprimirDocumento(nombreDocumento);
        }

        public void GuardarDocumento(string nombreDocumento)
        {
            gestorDocumentos.GuardarDocumento(nombreDocumento);
        }

        public void EnviarDocumentoPorCorreo(string nombreDocumento, string destinatario)
        {
            gestorDocumentos.EnviarDocumentoPorCorreo(nombreDocumento, destinatario);
        }

        public ClienteDTO MostrarClientePorId(int id)
        {
            return clientesServicio.ObtenerPorId(id);
        }
    }

}
