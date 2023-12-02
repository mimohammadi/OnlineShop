using Domain.Enums;

namespace Service.Dto
{
    public class OrderDto
    {
        public string? DiscountCode { get; set; }
        public int OrderId { get; set;}
    }
    
    public class OrderItemCreateDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
