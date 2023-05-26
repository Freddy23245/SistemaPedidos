using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
