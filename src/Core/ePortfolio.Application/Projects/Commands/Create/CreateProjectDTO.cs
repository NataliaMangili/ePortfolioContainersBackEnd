using ePortfolio.Domain.Enums;

namespace ePortfolio.Application.Projects.Commands.Create;

public record CreateProjectDTO(
    string Title,
    string HtmlDescription,
    int Order,
    EProject EProject,
    Guid userInclusionId,
    IReadOnlyCollection<ProjectTagDto> ProjectTags
);

public record ProjectTagDto(
    string Name
);
