using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class SignInWm
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
