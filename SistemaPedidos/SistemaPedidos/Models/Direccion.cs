using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Models;

public partial class Direccion
{
    [Required]
    public int IdDireccion { get; set; }
    [Required]
    public int IdCliente { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public TimeSpan Horario { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
