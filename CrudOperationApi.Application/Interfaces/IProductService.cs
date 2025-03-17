using CrudOperationApi.Application.DTOs;
using CrudOperationApi.Domain.Common.QueryParameters;
using CrudOperationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParameters queryParams);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto> AddProductAsync(CreateProductDto dto);
        Task<ProductDto> UpdateProductAsync(UpdateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
    }
}
