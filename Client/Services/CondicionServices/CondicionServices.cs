using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.CondicionServices
{
    public class CondicionServices : ICondicionServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CondicionServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Condicion> Condiciones { get; set ; } = new List<Condicion>();

        public async Task DeleteCondicion(byte id)
        {
            await _http.DeleteAsync($"api/Condiciones/{id}");
            _navigationManager.NavigateTo("/Condiciones");
        }

        public async Task<Condicion> GetCondicion(byte id)
        {
            var response = await _http.GetFromJsonAsync<Condicion>($"api/Condiciones/{id}");
            if (response != null)
            {
                return response;
            }
            throw new Exception("Condicion no encontrada");
        }

        public async Task GetCondiciones()
        {
            var response = await _http.GetFromJsonAsync<List<Condicion>>("api/Condiciones");
            if (response != null)
            {
                Condiciones = response;
            }
        }

        public async Task PostCondicion(Condicion condicion)
        {
            await _http.PostAsJsonAsync<Condicion>("api/Condiciones", condicion);
            _navigationManager.NavigateTo("/Condiciones");
        }

        public async Task PutCondicion(byte id, Condicion condicion)
        {
            await _http.PutAsJsonAsync<Condicion>($"api/Condiciones/{id}", condicion);
            _navigationManager.NavigateTo("/Condiciones");
        }
    }
}
