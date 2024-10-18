using ePortfolio.Domain.Enums;

namespace ePortfolio.Domain.Models;

public class Project : Entity<Guid>
{
    public string Title { get; set; }
    public string HtmlDescription { get; set; }
    public int Order { get; set; }
    public EProject EProject { get; set; }

    public Project(string title,
        string htmlDescription,
        int order,
        EProject eProject,
        Guid id,
        Guid userInclusionId):base(id,userInclusionId)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));    
        HtmlDescription = htmlDescription ?? throw new ArgumentNullException(nameof(htmlDescription));
        Order = order;  
        EProject = eProject ;    
    }

    private Project()
    {
        
    }
}