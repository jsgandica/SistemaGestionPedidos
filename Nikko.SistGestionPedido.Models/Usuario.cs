using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RolId { get; set; }

    public string Password { get; set; } = null!;

    public bool Estatus { get; set; }

    public int? UsuarioPadreId { get; set; }
}
