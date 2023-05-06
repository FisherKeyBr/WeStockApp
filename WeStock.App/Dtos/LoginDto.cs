using System.ComponentModel.DataAnnotations;

namespace WeStock.App.Dtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
