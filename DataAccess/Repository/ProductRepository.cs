using Microsoft.EntityFrameworkCore;
using SimpleProductAPI.DataAccess.DataContext;
using SimpleProductAPI.DataAccess.Interface;
using SimpleProductAPI.Model.Domain;
using SimpleProductAPI.Model.DTOs;

namespace SimpleProductAPI.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ctx;
        public ProductRepository(ProductContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<string> AddProduct(ProductDto product)
        {
            try
            {
                var addproduct = new Product()
                {
                    Name = product.Name,
                    Price = product.Price
                };

                await _ctx.Products.AddAsync(addproduct);
                await _ctx.SaveChangesAsync();

                return "Product added sucessfully";

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteProduct(Guid Id)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == Id);
                if (product == null)
                {
                    throw new Exception("product does not exist");
                }
                _ctx.Products.Remove(product);
                await _ctx.SaveChangesAsync();
                return "Product deleted successfully";

                

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var products = await _ctx.Products.ToListAsync();
                if(products.Count == 0)
                {
                    throw new Exception("There is no product in the Db");
                }
                return products;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Product> GetProductById(Guid Id)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == Id);
                if(product is null)
                {
                    throw new Exception("Product does not exist");
                }
                return product;

            }catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateProduct(UpdateProductDto product)
        {
            try
            {
                var checkProduct = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                if(checkProduct is null)
                {
                    throw new Exception("Product does not exist");

                }
                checkProduct.Id = product.Id;
                checkProduct.Name = product.Name ?? checkProduct.Name;
                checkProduct.Price = product.Price ?? checkProduct.Price;

                _ctx.Products.Update(checkProduct);
                await _ctx.SaveChangesAsync();

                return "Product updated successfully";

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
