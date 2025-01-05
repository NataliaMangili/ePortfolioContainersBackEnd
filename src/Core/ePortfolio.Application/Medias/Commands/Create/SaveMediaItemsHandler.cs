using ePortfolio.Domain.Ports;
using ePortfolio.Domain.Ports.MinIO;
using ePortfolio.Domain.Ports.MongoDB;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace ePortfolio.Application.Medias.Commands.Create;

public class SaveMediaItemsHandler(ILogger<SaveMediaItemsCommand> logger, IFileService minio, IMediaService mongo, ICacheService redis) : IRequestHandler<SaveMediaItemsCommand, bool>
{
    private readonly ILogger<SaveMediaItemsCommand> _logger = logger;
    private readonly IFileService _minioStorage = minio;
    private readonly IMediaService _mongoService = mongo;
    private readonly ICacheService _redisCache = redis;

    public async Task<bool> Handle(SaveMediaItemsCommand command, CancellationToken cancellationToken)
    {
        if (command.DTO.File == null || command.DTO.File.Count == 0) throw new ArgumentException("No files were provided in the request.");

        IEnumerable<Task<MinioFileReturn>> uploadTasks = command.DTO.File.Select(file => UploadFileAsync(file));
        MinioFileReturn[] uploadedMedia = await Task.WhenAll(uploadTasks);

        await UpdateCache();

        // Valida se todos os uploads retornaram sucesso
        if (uploadedMedia.Any(media => !media.Success)) { throw new InvalidOperationException("One or more files failed to upload to MinIO."); }

        await CreateAndInsertInMongo(uploadedMedia);

        return true;
    }

    private async Task UpdateCache()
    {
        // Atualizar o cache com as 3 primeiras imagens
        List<MediaItem> topImages = (await _mongoService.GetMediaItemsPaginatedAsync(1, 3, item => item.Type == EType.image));

        await _redisCache.SetAsync("Top3Images", topImages);
    }

    private async Task<MinioFileReturn> UploadFileAsync(IFormFile file)
    {
        MinioFileReturn uploadedMedia = await _minioStorage.UploadAsync(file);

        if (!uploadedMedia.Success) _logger.LogWarning(message: $"Failed to upload file '{file.FileName}' to MinIO.");

        return uploadedMedia;
    }

    private async Task CreateAndInsertInMongo(MinioFileReturn[] uploadedMedia)
    {
        var mediaItems = uploadedMedia.Select(media => new MediaItem { Name = media.Name });
        await _mongoService.SaveMediaItemsAsync(mediaItems);
    }
}
