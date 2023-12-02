using Service.Dto;

namespace Service.Interface
{
    public interface IOrderService
    {
        Task AddItem(OrderItemCreateDto dto);
        Task PayOrder(int id, string? discountCode);
    }
}
