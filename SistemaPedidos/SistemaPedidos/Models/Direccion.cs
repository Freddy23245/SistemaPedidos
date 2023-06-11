using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Direccion
{
    public int IdDireccion { get; set; }
    [Required(ErrorMessage = "Cliente Requerido")]
    public int IdCliente { get; set; }
    [Required(ErrorMessage = "Lugar Requerido")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "Horario Requerido")]
    public TimeSpan Horario { get; set; }
    [Required(ErrorMessage = "Fecha de Entrega Requerida")]
    public DateTime Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
