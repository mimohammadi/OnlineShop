using Domain;
using Domain.Enums;
using Domain.Models.Order;
using Service.Dto;
using Service.Interface;

namespace Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public OrderService(IRepository<Order> repository,
            IProductService productService,
            IDiscountService discountService)
        {
            _repository = repository;
            _productService = productService;
            _discountService = discountService;
        }

        public async Task AddItem(OrderItemCreateDto dto)
        {
             var product = await _productService.Get(dto.ProductId);
            if (product == null) throw new ArgumentNullException("محصول یافت نشد");
            if (product.Quantity < dto.Quantity)
                throw new ArgumentOutOfRangeException("محصول برای سفارش در این تعداد در دسترس نیست");

            var orders = await _repository.GetAll(); //بهینه نیست میتونه
                                                    //AsQuerable
                                                    //باشه و داخل حافظه همه رکورد ها رو نیاره
            if (orders == null) throw new ArgumentNullException("سفارشی یافت نشد");
            var order = orders.SingleOrDefault(a => a.UserId == dto.UserId
            && a.Sattus == OrderStatus.Cart);

            if(order == null)
            {
                var post = product.PackingMethod == PackingMethod.Breakable_Products ? PostMethod.Express_Mail : PostMethod.Regular_Post;
                order = new Order(dto.UserId, product.Price + product.Profit, post);
                order.AddItem(product.Id, dto.Quantity, product.Price + (product.Profit * dto.Quantity));
                await _repository.Insert(order);
            }
            else
            {
                var price = product.Price + (product.Profit * dto.Quantity);
                var post = order.PostMethod;

                if (product.PackingMethod == PackingMethod.Breakable_Products && order.PostMethod == PostMethod.Regular_Post)
                    post = PostMethod.Express_Mail;

                order.Update(post, order.TotalPrice + price);
                order.AddItem(product.Id, dto.Quantity, price);
                await _repository.Update(order);
            }
        }

        public async Task PayOrder(int id, string? discountCode)
        {
            var order = await _repository.Get(id);
            if (order == null) throw new ArgumentNullException("سفارش یافت نشد");

            DiscountDto? dis = null;
            if (discountCode != null)
            {
                var discountLst = await _discountService.GetAll();
                dis = discountLst.Where(a => a.Code == discountCode && a.Orders.Contains(id))
                    .FirstOrDefault();
            }
            var total = order.TotalPrice;
            long discountAmount = 0;
            if(dis!= null)
            {
                if (dis.Type == DiscountType.Amount)
                {
                    total = total - dis.Value;
                    discountAmount = dis.Value;
                }
                else
                {
                    discountAmount = (total * (dis.Value / 100));
                    total = total - (total * (dis.Value / 100));
                }
            }
            order.Pay(dis?.Code?? null, total, discountAmount);

            await _repository.Update(order);
        }
    }
}
