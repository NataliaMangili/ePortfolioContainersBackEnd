
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Interfaces;

public interface IAuthRepository<TUser>
{
    public Task<bool> IsUserPasswordValid(string username, string password);

    Task<IdentityResult> CreateUser(TUser user, string password);
}