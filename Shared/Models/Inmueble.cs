using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Inmueble
{
    public byte IdInmueble { get; set; }

    public byte IdTipoInmueble { get; set; }

    public string DescInmueble { get; set; } = null!;

    public string UbicInmueble { get; set; } = null!;

    public decimal CostoInmueble { get; set; }

}
