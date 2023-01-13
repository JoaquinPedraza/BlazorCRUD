using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.TipoInmuebleServices
{
    public interface ITipoInmuebleServices
    {
        List<TipoInmueble> TiposInmueble { get; set; }
        Task GetTiposInmueble();
        Task<TipoInmueble> GetTipoInmueble(byte id);
        Task PostTipoInmueble(TipoInmueble tipoInmueble);
        Task PutTipoInmueble(byte id, TipoInmueble tipoInmueble);
        Task DeleteTipoInmueble(byte id);
    }
}
