using System.ComponentModel.DataAnnotations;

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } // Hashed

        [Required]
        public string Role { get; set; }
    }
}
