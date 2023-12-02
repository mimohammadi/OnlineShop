using Domain.Enums;

namespace Service.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Quantity { get; set; }
        public PackingMethod PackingMethod { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Profit { get; set; }
    }
    
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public short Quantity { get; set; }
        public PackingMethod PackingMethod { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Profit { get; set; }
    }
}
