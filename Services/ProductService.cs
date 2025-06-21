using Microsoft.EntityFrameworkCore;
using Price_Comparison.Data;
using Price_Comparison.DTOs;
using System.Linq.Dynamic.Core;
using Price_Comparison.Models;
using System.Web.Helpers;

namespace Price_Comparison.Services
{
    public class ProductService:IProductService
    {
        private readonly PriceDBContext _context;

        public ProductService(PriceDBContext context)
        {
            _context = context;
        }


        public IQueryable<SearchDto> SearchProduct(SearchObjectDto dto)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.ProductName))
                query = query.Where(p => p.Name.Contains(dto.ProductName, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(dto.Category))
                query = query.Where(p => p.Category.Equals(dto.Category, StringComparison.OrdinalIgnoreCase));

            if (dto.MinPrice.HasValue)
                query = query.Where(p => p.Price >= dto.MinPrice.Value);

            if (dto.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= dto.MaxPrice.Value);

            // Validate sort field
            var validSortFields = new[] { "id", "name", "category", "price" };
            if (string.IsNullOrWhiteSpace(dto.SortField) || !validSortFields.Contains(dto.SortField.ToLower()))
                dto.SortField = "name";

            // Normalize sort direction
            var sortDirection = dto.SortAscending?.ToLower() == "desc" ? "desc" : "asc";

            // Apply dynamic OrderBy
            query = query.OrderBy($"{dto.SortField} {sortDirection}");

            // Select into SearchDto (adjust projection as needed)
            return query.Select(p => new SearchDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price
            });
        }
    }
}
