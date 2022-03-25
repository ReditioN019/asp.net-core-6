using System.ComponentModel.DataAnnotations;

namespace CRUDDatatableAjax.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        [StringLength(maximumLength: 50, ErrorMessage = "No puede contener mas de {1} letras")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Edad")]
        [Range(1,120, ErrorMessage = "El campo {0} debe ser entre {1} y {2}")]
        public int Year { get; set; }

        public DateTime BirthDate { get; set; } //= DateTime.Now;
    }
}
