using SimpleProductAPI.Model.Domain;
using SimpleProductAPI.Model.DTOs;

namespace SimpleProductAPI.DataAccess.Interface
{
    public interface IProductRepository
    {
        public Task<string> AddProduct(ProductDto product);
        public Task<Product> GetProductById(Guid Id);
        public Task<List<Product>>GetAllProducts();
        public Task<string>DeleteProduct(Guid Id);
        public Task<string> UpdateProduct(UpdateProductDto product, Guid id);

        
    }
}
