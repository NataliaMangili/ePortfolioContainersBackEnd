namespace Identity.API.Domain.Entity;

public class IdentiyEntity : IIdentityEntity<Guid>
{
    public Guid Id { get;  }
    public DateTime Inclusion { get; }
    public DateTime Modification { get; set; }
    public bool Active { get; set; }


    public IdentiyEntity(Guid id,DateTime inclusion,DateTime modification,bool active = true)
    {
        Id = Guid.NewGuid();
        Inclusion = DateTime.Now;  
        Modification = modification;    
        Active = active;
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