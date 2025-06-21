using Price_Comparison.DTOs;

namespace Price_Comparison.Services
{
    public interface IProductService
    {
        IQueryable<SearchDto> SearchProduct(SearchObjectDto dto);
    }
}
