using InfrastructureLayer;

namespace InfrastructureLayer;

public sealed class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IUserRepo> _userRepo;
    private readonly Lazy<IUserSessionRepo> _userSessionRepo;

    public RepositoryWrapper(RepositoryContext context)
    {
        _context = context;
        _userRepo = new(() => new UserRepo(_context));
        _userSessionRepo = new(() => new UserSessionRepo(_context));
    }
    public IUserRepo userRepo => _userRepo.Value;
    public IUserSessionRepo userSessionRepo => _userSessionRepo.Value;

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
