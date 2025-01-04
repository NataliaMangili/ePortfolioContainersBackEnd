namespace ePortfolio.Application.VMCommon;

//TO DO: Colocar em um projeto Shared/BuildingBlocks
//Construtor Primário
public class PaginatedResult<T>(List<T> items, int totalCount, int pageNumber, int pageSize)
{
    public List<T> Items { get; set; } = items;
    public int TotalCount { get; set; } = totalCount;
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}