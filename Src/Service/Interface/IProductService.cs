using Service.Dto;

namespace Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> Get(int id);
        Task AddProduct(ProductCreateDto dto);
        Task DeleteProduct(int id);
        Task UpdateProduct(ProductDto dto);
    }
}
