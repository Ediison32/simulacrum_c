using System.Text.Json;
using simulacro.Application.Dto;
using simulacro.Application.Interfaces.Services;
using simulacro.Application.Models;
using simulacro.Domain.Interfaces;

namespace simulacro.Application.Services;

public class ProductService : IProductService
{
    // inyectar services de infrastructure

    private readonly IProductsRespository _productService;

    public ProductService(IProductsRespository productRepository)
    {
        _productService = productRepository;
    }
    
    
    public async Task<IEnumerable<ProductsDto>> GetAllProductAsync()
    {
        var product = await _productService.GetAllProductAsync();
        return product.Select(p => new ProductsDto
        {
            Id = p.Id,
            Name = p.Name,
            Cuantity = p.Cuantity,
            price = p.price,
            topy = p.topy,
            CreateProduct = p.CreateProduct
        });
    }

    public async Task<ProductsDto> GetIdProductAsync(int id)
    {
        var product = await _productService.GetIdProductAsync(id);
        if (product == null) return null;
        return new ProductsDto
        {
            Id = product.Id,
            Name = product.Name,
            Cuantity = product.Cuantity,
            price = product.price,
            topy = product.topy,
            CreateProduct = product.CreateProduct
        };
    }
    

    public async Task<ProductsDto> AddProductAsync(ProductCreateDto productDto)
    {
        var newProduct = new Products
        {
            
            Name = productDto.Name,
            Cuantity = productDto.Cuantity,
            price = productDto.price,
            topy = productDto.topy,
            CreateProduct = DateTime.Now,
            UpdateProduct = DateTime.Now
        };

        await _productService.AddProductAsync(newProduct);
        return new ProductsDto
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Cuantity = newProduct.Cuantity,
            price = newProduct.price,
            topy = newProduct.topy,
            CreateProduct = newProduct.CreateProduct
        };
    }

    public async Task<ProductsDto> UpdateProductAsync(int id, ProductUpdateDto productsDto)
    {
        var product = await _productService.GetIdProductAsync(id);
        if (product == null) return null;

        product.Name = productsDto.Name;
        product.Cuantity = productsDto.Cuantity;
        product.price = product.price;
        product.topy = product.topy;
        product.UpdateProduct = DateTime.Now;

        await _productService.UpdateProductAsync(id, product);
        
        // retronar un Dto par el usuario 

        return new ProductsDto
        {
            Id = product.Id,
            Name = product.Name,
            Cuantity = product.Cuantity,
            price = product.price,
            topy = product.topy,
            CreateProduct = product.CreateProduct
        };

    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productService.DeleteProductAsync(id);
    }
}