using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Ventas> Venta { get; set; } = new List<Ventas>();
}
