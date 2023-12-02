using Common.Interface;
using Domain.Enums;

namespace Domain.Models.Order
{
    public class Order:BaseEntity,IAggregateRoot
    {
        public int UserId { get; private set; }
        public virtual User.User User { get; private set; }
        public long TotalPrice { get; private set; }
        public OrderStatus Sattus { get; private set; }
        public string? DiscountCode { get; private set; }
        public virtual Discount.Discount Discount { get; private set; }
        public long DisCountAmount { get; private set; }
        public DateTime? PaidDate { get; private set; }
        public PostMethod PostMethod { get; private set; }

        public ICollection<OrderItem> Items { get; private set; }

        protected Order() { }
        public Order(int userId, long totalPrice, PostMethod postMethod)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            Sattus = OrderStatus.Cart;
            Items = new List<OrderItem>();
            PostMethod = postMethod;
        }

        public void AddItem(int productId, int quantity, long price)
        {
            Items.Add(new OrderItem(productId, quantity, price));
        }

        public void Update(PostMethod postMethod, long totalPrice)
        {
            PostMethod = postMethod;
            TotalPrice = totalPrice;
        }

        public void Pay(string? discountCode, long totalPrice, long discountAmount)
        {
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 19)
                throw new ArgumentOutOfRangeException("بازه ثبت سفارش از 8 صبح تا 7 بعد از ظهر می باشد");

            if (TotalPrice < 50000)
                throw new ArgumentOutOfRangeException("حداقل مبلغ سفارش باید 50000 تومان باشد");

            DiscountCode = discountCode;
            TotalPrice = totalPrice;
            DisCountAmount = discountAmount;
        }
        
    }
}

