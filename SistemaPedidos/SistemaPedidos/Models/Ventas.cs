using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Ventas
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdTipo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Tipo IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
