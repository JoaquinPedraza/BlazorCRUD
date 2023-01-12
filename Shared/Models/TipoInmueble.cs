using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class TipoInmueble
{
    public byte IdTipoInmueble { get; set; }

    public string DescInmueble { get; set; } = null!;

}
