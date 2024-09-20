namespace SistemaClientes
{
    public class ClientesFactory
    {
        public Cliente CrearCliente(ClienteDTO clienteDTO)
        {
            return new Cliente
            {
                Id = clienteDTO.Id,
                Nombre = clienteDTO.Nombre,
                Documento = clienteDTO.Documento,
                CorreoElectronico = clienteDTO.CorreoElectronico,
                Telefono = clienteDTO.Telefono
            };
        }
    }

}
