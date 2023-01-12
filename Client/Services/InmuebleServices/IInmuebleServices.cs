using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.InmuebleServices
{
    public interface IInmuebleServices
    {
        List<Inmueble> Inmuebles { get; set; }
        List<TipoInmueble> TipoInmuebles { get; set; }
        Task GetTipoInmuebles();
        Task GetInmuebles();
        Task<Inmueble> GetInmueble(byte id);
        Task PostInmueble(Inmueble inmueble);

        Task PutInmueble(byte id, Inmueble inmueble);

        Task DeleteInmueble(byte id);
    }
}
