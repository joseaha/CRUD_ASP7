using System.ComponentModel.DataAnnotations;

namespace CRUD_ASP7.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Phone { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string PhoneNumber { get; set; }

        public DateTime ReleaseDate { get; set; }
      
    }
}
