
namespace SistemaClientes
{
    using System.Collections.Generic;

    public class ClientesServicio
    {
        private readonly ClientesRepository clientesRepository;

        public ClientesServicio()
        {
            ClientesFactory fabrica = new ClientesFactory();
            this.clientesRepository = new ClientesRepository();
        }

        public List<ClienteDTO> ObtenerTodos()
        {
            List<Cliente> clientes = clientesRepository.ObtenerTodos();
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();

            foreach (var cliente in clientes)
            {
                clientesDTO.Add(new ClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Documento = cliente.Documento,
                    CorreoElectronico = cliente.CorreoElectronico,
                    Telefono = cliente.Telefono
                });
            }

            return clientesDTO;
        }

        public ClienteDTO ObtenerPorId(int id)
        {
            Cliente cliente = clientesRepository.ObtenerPorId(id);
            if (cliente != null)
            {
                return new ClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Documento = cliente.Documento,
                    CorreoElectronico = cliente.CorreoElectronico,
                    Telefono = cliente.Telefono
                };
            }
            return null;
        }

        public void AgregarCliente(ClienteDTO clienteDTO)
        {
            ClientesFactory clientesFactory = new ClientesFactory();
            Cliente nuevoCliente = clientesFactory.CrearCliente(clienteDTO);
            clientesRepository.Agregar(nuevoCliente);
        }

        public void ActualizarCliente(ClienteDTO clienteDTO)
        {
            Cliente clienteExistente = clientesRepository.ObtenerPorId(clienteDTO.Id);
            if (clienteExistente != null)
            {
                ClientesFactory clientesFactory = new ClientesFactory();
                Cliente clienteActualizado = clientesFactory.CrearCliente(clienteDTO);
                clientesRepository.Actualizar(clienteActualizado);
            }
        }

        public void EliminarCliente(int id)
        {
            clientesRepository.Eliminar(id);
        }
    }

}
