using System.ComponentModel.DataAnnotations;

namespace ContactBookApp
{
    public record ContactModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MaxLength(13)]
        [MinLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }

    public record UpdateContactModel
    {
        [Required]
        [MaxLength(13)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
