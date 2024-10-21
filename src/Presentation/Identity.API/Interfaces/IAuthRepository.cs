namespace Identity.API.Interfaces;

public interface IAuthRepository
{
    public Task<bool> IsUserPasswordValid(string username, string password);
    
    
}