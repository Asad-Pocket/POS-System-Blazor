using BlazorCrudApp.Data;
using BlazorCrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApp.Services
{
    public class SalesService
    {
        private readonly AppDbContext _db;
        public SalesService(AppDbContext db) => _db = db;

        public async Task<List<Sales>> GetSalesAsync()
        {
            return await _db.Sales.AsNoTracking().ToListAsync();
        }
        public async Task AddSalesAsync(Sales s)
        {
            _db.Sales.Add(s);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateSalesAsync(Sales updatedSales)
        {
            var existing = await _db.Sales.FindAsync(updatedSales.SalesId);
            if (existing == null) throw new Exception("Sales record not found");
            existing.ProductId = updatedSales.ProductId;
            existing.CusId = updatedSales.CusId;
            existing.Quantity = updatedSales.Quantity;
            existing.SaleDate = updatedSales.SaleDate;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteSalesAsync(int id)
        {
            var salesRecord = await _db.Sales.FindAsync(id);
            if ( salesRecord != null)
            {
                _db.Sales.Remove(salesRecord);
                await _db.SaveChangesAsync();
            }
        }
    }
}