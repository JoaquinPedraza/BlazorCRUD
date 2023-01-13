using BlazorCRUD.Client.Pages.Clientes;
using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.VentaServices
{
    public class VentaServices : IVentaServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public VentaServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Venta> Ventas { get ; set ; } = new List<Venta>();
        public List<Cliente> Clientes { get ; set ; } = new List<Cliente>();
        public List<Inmueble> Inmuebles { get ; set ; } = new List<Inmueble>();
        public List<FormaPago> FormasPago { get ; set ; } = new List<FormaPago>();
        public List<Condicion> Condiciones { get ; set ; } = new List<Condicion>();

        public async Task DeleteVenta(byte id)
        {
            await _http.DeleteAsync($"api/Ventas/{id}");
            _navigationManager.NavigateTo("/Ventas");
        }

        public async Task<Venta> GetVenta(byte id)
        {
            var result = await _http.GetFromJsonAsync<Venta>($"api/Ventas/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Venta no encontrada");
        }

        public async Task GetVentas()
        {
            var result = await _http.GetFromJsonAsync<List<Venta>>("api/Ventas");
            if (result != null)
            {
                Ventas = result;
            }
        }
        public async Task GetInmuebles()
        {
            var result = await _http.GetFromJsonAsync<List<Inmueble>>("api/Inmuebles");
            if (result != null)
            {
                Inmuebles = result;
            }
        }
        public async Task GetClientes()
        {
            var result = await _http.GetFromJsonAsync<List<Cliente>>("api/Clientes");
            if (result != null)
            {
                Clientes = result;
            }
        }
        public async Task GetCondiciones()
        {
            var result = await _http.GetFromJsonAsync<List<Condicion>>("api/Condiciones");
            if (result != null)
            {
                Condiciones = result;
            }
        }
        public async Task GetFormasPago()
        {
            var result = await _http.GetFromJsonAsync<List<FormaPago>>("api/FormasPago");
            if (result != null)
            {
                FormasPago = result;
            }
        }
        public async Task PostVenta(Venta venta)
        {
            await _http.PostAsJsonAsync("api/Ventas", venta);
            _navigationManager.NavigateTo("/Ventas");
        }

        public async Task PutVenta(byte id, Venta venta)
        {
            await _http.PutAsJsonAsync($"api/Ventas/{id}", venta);
            _navigationManager.NavigateTo("/Ventas");
        }
    }
}
