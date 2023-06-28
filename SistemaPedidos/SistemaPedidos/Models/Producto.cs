using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Talle { get; set; } = null!;

    public string? Descripcion { get; set; }

   // [Column, Display(Name = "PrecioCompra"), Required, DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Currency)] //Esto Permite resolver el problema de los numeros decimales
    public decimal PrecioCompra { get; set; }
   // [Column, Display(Name = "Precio"), Required, DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Currency)] //Esto Permite resolver el problema de los numeros decimales
    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
