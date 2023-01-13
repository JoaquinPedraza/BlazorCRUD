using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.FormaPagoServices
{
    public class FormaPagoServices : IFormaPagoServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public FormaPagoServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<FormaPago> FormasPago { get; set; } = new List<FormaPago>();

        public async Task DeleteFormaPago(byte id)
        {
            await _http.DeleteAsync($"api/FormasPago/{id}");
            _navigationManager.NavigateTo("/FormasPago");
        }

        public async Task<FormaPago> GetFormaPago(byte id)
        {
            var result = await _http.GetFromJsonAsync<FormaPago>($"api/FormasPago/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Condicion no encontrada");
        }

        public async Task GetFormasPago()
        {
            var result = await _http.GetFromJsonAsync<List<FormaPago>>("api/FormasPago");
            if (result != null)
            {
                FormasPago =  result;
            }
        }

        public async Task PostFormaPago(FormaPago formaPago)
        {
            await _http.PostAsJsonAsync("api/FormasPago", formaPago);
            _navigationManager.NavigateTo("/FormasPago");
        }

        public async Task PutFormaPago(byte id, FormaPago formaPago)
        {
            await _http.PutAsJsonAsync($"api/FormasPago/{id}", formaPago);
            _navigationManager.NavigateTo("/FormasPago");
        }
    }
}
