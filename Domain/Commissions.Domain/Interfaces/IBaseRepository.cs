using Commissions.Domain.Entities;

namespace Commissions.Domain.Interfaces
{
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetById(Guid id);
}
}