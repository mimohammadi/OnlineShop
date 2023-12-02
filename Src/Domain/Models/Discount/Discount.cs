using Common.Interface;
using Domain.Enums;

namespace Domain.Models.Discount
{
    public class Discount:BaseEntity,IAggregateRoot
    {
        public string Code { get; private set; }
        public DiscountType Type { get; private set; }
        public long Value { get; private set; }
        public ICollection<Order.Order> Orders { get; private set; }

        protected Discount()
        {
            
        }

        public Discount(string code, DiscountType type, long value)
        {
            GuardAgainstIfValueIsLessThanZero(value);
            GuardAgainstIfTypeIsPercentageAndValueIsMoreThan100(type, value);

            Code = code;
            Type = type;
            Value = value;
            Orders = new List<Order.Order>();

        }

        private static void GuardAgainstIfTypeIsPercentageAndValueIsMoreThan100(DiscountType type, long value)
        {
            if (type == DiscountType.Percentage && value > 100)
                throw new ArgumentException("درصد تخفیف باید کمتر از 100 باشد");
        }

        private static void GuardAgainstIfValueIsLessThanZero(long value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("مقدار یا درصد تخفیف باید بزرگتر از 0 باشد");
        }
    }
}
