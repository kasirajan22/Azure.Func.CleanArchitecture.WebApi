using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer;

[Table("UserSessions")]
public class UserSession
{
    public UserSession() => Id = Guid.NewGuid();
    
    [Key, Column("UserSessionId")]
    public Guid Id { get; init; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string SessionToken { get; set; }

    [MaxLength(100)]
    public string IpAddress { get; set; }

    [MaxLength(50)]
    public string LoginType { get; set; }

    public DateTime StartsOn { get; set; }

    public DateTime EndsOn { get; set; }

    public DateTime CreatedAt { get; set; }
}
