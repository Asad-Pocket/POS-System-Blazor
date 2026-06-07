
using BlazorCrudApp.Data;
using BlazorCrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApp.Services;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db) => _db = db;

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _db.Products.AsNoTracking().ToListAsync();
    }

    public async Task AddProductAsync(Product p)
    {
        _db.Products.Add(p);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product updatedProduct)
    {
        var existing = await  _db.Products.FindAsync(updatedProduct.Id);
        if (existing == null) throw new Exception("Product not found");

        existing.Name = updatedProduct.Name;
        existing.Description = updatedProduct.Description;
        existing.Price = updatedProduct.Price;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p != null)
        {
            _db.Products.Remove(p);
            await _db.SaveChangesAsync();
        }
    }


}