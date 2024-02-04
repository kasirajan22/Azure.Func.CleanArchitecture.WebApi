using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer;

public class UserSessionRepo : RepositoryBase<UserSession>, IUserSessionRepo
{
    public UserSessionRepo(RepositoryContext context) : base(context)
    {
    }

    public async Task CloseExistingSessionsAsync(Guid userId, DateTime now)
    {
        var sessions = await FindByCondition(x => x.UserId.Equals(userId) && x.EndsOn >= now).ToListAsync();
        sessions.ForEach(x => x.EndsOn = now);
        UpdateRange(sessions);
    }

    public async Task<UserSession?> ValidateSessionAsync(Guid userId, string? token)
    {
        return await FindByCondition(x => x.UserId.Equals(userId) && x.SessionToken != null && x.SessionToken.Equals(token) 
        && x.EndsOn >= DateTime.UtcNow).Include(s => s.User).FirstOrDefaultAsync();
    }
}
