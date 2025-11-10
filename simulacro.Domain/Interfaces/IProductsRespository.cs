using simulacro.Application.Models;

namespace simulacro.Domain.Interfaces;

public interface IProductsRespository
{
    Task<IEnumerable<Products>> GetAllProductAsync();
    Task<Products> GetIdProductAsync(int id);
    Task<Products> AddProductAsync(Products product);
    Task<Products> UpdateProductAsync(int id, Products products);
    Task<Boolean> DeleteProductAsync(int id);

}