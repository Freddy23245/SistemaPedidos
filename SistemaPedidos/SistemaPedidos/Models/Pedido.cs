﻿using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public double? Seña { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventas IdVentaNavigation { get; set; } = null!;
}
