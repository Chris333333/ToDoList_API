using System.Collections.Generic;

namespace App.Helpers
{
    /// <summary>
    /// Class that represents pagination of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="count"></param>
    /// <param name="data"></param>
    public class Pagination<T>(int pageNumber, int pageSize, int count, IReadOnlyList<T> data) where T : class
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int PageNumber { get; set; } = pageNumber;
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; } = pageSize;
        /// <summary>
        /// Total count of data
        /// </summary>
        public int TotalCount { get; set; } = count;
        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; } = (int)Math.Ceiling(count / (double)pageSize);
        /// <summary>
        /// Data
        /// </summary>
        public IReadOnlyList<T> Data { get; set; } = data;
    }
}
