namespace ePortfolio.Application.Projects.Commands.Create;

public record CreateProjectCommand(CreateProjectDTO dto) : IRequest<bool>;
