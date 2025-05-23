using SalesOrderApi.Models;
using SalesOrderApi.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesOrderApi.Services;

public class SalesOrderService
{
    private readonly AppDbContext _context;

    public SalesOrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalesOrder>> GetAllAsync()
    {
        return await _context.SalesOrders.Include(o => o.Items).ToListAsync();
    }

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        return await _context.SalesOrders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<SalesOrder> CreateAsync(SalesOrder order)
    {
        _context.SalesOrders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
