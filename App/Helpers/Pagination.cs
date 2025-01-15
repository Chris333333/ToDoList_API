using System.Collections.Generic;

namespace App.Helpers
{
    public class Pagination<T>(int pageNumber, int pageSize, int count, IReadOnlyList<T> data) where T : class
    {
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public int TotalCount { get; set; } = count;
        public int TotalPages { get; set; } = (int)Math.Ceiling(count / (double)pageSize);
        public IReadOnlyList<T> Data { get; set; } = data;
    }
}
