using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Specifications;

namespace core.Interfaces
{
    public interface IGenericRepository<T>  where T:BaseEntity
    {
         Task<T> GetbyIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();

         Task<T> GetEntityBySpec(ISpecification<T> spec);

         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}