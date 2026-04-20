using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using Commissions.Data;
using Microsoft.EntityFrameworkCore;

namespace Commissions.Data.Repository
{
public sealed class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;

    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<Country>> GetAllAsync() => await _context.Countries.ToListAsync();
    public async Task<Country> GetById(Guid id) => await _context.Countries.FindAsync(id) ?? throw new Exception("Pais no encontrado.");
}
}