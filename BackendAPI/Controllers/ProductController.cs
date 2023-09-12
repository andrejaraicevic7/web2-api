using BackendAPI.DTO;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "shopper")]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("sellerProducts")]
        [Authorize(Roles = "seller")]
        public IActionResult GetProductsForSeller(string sellerId)
        {
            return Ok(_productService.GetSellerProducts(sellerId));
        }

        [HttpPost("new")]
        [Authorize(Roles = "seller")]
        public IActionResult AddProduct(ProductDto productDto)
        {
            try
            {
                _productService.AddProduct(productDto);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("delete")]
        [Authorize(Roles = "seller")]
        public IActionResult RemoveProduct(ProductDto productDto)
        {
            _productService.RemoveProduct(productDto);
            return Ok();
        }
    }
}
