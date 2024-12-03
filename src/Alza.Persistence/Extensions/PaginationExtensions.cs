namespace Alza.Persistence.Extensions;

internal static class PaginationExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> ts, int pageNumber, int pageSize)
    {
        return ts.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }
}