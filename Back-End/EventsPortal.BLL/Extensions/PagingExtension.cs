using System;
using System.Collections.Generic;
using System.Linq;


public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }

    public int FirstRowOnPage
    {
        get { return (CurrentPage - 1) * PageSize + 1; }
    }

    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * PageSize, RowCount); }
    }
}

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> Results { get; set; }

    public PagedResult()
    {
        Results = new List<T>();
    }
}

public static class PagingExtensions
{
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {


        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.RowCount = query.Count();
        result.PageCount = query.GetTotalPages(pageSize);



        var skip = (page - 1) * pageSize;
        result.Results = query.Skip(skip).Take(pageSize).ToList();

        return result;
    }

    public static int GetTotalPages<T>(this IQueryable<T> query, int pageSize) where T : class
    {
        var pageCount = (double)query.Count() / pageSize;
        int totalPages = (int)Math.Ceiling(pageCount);

        return totalPages;
    }

    public static List<PagedResult<T>> GetAllPaged<T>(this IQueryable<T> query, int pageSize) where T : class

    {
        var result = new List<PagedResult<T>>();
        var totalPages = query.GetTotalPages(pageSize);

        for (int i = 1; i <= totalPages; i++)
        {
            var chunk = query.GetPaged(i, pageSize);
            result.Add(chunk);
        }

        return result;
    }

}

