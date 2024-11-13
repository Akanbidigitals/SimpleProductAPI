using Microsoft.AspNetCore.Mvc;
using SimpleProductAPI.DataAccess.Interface;
using SimpleProductAPI.Model.DTOs;

namespace SimpleProductAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct (ProductDto productDto)
        {
            try
            {

                var res = await _repo.AddProduct(productDto);
                return Ok(res);
            }catch(Exception ex)
            {
               return  BadRequest(ex.Message);  
            }
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById (Guid id)
        {
            try
            {
                var res = await _repo.GetProductById(id);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var res = await _repo.GetAllProducts();
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateProduct/{Id}")]
        public async Task<IActionResult> UpdateProduct ([FromBody]UpdateProductDto update,Guid Id)
        {
            try
            {
                var res = await _repo.UpdateProduct(update,Id);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct (Guid id)
        {
            try
            {
                var res = await _repo.DeleteProduct(id);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
