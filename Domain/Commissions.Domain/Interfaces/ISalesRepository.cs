using Commissions.Domain.Entities;

namespace Commissions.Domain.Interfaces
{
public interface ISalesRepository : IBaseRepository<Sales>
{
    Task AddAsync(Sales sale);
}
}