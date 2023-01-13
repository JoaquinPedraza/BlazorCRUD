using BlazorCRUD.Client.Pages;
using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.ClienteServices
{
    public class ClienteServices : IClienteServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ClienteServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Cliente> Clientes { get ; set; } = new List<Cliente>();

        public async Task DeleteCliente(byte id)
        {
            var result = await _http.DeleteAsync($"api/Clientes/{id}");

        }

        public async Task<Cliente> GetCliente(byte id)
        {
            var result = await _http.GetFromJsonAsync<Cliente>($"api/Clientes/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Cliente no encontrado");
        }

        public async Task GetClientes()
        {
            var result = await _http.GetFromJsonAsync<List<Cliente>>("api/Clientes");
            if (result != null)
            {
                Clientes = result;
            }
        }

        public async Task PostCliente(Cliente cliente)
        {
            var result = await _http.PostAsJsonAsync("api/Clientes", cliente);

        }

        public async Task PutCliente(byte id, Cliente cliente)
        {
            var result = await _http.PutAsJsonAsync($"api/Clientes/{id}", cliente);

        }
    }
}
