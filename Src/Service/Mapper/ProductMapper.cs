using Domain.Models.Product;
using Service.Dto;

namespace Service.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product a)
        {
            return new ProductDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Quantity = a.Quantity,
                PackingMethod = a.PackingMethod,
                Price = a.Price,
                Profit = a.Profit,
            };
        }

        public static Product ToModel(this ProductCreateDto a)
        {
            return new Product(a.Title, a.Quantity, a.PackingMethod, a.Description, a.Price, a.Profit);
        }
    }
}
