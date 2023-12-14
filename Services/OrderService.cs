using E_CommerceStore.Data;
using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;
using E_CommerceStore.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceStore.Services
{
    public class OrderService : IOrder
    {
        public readonly StoreContext _context; 
        
        public OrderService(StoreContext context) 
        {
            _context = context; 
        }   
        public async Task<bool> CreateOrder(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;   
            }
        }
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Order>();
            }
        }

        public async Task<Order>? GetSingleOrder(Guid id)
        {
            try
            {
                var order = await _context.Orders.Where(order => order.Id == id).FirstOrDefaultAsync();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> UpdateOrder(Guid id, AddOrderDTO order)
        {
            try
            {
                var orderToUpdate = await _context.Orders.Where(order => order.Id == id).FirstOrDefaultAsync();
                if (orderToUpdate != null)
                {
                    orderToUpdate.ProductId = order.ProductId;
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

        public async Task<bool> DeleteOrder(Guid id)
        {
            try
            {
                var orderToDelete = await _context.Orders.Where(order => order.Id == id).FirstOrDefaultAsync();
                if (orderToDelete != null)
                {
                    _context.Orders.Remove(orderToDelete);
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
