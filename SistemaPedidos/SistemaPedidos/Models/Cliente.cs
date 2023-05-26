using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Apellido { get; set; } = null!;
    [Required]
    public string Telefono { get; set; } = null!;

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Ventas> Venta { get; set; } = new List<Ventas>();
}
