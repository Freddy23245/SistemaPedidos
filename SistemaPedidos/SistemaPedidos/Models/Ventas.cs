using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Ventas
{
    public int IdVenta { get; set; }
    [Required(ErrorMessage = "Cliente Requerido")]
    public int IdCliente { get; set; }
    [Required(ErrorMessage = "Tipo de Comprobante Requerido")]
    public int IdTipo { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Tipo IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
