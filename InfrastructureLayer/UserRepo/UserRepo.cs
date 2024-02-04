using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer;

public class UserRepo : RepositoryBase<User>, IUserRepo
{
    public UserRepo(RepositoryContext context) : base(context) { }
   public async Task<User?> GetAsync(Guid? id = null, string? userName = "")
    {
        return await FindByCondition(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
    }
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await FindByCondition(u => u.Id.Equals(id)).FirstOrDefaultAsync();
    }
    public async Task<int> GetLatestUserIdAsync()
    {
        return await FindAll().Select(u => Convert.ToInt32(u.NameIdentifier.Replace("EMP", "")))
            .OrderByDescending(u => u).FirstOrDefaultAsync();
    }
}
