using ePortfolio.Application.VMCommon;
using ePortfolio.Domain.Ports.MinIO;
using ePortfolio.Domain.Ports.MongoDB;
using Microsoft.Extensions.Logging;
using Minio.DataModel;

namespace ePortfolio.Application.Medias.Querys.PaginatedMedias;

public class PaginatedMediasHandler(ILogger<PaginatedMediasQuery> logger, IFileService minio, IMediaService mongo) : IRequestHandler<PaginatedMediasQuery, PaginatedResult<MediaItem>>
{
    private readonly ILogger<PaginatedMediasQuery> _logger = logger;
    private readonly IFileService _minioStorage = minio;
    private readonly IMediaService _mediaMongoService = mongo;

    public async Task<PaginatedResult<MediaItem>> Handle(PaginatedMediasQuery query, CancellationToken cancellationToken)
    {
        // Busca a coleção do MongoDB
        List<MediaItem> items = await _mediaMongoService.GetMediaItemsPaginatedAsync(query.PageNumber, query.PageSize);

        // Conta o número total de itens na coleção
        int totalCount = await _mediaMongoService.GetTotalCountAsync();

        // Retorna o resultado paginado
        return new PaginatedResult<MediaItem>(items, totalCount, query.PageNumber, query.PageSize);
    }
}