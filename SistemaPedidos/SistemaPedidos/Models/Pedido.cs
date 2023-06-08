using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Pedido
{
    [Required]
    public int IdPedido { get; set; }
    [Required]
    public int IdVenta { get; set; }
    [Required]
    public int IdProducto { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public decimal PrecioUnitario { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventas IdVentaNavigation { get; set; } = null!;
}
