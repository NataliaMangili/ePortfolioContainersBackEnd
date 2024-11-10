namespace ePortfolio.Domain.Models;

public class Image : Entity<Guid>
{
    //TODO Futuramente, ajustar o Name para que seja feito automatico
    public string Name { get; set; }
    public string Url { get; set; }

    public Image(Guid id, string name, string url, Guid userInclusion) : base(id, userInclusion)
    {
        SetName(name);
        SetUrl(url);  
    }

    //Todo : Implementar
    public void SetName(string name)
    {
        throw new  NotImplementedException();
    }

    //Todo : Implementar
    public void SetUrl(string url)
    {
        throw new  NotImplementedException();   
    }  
    
    
}
