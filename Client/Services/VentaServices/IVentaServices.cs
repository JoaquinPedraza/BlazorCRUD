using BlazorCRUD.Server.Models;

namespace BlazorCRUD.Client.Services.VentaServices
{
    public interface IVentaServices
    {
        List<Venta> Ventas { get; set; }
        List<Inmueble> Inmuebles { get; set; }
        List<Cliente> Clientes { get; set; }
        List<Condicion> Condiciones { get; set; }
        List<FormaPago> FormasPago { get; set; }
        Task GetVentas();
        Task GetInmuebles();
        Task GetClientes();
        Task GetCondiciones();
        Task GetFormasPago();
        Task<Venta> GetVenta(byte id);
        Task PostVenta(Venta venta);
        Task PutVenta(byte id, Venta venta);
        Task DeleteVenta(byte id);
    }
}
