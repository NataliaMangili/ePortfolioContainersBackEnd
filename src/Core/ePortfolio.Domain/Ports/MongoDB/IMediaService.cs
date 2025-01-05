using System.Linq.Expressions;

namespace ePortfolio.Domain.Ports.MongoDB;

public interface IMediaService
{
    /// <summary>
    /// Salva uma lista de mídia.
    /// </summary>
    Task<bool> SaveMediaItemsAsync(IEnumerable<MediaItem> mediaItems);

    /// <summary>
    /// Retorna uma lista paginada de mídia.
    /// </summary>
    Task<List<MediaItem>> GetMediaItemsPaginatedAsync(int pageNumber, int pageSize, Expression<Func<MediaItem, bool>>? filter = null);

    /// <summary>
    /// Retorna uma Contagem de todos os objetos
    /// </summary>
    Task<int> GetTotalCountAsync();
}

public class MediaItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string? Author { get; set; }
    public long? Duration { get; set; }
    public string Url { get; set; }
    public EType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public long Size { get; set; }
    public Guid ProjectId { get; set; }
}


public enum EType
{
    image = 0,
    video = 1,
}