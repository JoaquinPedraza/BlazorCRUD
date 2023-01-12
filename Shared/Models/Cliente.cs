using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Cliente
{
    public byte IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string DirCliente { get; set; } = null!;

    public string CorreoCliente { get; set; } = null!;

    public decimal TelefonoCliente { get; set; }

}
