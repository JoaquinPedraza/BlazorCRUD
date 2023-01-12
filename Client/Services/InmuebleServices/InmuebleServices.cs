
using BlazorCRUD.Client.Pages;
using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.InmuebleServices
{
    public class InmuebleServices : IInmuebleServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public InmuebleServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
        public List<TipoInmueble> TipoInmuebles { get; set; } = new List<TipoInmueble>();

        public async Task DeleteInmueble(byte id)
        {
            var result = await _http.DeleteAsync($"api/Inmuebles/{id}");
            await SetInmuebles(result);
        }

        private async Task SetInmuebles(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Inmueble>>();
            Inmuebles = response;
            _navigationManager.NavigateTo("/Inmueble");

        }

        public async Task<Inmueble> GetInmueble(byte id)
        {
            var result = await _http.GetFromJsonAsync<Inmueble>($"api/Inmuebles/{id}");
            if (result != null)
            {
                return result;
            } throw new Exception("Inmueble no encontrado");

        }

        public async Task GetInmuebles()
        {
            var result = await _http.GetFromJsonAsync<List<Inmueble>>("api/Inmuebles");
            if (result != null)
            {
                Inmuebles = result;
            }
        }

        public async Task GetTipoInmuebles()
        {
            var result = await _http.GetFromJsonAsync<List<TipoInmueble>>("api/TiposInmuebles");
            if (result != null)
            {
                TipoInmuebles = result;
            }
        }

        public async Task PostInmueble(Inmueble inmueble)
        {
            var result = await _http.PostAsJsonAsync("api/Inmuebles", inmueble);
            await SetInmuebles(result);
        }

        public async Task PutInmueble(byte Id, Inmueble inmueble)
        {
            var result = await _http.PostAsJsonAsync($"api/Inmuebles/{inmueble.IdInmueble}", inmueble);
            await SetInmuebles(result);
        }
    }
}
