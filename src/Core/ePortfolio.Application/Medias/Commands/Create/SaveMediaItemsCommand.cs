using Microsoft.AspNetCore.Http;

namespace ePortfolio.Application.Medias.Commands.Create;

public record SaveMediaItemsCommand(MediaItemsViewModel DTO) : IRequest<bool>;

public class MediaItemsViewModel
{
    public string MediaItemId { get; set; }
    public IFormFileCollection File { get; set; }

}
