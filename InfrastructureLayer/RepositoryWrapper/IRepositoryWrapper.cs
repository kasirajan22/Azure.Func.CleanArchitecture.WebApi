using InfrastructureLayer;

namespace InfrastructureLayer;

public interface IRepositoryWrapper
{
    IUserRepo userRepo { get; }
    IUserSessionRepo userSessionRepo {get;}
    Task<int> SaveAsync();

}
