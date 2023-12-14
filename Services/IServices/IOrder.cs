using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;

namespace E_CommerceStore.Services.IServices
{
    public interface IOrder
    {
        Task<bool> CreateOrder(Order order);

        Task<List<Order>> GetAllOrders();

        Task<Order>? GetSingleOrder(Guid id);

        Task<bool> UpdateOrder(Guid id, AddOrderDTO order);

        Task<bool> DeleteOrder(Guid id);    
    }
}
