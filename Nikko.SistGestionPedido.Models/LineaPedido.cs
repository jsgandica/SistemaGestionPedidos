using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class LineaPedido
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioId { get; set; }

    public int PedidoId { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
