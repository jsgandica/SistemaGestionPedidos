using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class RolPermiso
{
    public int Id { get; set; }

    public string Accion { get; set; } = null!;

    public int RolId { get; set; }

    public bool Activo { get; set; }

    public DateTime Fecha { get; set; }
}
