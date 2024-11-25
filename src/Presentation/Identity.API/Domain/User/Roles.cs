using Identity.API.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Domain.User;

public class Roles : IdentityRole<Guid>,IIdentityEntity<Guid>
{
    public Roles()
    {
        
    }

    public Roles(string roleName,bool active = true)
    {
        SetName(roleName);
        Id = Guid.NewGuid();
        Inclusion = DateTime.Now;
        Modification = DateTime.Now;    
        Active = active;
    }
    
    public DateTime Inclusion { get; }
    public DateTime Modification { get; set; }
    public bool Active { get; set; }

    public void SetName(string roleName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(roleName, "There's no role name");  
        Name = roleName;
    }
    public void SetActive()
    {
        Active = true;
    }

    public void SetInactive()
    {
        Active = false;
    }
}