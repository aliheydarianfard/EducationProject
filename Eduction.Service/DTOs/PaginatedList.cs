﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.Service.DTOs
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int PageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get {
                return (PageIndex > 1);
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex > TotalPage);
            }
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int PageIndex, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new PaginatedList<T>(items,count,PageIndex,PageSize);
        }

    }
}
