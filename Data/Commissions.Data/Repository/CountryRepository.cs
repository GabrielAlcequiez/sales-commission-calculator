using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using Commissions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Commissions.Data.Repository
{
public sealed class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CountryRepository> _logger;

    public CountryRepository(ApplicationDbContext context, ILogger<CountryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IReadOnlyList<Country>> GetAllAsync()
    {
        _logger.LogInformation("Obteniendo todos los países.");
        return await _context.Countries.ToListAsync();
    }
    public async Task<Country> GetById(Guid id)
    {
        _logger.LogInformation("Buscando país por ID: {CountryId}", id);
        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            _logger.LogWarning("País con ID {CountryId} no encontrado.", id);
            throw new Exception("País no encontrado.");
        }
        return country;
    }
}
}
