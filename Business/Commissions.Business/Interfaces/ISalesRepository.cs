using Commissions.Business.Entities;
public interface ISalesRepository : IBaseRepository<Sales>
{
    Task AddAsync(Sales sale);
}