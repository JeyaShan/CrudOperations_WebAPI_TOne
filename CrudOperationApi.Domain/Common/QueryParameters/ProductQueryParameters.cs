using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationApi.Domain.Common.QueryParameters
{
    public class ProductQueryParameters
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 0;

        private const int MaxPageSize = 50;

        private const int DefaultPageSize = 10;

        public int ValidatedPageSize
        {
            get
            {
                int size = PageSize <= 0 ? DefaultPageSize : PageSize;
                return size > MaxPageSize ? MaxPageSize : size;
            }
        }
    }
}
