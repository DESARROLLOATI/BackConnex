using CONNEX.Dtos.SearchDtos;
using Microsoft.EntityFrameworkCore;

namespace CONNEX.ClassLibraries.Helpers
{
    public static class QueryableExtensions
    {

        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination) where T : class
        {
            var entityType = typeof(T);
            var deletedProperty = entityType.GetProperty("DELETED");

            if (deletedProperty != null)
            {
                queryable = queryable.Where(x => EF.Property<bool?>(x, "DELETED") == null);
            }

            if (pagination.RecordsNumber > 0)
            {
                return queryable
                    .Skip((pagination.Page - 1) * pagination.RecordsNumber)
                    .Take(pagination.RecordsNumber);
            }

            return queryable;
        }

    }
}