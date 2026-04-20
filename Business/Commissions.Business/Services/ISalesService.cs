using Commissions.Business.Entities;

namespace Commissions.Business.Services
{
    public interface ISalesService
    {
        Task<Sales> CreateSaleAsync(Sales sale);
        Task<IReadOnlyList<Sales>> GetAllSalesAsync();
        Task<Sales> GetSaleByIdAsync(Guid id);
    }
}