using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Pedido
{

    public int IdPedido { get; set; }
   
    public int IdVenta { get; set; }
    [Required(ErrorMessage = "Producto Requerido")]
    public int IdProducto { get; set; }
    [Required(ErrorMessage = "Cantidad Requerida")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "Precio Unitario Requerido")]
    public decimal PrecioUnitario { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventas IdVentaNavigation { get; set; } = null!;
}
