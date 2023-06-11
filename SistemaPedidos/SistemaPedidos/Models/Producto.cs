using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Producto
{
    public int IdProducto { get; set; }
    [Required(ErrorMessage = "Marca Requerida")]
    public int IdMarca { get; set; }
    [Required(ErrorMessage = "Nombre Requerido")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "Color Requerido")]
    [StringLength(50)]
    public string Color { get; set; } = null!;
    [Required(ErrorMessage = "Modelo Requerido")]
    [StringLength(50)]
    public string Modelo { get; set; } = null!;
    
    [Required(ErrorMessage = "Descripción Requerida")]
    [StringLength(200,MinimumLength =10)]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Precio Requerido")]
    public decimal Precio { get; set; }
    [Required(ErrorMessage = "Stock Requerido")]
    public int? Stock { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
