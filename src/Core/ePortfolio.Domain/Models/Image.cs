using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ePortfolio.Domain.Models;

public class Image : Entity<Guid>
{
    //TODO Futuramente, ajustar o Name para que seja feito automatico
    public Image()
    {
        
    }
    public string Name { get; set; }
    [Url]
    [Description("Store the relative image url")]
    public string Url { get; set; }

    public Image(string name, string url, Guid userInclusion) : base(Guid.NewGuid(), userInclusion)
    {
        SetName(name);
        SetUrl(url);  
    }

    //Todo : Implementar
    public void SetName(string name)
    {
        if(string.IsNullOrEmpty((name)))
            throw new ArgumentException(nameof(name),"There's no name");
        
        string?  extension = GetFileExtension(name);
        
        if(string.IsNullOrEmpty(extension) || extension?.Length != 3)
            throw new ArgumentException(nameof(name), "There's no file extension");

        Name = name;

    }

    
    public void SetUrl(string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(url),"There's no file url");
        
        if(!url.Contains('/'))
            throw new ArgumentException(nameof(url),"invalid file url"); 
        
        Url = url;
    }  
    
    public string FileExtension => GetFileExtension(Name);

    private string GetFileExtension(string fileName) => fileName.Trim().Split('.').Last();

}
