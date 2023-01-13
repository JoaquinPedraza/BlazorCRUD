
using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.ClienteServices
{
    public interface IClienteServices
    {
        List<Cliente> Clientes { get; set; }
        Task GetClientes();

        Task<Cliente> GetCliente(byte id);

        Task PostCliente(Cliente cliente);

        Task PutCliente(byte id, Cliente cliente);

        Task DeleteCliente(byte id);
    }
}
