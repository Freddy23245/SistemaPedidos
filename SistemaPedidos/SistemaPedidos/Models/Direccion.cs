using System;
using System.Collections.Generic;

namespace SistemaPedidos.Models;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeSpan Horario { get; set; }

    public DateTime Fecha { get; set; }

    public bool? Entregado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
