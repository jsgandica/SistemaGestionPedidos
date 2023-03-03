using System.ComponentModel.DataAnnotations;

namespace Nikko.SistGestionPedido.UI.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Campo {0} debe ser requerido")]
        public string? Telefono { get; set; }
       
        [Display(Name = "Fecha Nacimiento")]
        public DateTime Fecha { get; set; }
        
    }
}
