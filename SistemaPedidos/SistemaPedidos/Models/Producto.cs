using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Talle { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioCompra { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
