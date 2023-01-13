using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.CondicionServices
{
    public interface ICondicionServices
    {
        List<Condicion> Condiciones { get; set; }
        Task GetCondiciones();
        Task<Condicion> GetCondicion(byte id);
        Task PostCondicion(Condicion condicion);
        Task PutCondicion(byte id, Condicion condicion);
        Task DeleteCondicion(byte id);
    }
}
