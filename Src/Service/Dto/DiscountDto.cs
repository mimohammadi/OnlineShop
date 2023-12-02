using Domain.Enums;

namespace Service.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DiscountType Type { get; set; }
        public long Value {  get; set; }
        public List<int> Orders { get; set; }
    }
}
