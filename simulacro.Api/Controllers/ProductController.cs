using Microsoft.AspNetCore.Mvc;
using simulacro.Application.Dto;
using simulacro.Application.Interfaces.Services;

namespace simulacro.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<ProductsDto>>> GetAllProduct()
    {
        var resul = await _productService.GetAllProductAsync();
        return Ok(resul);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductsDto>> GetIdproduct(int id)
    {
        var result = await _productService.GetIdProductAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteProduct(int id)
    {
        var resul = await _productService.DeleteProductAsync(id);
        return Ok(resul);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ProductsDto>> Create(ProductCreateDto productDto)
    {
        var result = await _productService.AddProductAsync(productDto);
        return Ok(result);
    }


}