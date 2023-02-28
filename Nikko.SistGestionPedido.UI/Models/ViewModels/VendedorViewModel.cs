using System.ComponentModel.DataAnnotations;

namespace Nikko.SistGestionPedido.UI.Models.ViewModels
{
    public class VendedorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public string Nombre { get; set; } = null!;
        public Guid? Rowguid { get; set; }

    }
}
