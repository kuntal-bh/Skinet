using System.Linq;
using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace core.Specifications
{
    public class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> AddSpecification(IQueryable<T> inputQuery , ISpecification<T> spec) {
            var query = inputQuery;
            if(spec.Criteria!=null) {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;

        }
    }
}