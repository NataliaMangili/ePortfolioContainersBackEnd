using ePortfolio.Domain.Enums;

namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Project : Entity<Guid>
{
    public Project() { }

    private readonly List<ProjectTag> _projectTags = new List<ProjectTag>();
    public IReadOnlyCollection<ProjectTag> ProjectTags => _projectTags.AsReadOnly();


    public string Title { get; set; }
    public string HtmlDescription { get; set; }
    public int Order { get; set; }
    public EProject EProject { get; set; }

    public Project(string title,
        string htmlDescription,
        int order,
        EProject eProject,
        Guid userInclusionId) : base(Guid.NewGuid(), userInclusionId)
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

    public void AddTags(IEnumerable<Tag> tags)
    {
        if (tags == null || !tags.Any())
        {
            throw new ArgumentException("The tag list cannot be null or empty.");
        }
        
        foreach (var tag in tags)
        {
            if (_projectTags.Any(pt => pt.TagId == tag.Id))
            {
                throw new InvalidOperationException($"Tag with Id {tag.Id} is already added.");
            }
        
            // Cria a associação entre o projeto e a tag
            var projectTag = new ProjectTag(this.Id, tag, this.UserInclusion);
            _projectTags.Add(projectTag);
        }
    }
}