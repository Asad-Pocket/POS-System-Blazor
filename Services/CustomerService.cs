using BlazorCrudApp.Data;
using BlazorCrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApp.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _db;
        public CustomerService(AppDbContext db) => _db = db;

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _db.Customers.AsNoTracking().ToListAsync();
        }
        public async Task AddCustomerAsync(Customer c)
        {
            _db.Customers.Add(c);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer updatedCustomer)
        {
            var existing = await _db.Customers.FindAsync(updatedCustomer.CusID);
            if (existing == null) throw new Exception("Customer not found");
            existing.CusName = updatedCustomer.CusName;
            existing.CusBalane = updatedCustomer.CusBalane;
            existing.CusType = updatedCustomer.CusType;
            existing.CusDescription = updatedCustomer.CusDescription;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var c = await _db.Customers.FindAsync(id);
            if (c != null)
            {
                _db.Customers.Remove(c);
                await _db.SaveChangesAsync();
            }
        }

    }
}   
