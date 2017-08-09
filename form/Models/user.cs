using System.ComponentModel.DataAnnotations;
 
namespace form.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}