using Fachada;
using SistemaClientes;

namespace Controladores
{
    public class ClientesController
    {
        private readonly SistemaFachada sistemaFachada;

        public ClientesController()
        {
            sistemaFachada = new SistemaFachada();
        }

        public void CrearCliente(ClienteDTO clienteDTO)
        {
            sistemaFachada.CrearCliente(clienteDTO);
            Console.WriteLine("Cliente creado exitosamente.");
        }

        public void ActualizarCliente(ClienteDTO clienteDTO)
        {
            sistemaFachada.ActualizarCliente(clienteDTO);
            Console.WriteLine("Cliente actualizado exitosamente.");
        }

        public void EliminarCliente(int id)
        {
            sistemaFachada.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }

        public List<ClienteDTO> MostrarTodosLosClientes()
        {
            var clientes = sistemaFachada.MostrarTodosLosClientes();

            if (clientes == null || clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes disponibles.");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Documento: {cliente.Documento}, Correo: {cliente.CorreoElectronico}, Teléfono: {cliente.Telefono}");
                }
            }

            return clientes;
        }


        public ClienteDTO MostrarClientePorId(int id)
        {
            var cliente = sistemaFachada.MostrarClientePorId(id);
            if (cliente != null)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Documento: {cliente.Documento}, Correo: {cliente.CorreoElectronico}, Teléfono: {cliente.Telefono}");
                return cliente;
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
                return null;
            }
        }
    }


}
