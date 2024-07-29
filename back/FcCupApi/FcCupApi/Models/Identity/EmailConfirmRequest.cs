using System.ComponentModel.DataAnnotations;

namespace FcCupApi.Models.Identity
{
    public class EmailConfirmRequest
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;
    }
}
