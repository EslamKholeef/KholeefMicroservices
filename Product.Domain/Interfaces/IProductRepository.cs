using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductModel> GetByIdAsync(int id);
        Task<List<ProductModel>> GetAllAsync();
        Task AddAsync(ProductModel product);
        Task <bool> UpdateAsync(ProductModel product);
        Task DeleteAsync(int id); 
        Task DeleteAllAsync();
    }
}
