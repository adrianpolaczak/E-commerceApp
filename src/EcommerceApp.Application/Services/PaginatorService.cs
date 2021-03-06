using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Application.Interfaces;
using EcommerceApp.Application.ViewModels;

namespace EcommerceApp.Application.Services
{
    public class PaginatorService<T> : IPaginatorService<T>
    {
        public async Task<PaginatedVM<T>> CreateAsync(IQueryable<T> source, int currentPage, int pageSize)
        {
            var count = await source.ToAsyncEnumerable().CountAsync();
            source = source.OrderBy(x => "Id").Skip((currentPage - 1) * pageSize).Take(pageSize);
            List<T> items;
            var totalPages = 1;
            if (count == 0)
            {
                items = new List<T>();
            }
            else
            {
                items = await source.ToAsyncEnumerable().ToListAsync();
                totalPages = (int)Math.Ceiling(count / (double)pageSize);
            }

            return new PaginatedVM<T>
            {
                CurrentPage = currentPage,
                Items = items,
                PageSize = pageSize,
                TotalCount = items.Count,
                TotalPages = totalPages
            };
        }
    }
}
