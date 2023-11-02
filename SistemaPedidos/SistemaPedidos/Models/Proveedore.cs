using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
