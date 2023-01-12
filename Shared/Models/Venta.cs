using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Venta
{
    public byte IdVenta { get; set; }

    public byte IdInmueble { get; set; }

    public byte IdCliente { get; set; }

    public byte IdCondicion { get; set; }

    public byte IdFormaPago { get; set; }

    public string DescVenta { get; set; } = null!;

    public decimal TotalVenta { get; set; }

    public decimal TotalIva { get; set; }

    public decimal TotalGeneral { get; set; }

    public DateTime FechaVenta { get; set; }

}
