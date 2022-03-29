using System.ComponentModel.DataAnnotations;

namespace CRUDDatatableAjax.Models
{
    public class Contacto
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Email { get; set; }
    }
}
