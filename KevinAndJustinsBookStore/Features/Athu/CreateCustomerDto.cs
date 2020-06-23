using System.ComponentModel.DataAnnotations;

namespace KevinAndJustinsBookStore.Features.Authentication
{
    public class CreateCustomerDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string EmailConfirmed { get; set; }
        [Required]
        public string PasswordConfirmed { get; set; }
    }
}