using Microsoft.AspNetCore.Mvc;
using Price_Comparison.DTOs;
using Price_Comparison.Services;

namespace Price_Comparison.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromServices] IBlobStorageService blobService)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded.");
            var url = await blobService.UploadFileAsync(file, "product-images");
            return Ok(new { imageUrl = url });
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody]SearchObjectDto dto)
        {
           var result = _productService.SearchProduct(dto);
            return Ok(result);
        }

    }
}
