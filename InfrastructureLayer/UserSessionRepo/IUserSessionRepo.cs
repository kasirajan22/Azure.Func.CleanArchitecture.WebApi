using DomainLayer;

namespace InfrastructureLayer;

public interface IUserSessionRepo : IRepositoryBase<UserSession>
{
     Task CloseExistingSessionsAsync(Guid userId, DateTime now);

    Task<UserSession?> ValidateSessionAsync(Guid userId, string? token);
}
