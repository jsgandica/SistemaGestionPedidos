using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string? Comentario1 { get; set; }

    public int? VendedorId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
