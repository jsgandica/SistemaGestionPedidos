using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Vendedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estatus { get; set; }

    public DateTime? Fecha { get; set; }

    public int? UsuarioId { get; set; }

    public Guid? Rowguid { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
