using Service.Dto;

namespace Service.Interface
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDto>> GetAll();
    }
}
