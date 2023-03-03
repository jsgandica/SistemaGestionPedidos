using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Rol { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioId { get; set; }
}
