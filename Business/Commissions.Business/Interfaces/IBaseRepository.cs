using Commissions.Business.Entities;

namespace Commissions.Business.Interfaces
{
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetById(Guid id);
}
}