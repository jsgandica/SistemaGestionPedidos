using System.ComponentModel.DataAnnotations;
namespace Nikko.SistGestionPedido.UI.Models.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int? ClienteId { get; set; }

        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public string? CodigoFactura { get; set; }

        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public decimal? Total { get; set; }

        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public bool? Estatus { get; set; }

        //public int? VendedorId { get; set; }

        public int? UsuarioId { get; set; }
        public int ProductoId { get; set; }
    }
}
