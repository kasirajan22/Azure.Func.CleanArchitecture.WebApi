using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer;

public class SignUpRequestDto
{
    [Required, MaxLength(100)]
    public string UserName { get; set; }

    [Required, MaxLength(100)]
    public string Password { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(100)]
    public string PhoneNo { get; set; }

    [StringLength(3, MinimumLength = 3), DefaultValue("IND")]
    public string? CountryCode { get; set; }
}
