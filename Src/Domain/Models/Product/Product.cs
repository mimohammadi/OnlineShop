using Common.Interface;
using Domain.Enums;
using Domain.Models.Order;
using System.Diagnostics;

namespace Domain.Models.Product
{
    public class Product:BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public short Quantity { get; private set; }
        public PackingMethod PackingMethod { get; private set; }
        public string Description { get; private set; }
        public long Price { get; private set; }
        public long Profit { get; private set; }

        public virtual ICollection<OrderItem> Items { get; private set; }
        protected Product() { }
        public Product(string title, short quantity, PackingMethod packingMethod, string description, 
            long price, long profit)
        {
            Title = title;
            Quantity = quantity;
            PackingMethod = packingMethod;
            Description = description;
            Profit = profit;
            Price = price;
        }

        public void Update(string title, short quantity, PackingMethod packingMethod, string description,
            long price, long profit)
        {
            Title = title;
            Quantity = quantity;
            PackingMethod = packingMethod;
            Description = description;
            Profit = profit;
            Price = price;
        }
    }
}

