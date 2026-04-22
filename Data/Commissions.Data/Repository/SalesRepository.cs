using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using Commissions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Commissions.Data.Repository
{
public sealed class SalesRepository : ISalesRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SalesRepository> _logger;

    public SalesRepository(ApplicationDbContext context, ILogger<SalesRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task AddAsync(Sales sale)
    {
        if (sale is null)
        {
            _logger.LogError("El objeto de venta es nulo.");
            throw new ArgumentNullException(nameof(sale));
        }

        if (sale.Total_Sales <= 0)
        {
            _logger.LogWarning("Intento de registrar una venta con ventas totales no positivas: {TotalSales}", sale.Total_Sales);
            throw new ArgumentException("Las ventas totales deben ser mayores a cero.");
        }

        if (sale.Id_Country == Guid.Empty)
        {
            _logger.LogWarning("Intento de registrar una venta sin un país especificado.");
            throw new ArgumentException("Se debe especificar un país válido.");
        }

        try 
        {
            _logger.LogInformation("Agregando una nueva venta a la base de datos.");
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Venta con ID {SaleId} agregada con éxito.", sale.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al persistir el histórico de la comisión para la venta con ID {SaleId}.", sale.Id);
            throw new Exception("Error al persistir el histórico de la comisión.", ex);
        }
    }

    public async Task<IReadOnlyList<Sales>> GetAllAsync()
    {
        _logger.LogInformation("Recuperando todas las ventas de la base de datos.");
        return await _context.Sales.ToListAsync();
    }

    public async Task<Sales> GetById(Guid id)
    {
        _logger.LogInformation("Buscando venta por ID: {SaleId}", id);
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null)
        {
            _logger.LogWarning("No se encontró una venta con ID: {SaleId}", id);
            throw new Exception("Venta no encontrada.");
        }
        return sale;
    }
}
}
