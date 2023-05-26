using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Producto
{
    public int IdProducto { get; set; }
    [Required]
    public int IdMarca { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Color { get; set; } = null!;
    [Required]
    public string Modelo { get; set; } = null!;

    public string? Descripcion { get; set; }
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public int? Stock { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
