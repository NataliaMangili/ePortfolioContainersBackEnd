using ePortfolio.Domain.Enums;

namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Project : Entity<Guid>
{
    private Project() { }
    public string Title { get; set; }
    public string HtmlDescription { get; set; }
    public int Order { get; set; }
    public EProject EProject { get; set; }

    public Project(string title,
        string htmlDescription,
        int order,
        EProject eProject,
        Guid id,
        Guid userInclusionId) : base(id, userInclusionId)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        HtmlDescription = htmlDescription ?? throw new ArgumentNullException(nameof(htmlDescription));
        Order = order;
        EProject = eProject;
    }
    public void UpdateProject(string title, string htmlDescription, int order, EProject eProject)
    {
        SetTitle(title);
        SetHtmlDescription(htmlDescription);
        SetOrder(order);
        SetProjectType(eProject);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (title.Length > 100)
            throw new ArgumentException("Title cannot exceed 100 characters.");

        Title = title;
    }

    public void SetHtmlDescription(string htmlDescription)
    {
        if (string.IsNullOrWhiteSpace(htmlDescription))
            throw new ArgumentException("HtmlDescription cannot be empty.");

        if (htmlDescription.Length > 2000)
            throw new ArgumentException("HtmlDescription cannot exceed 2000 characters.");

        HtmlDescription = htmlDescription;
    }

    public void SetOrder(int order)
    {
        if (order < 0)
            throw new ArgumentException("Order cannot be negative.");

        Order = order;
    }

    public void SetProjectType(EProject eProject)
    {
        if (!Enum.IsDefined(typeof(EProject), eProject))
            throw new ArgumentException("Invalid project type.");

        this.EProject = eProject;
    }
}