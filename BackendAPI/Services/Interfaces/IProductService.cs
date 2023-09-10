using BackendAPI.DTO;

namespace BackendAPI.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDto productDTO);
        void RemoveProduct(ProductDto productDTO);
        List<ProductDto> GetProducts();
        List<ProductDto> GetSellerProducts(string sellerId);
    }
}
