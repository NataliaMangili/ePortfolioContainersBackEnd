namespace Identity.API.Domain.Entity;

public  interface IIdentityEntity<TKey> where TKey : IEquatable<TKey>   
{
    public TKey Id { get;  }
    public DateTime Inclusion { get; }
    public DateTime Modification { get; set; }
    public bool Active { get; set; }

    public void SetActive();
    public void SetInactive();
}