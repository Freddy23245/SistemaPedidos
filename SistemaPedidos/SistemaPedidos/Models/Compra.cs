using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdProveedor { get; set; }

    public int? NumeroCompra { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}
