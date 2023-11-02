using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int IdCompra { get; set; }

    public int IdProducto { get; set; }

    public DateTime Fecha { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal? Total { get; set; }

    public virtual Compra IdCompraNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
