using Microsoft.AspNetCore.Identity;

namespace Identity.API.Models;

public class User : IdentityUser
{
    public string Caption { get; set; }
    public string Resume {get; set;}
}