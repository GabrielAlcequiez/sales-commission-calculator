using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using Commissions.Data;
using Microsoft.EntityFrameworkCore;

namespace Commissions.Data.Repository
{
public sealed class SalesRepository : ISalesRepository
{
    private readonly ApplicationDbContext _context;

    public SalesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Sales sale)
    {
    if (sale == null) throw new ArgumentNullException(nameof(sale));
    
    if (sale.Total_Sales <= 0)
        throw new ArgumentException("Las ventas totales deben ser mayores a cero.");

    if (sale.Id_Country == Guid.Empty)
        throw new ArgumentException("Se debe especificar un país válido.");

    try 
    {
        await _context.Sales.AddAsync(sale);
        var result = await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        // Aquí podrías usar un logger para registrar el error en PostgreSQL
        throw new Exception("Error al persistir el histórico de la comisión.", ex);
    }
    }

    public async Task<IReadOnlyList<Sales>> GetAllAsync() => await _context.Sales.ToListAsync();

    public async Task<Sales> GetById(Guid id)=> await _context.Sales.FindAsync(id) ?? throw new Exception("Venta no encontrada.");
}
}