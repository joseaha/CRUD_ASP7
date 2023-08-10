using System.ComponentModel.DataAnnotations;

namespace CRUD_ASP7.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "The user is required")]
        [StringLength(20)]
        public string User { get; set; }

        [Required(ErrorMessage = "The user is Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The user is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
