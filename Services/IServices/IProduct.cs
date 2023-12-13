using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;

namespace E_CommerceStore.Services.IServices
{
    public interface IProduct
    {
        Task<bool> CreateProduct(Product product); 
        Task<List<Product>> GetAllProducts();

        Task<Product>? GetProductById(Guid id);

        Task<bool> UpdateProduct(Guid id, AddProductDTO updateProduct);

        Task<bool> DeleteProduct(Guid id);
    }
}
