using System.Text.Json.Serialization;

namespace PresentationLayer;

public class UserDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    public string NameIdentifier { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool ForcePasswordChange { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; }
    private DateTime? LastLogin {get;set;}
    public bool IsEnabled { get; set; } = true;

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }

    public string Token { get; set; }



}