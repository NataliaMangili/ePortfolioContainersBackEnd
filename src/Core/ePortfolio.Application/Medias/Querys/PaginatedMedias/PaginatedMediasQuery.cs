using ePortfolio.Application.VMCommon;
using ePortfolio.Domain.Ports.MongoDB;

namespace ePortfolio.Application.Medias.Querys.PaginatedMedias;

public record PaginatedMediasQuery(int PageNumber, int PageSize) : IRequest<PaginatedResult<MediaItem>>;
