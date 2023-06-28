using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
