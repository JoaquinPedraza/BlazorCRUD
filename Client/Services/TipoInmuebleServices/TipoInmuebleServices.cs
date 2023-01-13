using BlazorCRUD.Client.Pages.Condiciones;
using BlazorCRUD.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.TipoInmuebleServices
{
    public class TipoInmuebleServices : ITipoInmuebleServices
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TipoInmuebleServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<TipoInmueble> TiposInmueble { get ; set ; } = new List<TipoInmueble>();

        public async Task DeleteTipoInmueble(byte id)
        {
            await _http.DeleteAsync($"api/TiposInmuebles/{id}");
            _navigationManager.NavigateTo("/TiposInmueble");
        }

        public async Task<TipoInmueble> GetTipoInmueble(byte id)
        {
            var response = await _http.GetFromJsonAsync<TipoInmueble>($"api/TiposInmuebles/{id}");
            if (response != null)
            {
                return response;
            }
            throw new Exception("Tipo de Inmueble no encontrado");
        }

        public async Task GetTiposInmueble()
        {
            var response = await _http.GetFromJsonAsync<List<TipoInmueble>>("api/TiposInmuebles");
            if (response != null)
            {
                TiposInmueble = response;
            }
        }

        public async Task PostTipoInmueble(TipoInmueble tipoInmueble)
        {
            await _http.PostAsJsonAsync<TipoInmueble>("api/TiposInmuebles", tipoInmueble);
            _navigationManager.NavigateTo("/TiposInmueble");
        }

        public async Task PutTipoInmueble(byte id, TipoInmueble tipoInmueble)
        {
            await _http.PutAsJsonAsync<TipoInmueble>($"api/TiposInmuebles/{id}", tipoInmueble);
            _navigationManager.NavigateTo("/TiposInmueble");

        }
    }
}
