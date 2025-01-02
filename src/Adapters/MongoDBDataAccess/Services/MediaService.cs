using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBDataAccess.Services;

public class MediaService(MongoBaseRepository mongoRepository)
{
    private readonly MongoBaseRepository _mongoRepository = mongoRepository;

    public async Task SaveMediaItemsAsync(IEnumerable<MediaItem> mediaItems)
    {
        await _mongoRepository.SaveItemsAsync("MediaCollection", mediaItems);
    }

    public async Task<List<MediaItem>> GetMediaItemsPaginatedAsync(int pageNumber, int pageSize)
    {
        return await _mongoRepository.GetItemsPaginatedAsync<MediaItem>("MediaCollection", pageNumber, pageSize);
    }
}

public class MediaItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Size { get; set; }
}