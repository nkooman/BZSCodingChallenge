using System.ComponentModel.DataAnnotations;

namespace BZSCodingChallenge.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
