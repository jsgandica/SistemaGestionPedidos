using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int? ClienteId { get; set; }

    public string? CodigoFactura { get; set; }

    public decimal? Total { get; set; }

    public bool? Estatus { get; set; }

    public int? VendedorId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
