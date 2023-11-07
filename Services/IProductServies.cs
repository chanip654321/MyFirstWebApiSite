using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync();

        Task<IEnumerable<ProductsTbl>> GetProductsByCategoryAsync(int categoryId);
    }
}