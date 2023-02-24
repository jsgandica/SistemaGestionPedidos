namespace Nikko.SistGestionPedido.UI.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

       
        public string? Telefono { get; set; }

        
        public DateTime Fecha { get; set; }

    }
}
