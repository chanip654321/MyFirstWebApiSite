using Entities;

namespace Services
{
    public interface ICategoryServies
    {
        Task<IEnumerable<CategoriesTbl>> GetCategoriesAsync();
    }
}