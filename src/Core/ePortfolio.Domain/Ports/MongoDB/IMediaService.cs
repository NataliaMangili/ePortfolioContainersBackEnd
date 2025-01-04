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
    Task<List<MediaItem>> GetMediaItemsPaginatedAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Retorna uma Contagem de todos os objetos
    /// </summary>
    Task<int> GetTotalCountAsync();
}

public class MediaItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? Author { get; set; }
    public long? Duration { get; set; }
    public string Url { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public long Size { get; set; }
}