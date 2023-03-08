namespace Nikko.SistGestionPedido.UI.Models.ViewModels
{
    public class LineaPedidoViewModel
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public decimal Cantidad { get; set; }

        public int? UsuarioId { get; set; }

        public int PedidoId { get; set; }
    }
}
