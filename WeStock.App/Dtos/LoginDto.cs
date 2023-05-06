using System.ComponentModel.DataAnnotations;

namespace WeStock.App.Dtos
{
    public class LoginDto
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
