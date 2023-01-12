using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class FormaPago
{
    public byte IdFormaPago { get; set; }

    public string DescFormaPago { get; set; } = null!;

}
