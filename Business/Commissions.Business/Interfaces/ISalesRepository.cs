using Commissions.Business.Entities;

namespace Commissions.Business.Interfaces
{
public interface ISalesRepository : IBaseRepository<Sales>
{
    Task AddAsync(Sales sale);
}
}