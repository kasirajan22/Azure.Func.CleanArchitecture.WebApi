using DomainLayer;

namespace InfrastructureLayer;

public interface IUserRepo : IRepositoryBase<User>
{
    Task<User?> GetAsync(Guid? userId = null, string? userName = "");
    Task<User?> GetUserByIdAsync(Guid id);
    Task<int> GetLatestUserIdAsync();
}
