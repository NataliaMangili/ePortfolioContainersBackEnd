using ePortfolio.Domain.Ports.MongoDB;

namespace MongoDBDataAccess.Services;

public class MediaService(MongoBaseRepository mongoRepository) : IMediaService
{
    private readonly MongoBaseRepository _mongoRepository = mongoRepository ?? throw new ArgumentNullException(nameof(mongoRepository));
    private static readonly string mediaCollection = "Media";

    public async Task<bool> SaveMediaItemsAsync(IEnumerable<MediaItem> mediaItems)
    {
        await _mongoRepository.SaveItemsAsync(mediaCollection, mediaItems);
        return true;
    }

    public async Task<List<MediaItem>> GetMediaItemsPaginatedAsync(int pageNumber, int pageSize)
    {
        return await _mongoRepository.GetItemsPaginatedAsync<MediaItem>(mediaCollection, pageNumber, pageSize);
    }
}
