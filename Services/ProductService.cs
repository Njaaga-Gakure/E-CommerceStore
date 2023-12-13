using E_CommerceStore.Data;
using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;
using E_CommerceStore.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceStore.Services
{
    public class ProductService : IProduct
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
        }

        public async Task<Product>? GetProductById(Guid id)
        {
            try
            {
                var product = await _context.Products.Where(product => product.Id == id).FirstOrDefaultAsync();
                return product; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;    
            }
        }

        public async Task<bool> UpdateProduct(Guid id, AddProductDTO updateProduct)
        {
            try
            {
                var product = await _context.Products.Where(product => product.Id == id).FirstOrDefaultAsync();
                if (product != null) { 
                    product.Name = updateProduct.Name;
                    product.Description = updateProduct.Description;
                    product.Price = updateProduct.Price;
                    await _context.SaveChangesAsync();
                    return true;    
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _context.Products.Where(product => product.Id == id).FirstOrDefaultAsync();
                if (product != null) { 
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();  
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
