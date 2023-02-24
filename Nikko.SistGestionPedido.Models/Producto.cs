using System;
using System.Collections.Generic;

namespace Nikko.SistGestionPedido.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Modelo { get; set; }

    public string? Presentacion { get; set; }

    public string? Marca { get; set; }

    public decimal Costo { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Stock { get; set; }

    public bool? Estatus { get; set; }

    public int? VendedorId { get; set; }

    public int? AlmacenId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
