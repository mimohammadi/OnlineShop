namespace Domain.Models.Order
{
    public class OrderItem:BaseEntity
    {
        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }
        public int ProductId { get; private set;}
        public virtual Product.Product Product { get; private set; }
        public int Quantity { get; private set; }
        public long Price { get; private set; }
        protected OrderItem()
        {
            
        }

        public OrderItem(int productId, int quantity, long price)
        {
            GuardAgainstIfQuqntityIsZeroOrLess(quantity);
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        private static void GuardAgainstIfQuqntityIsZeroOrLess(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("تعداد باید بزرگتر از 0 باشد");
        }
    }
}
