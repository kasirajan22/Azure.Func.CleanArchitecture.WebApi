using System.ComponentModel.DataAnnotations;

namespace PresentationLayer;
public class SignInDto
{
    [Required, MaxLength(100)]
    public string UserName { get; set; }

    [Required, MaxLength(100)]
    public string Password { get; set; }
}
