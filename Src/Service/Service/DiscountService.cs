using Domain;
using Domain.Models.Discount;
using Service.Dto;
using Service.Interface;

namespace Service.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepository<Discount> _repository;

        public DiscountService(IRepository<Discount> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DiscountDto>> GetAll()
        {
            var lst = await _repository.GetAll();
            return lst.Select(a => new DiscountDto
            {
                Id = a.Id,
                Code = a.Code,
                Orders = a.Orders.Select(a => a.Id).ToList(), // include
                Type = a.Type,
                Value = a.Value,
            });
        }
    }
}
