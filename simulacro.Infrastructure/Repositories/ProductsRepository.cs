using Microsoft.EntityFrameworkCore;
using simulacro.Application.Models;
using simulacro.Domain.Interfaces;
using simulacro.Infrastructure.Data;

namespace simulacro.Infrastructure.Repositories;

public class ProductsRepository : IProductsRespository
{
    
    // inicializar la db 
    private readonly AppDbContext _context;

    public ProductsRepository(AppDbContext context)
    {
        _context = context;
    }
        
        
        
    public async Task<IEnumerable<Products>> GetAllProductAsync()
    {
        try
        {
            return await _context.products.ToListAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Products> GetIdProductAsync(int id)
    {
        try
        {
            var productId = await _context.products.FindAsync(id);
            if (productId == null) return null;

            return productId; 
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Products> AddProductAsync(Products products)
    {
        try
        {
            var productid = await _context.products.FindAsync(products.Id);
            if (productid != null) return null;

            _context.products.AddAsync(products);
            await _context.SaveChangesAsync();
            return productid;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Products> UpdateProductAsync(int id, Products products)
    {
        try
        {
            var producid = await _context.products.FindAsync(products.Id);
            if (producid == null) return null;

            producid.Name = products.Name;
            producid.price = products.price;
            producid.Cuantity = products.Cuantity;
            producid.topy = products.topy;
            producid.UpdateProduct = products.UpdateProduct;
            await _context.SaveChangesAsync();

            return producid;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Boolean> DeleteProductAsync(int id)
    {
        try
        {
            var producid = await _context.products.FindAsync(id);
            if (producid == null) return false;

            _context.Remove(producid);
            await _context.SaveChangesAsync();
            return true;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}