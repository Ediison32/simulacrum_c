using simulacro.Application.Dto;
using simulacro.Application.Models;

namespace simulacro.Application.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductsDto>> GetAllProductAsync();
    Task<ProductsDto> GetIdProductAsync(int id);
    Task<ProductsDto> AddProductAsync(ProductCreateDto productDto);
    Task<ProductsDto> UpdateProductAsync(int id, ProductUpdateDto productsDto);
    Task<Boolean> DeleteProductAsync(int id);
}