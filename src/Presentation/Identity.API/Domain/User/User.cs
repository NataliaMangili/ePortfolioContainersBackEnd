using Microsoft.AspNetCore.Identity;

namespace Identity.API.Domain.User;

public class User : IdentityUser
{
    public string Caption { get; set; }
    public string Resume {get; set;}
}