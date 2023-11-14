using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync(string? name, int? minPrice, int? maxPrice, int?[] CategoryIds);

        Task<IEnumerable<ProductsTbl>> GetProductsByCategoryAsync(int categoryId);
    }
}