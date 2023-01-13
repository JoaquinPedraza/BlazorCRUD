using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.FormaPagoServices
{
    public interface IFormaPagoServices
    {
        List<FormaPago> FormasPago { get; set; }
        Task GetFormasPago();
        Task <FormaPago> GetFormaPago(byte id);
        Task PutFormaPago(byte id, FormaPago formaPago);
        Task DeleteFormaPago(byte id);
        Task PostFormaPago(FormaPago formaPago);
    }
}
