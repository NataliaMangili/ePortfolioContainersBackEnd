using Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Interfaces;

public interface IAuthRepository
{
    public Task<bool> IsUserPasswordValid(string username, string password);

    Task<IdentityResult> CreateUser(User user, string password);
}