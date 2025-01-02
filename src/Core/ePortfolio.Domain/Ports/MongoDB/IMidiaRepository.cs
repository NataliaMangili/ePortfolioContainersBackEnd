using MongoDBDataAccess.Services;

namespace ePortfolio.Domain.Ports.MongoDB;

public interface IMediaService
{
    /// <summary>
    /// Salva uma lista de mídia.
    /// </summary>
    /// <param name="mediaItems">Lista de itens de mídia a serem salvos.</param>
    Task SaveMediaItemsAsync(IEnumerable<MediaItem> mediaItems);

    /// <summary>
    /// Retorna uma lista paginada de mídia.
    /// </summary>
    /// <param name="pageNumber">Número da página</param>
    /// <param name="pageSize">Quantidade de itens por página.</param>
    Task<List<MediaItem>> GetMediaItemsPaginatedAsync(int pageNumber, int pageSize);
}