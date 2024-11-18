
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Domain.User;

public interface IUsersRepository<TUser>
{
    public Task<bool> IsUserPasswordValid(string username, string password);

    Task<IdentityResult> CreateUser(TUser user, string password);
}