using System.ComponentModel.DataAnnotations;

namespace AspNetMvcDemo.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Full Name")]
        public string? Name { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int Age { get; set; }

        [Display(Name = "Favorite Language")]
        public string? FavoriteLanguage { get; set; }
    }
}
