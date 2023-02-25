using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Extension { get; set; }

    public string? Email { get; set; }

    public DateTime Fecha { get; set; }

    public string? Tipo { get; set; }

    public string? Estatus { get; set; }

    public int? VendedorId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
