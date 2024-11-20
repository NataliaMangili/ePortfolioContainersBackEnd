using ePortfolio.Application.Ports;
using ePortfolio.Domain.Models.ProjectAggregate;
using Microsoft.Extensions.Logging;

namespace ePortfolio.Application.Projects.Commands.Create;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, bool>
{
    private readonly ILogger<CreateProjectCommand> _logger;
    private readonly IWriteRepository<Project> _writeRepository;

    public CreateProjectHandler(ILogger<CreateProjectCommand> logger, IWriteRepository<Project> writeRepository)
    {
        _logger = logger;
        _writeRepository = writeRepository;
    }

    public async Task<bool> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        try
        {
            // Mapeamento do DTO para a entidade Project
            CreateProjectDTO dto = command.dto;

            var project = new Project(
                dto.Title,
                dto.HtmlDescription,
                dto.Order,
                dto.EProject,
                dto.userInclusionId
            );

            // Adicionando tags ao projeto
            var tags = dto.ProjectTags.Select(tagDto => new Tag(tagDto.Name, project.UserInclusion)).ToList();

            project.AddTags(tags); // Associando as tags ao projeto

            // Salvar o projeto no repositório
            //await _writeRepository.InsertAsync(project);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while attempting to process the CreateProject command.");
            throw new Exception("Unexpected error occurred while attempting to save the project.");
        }
    }
}
