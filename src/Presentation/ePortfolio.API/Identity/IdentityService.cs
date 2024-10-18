namespace ePortfolio.API.Identity;

public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    public string GetUserId() => context.HttpContext?.User.FindFirst("sub")?.Value;

    public string GetUserName() => context.HttpContext?.User.Identity?.Name;
}
