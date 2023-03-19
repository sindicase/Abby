using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(0, 100, ErrorMessage = "Display order have to be in range of 1-100!")]
        public int DisplayOrder { get; set; }


    }
}
