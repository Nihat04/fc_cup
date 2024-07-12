using System.ComponentModel.DataAnnotations;

namespace FcCupApi.Models.Identity
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}