using CrudOperationApi.Application.DTOs;
using CrudOperationApi.Application.Interfaces;
using CrudOperationApi.Domain.Entities;
using CrudOperationApi.Domain.Interfaces;
using CrudOperationApi.Domain.Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CrudOperationApi.Application.Services
{
    public  class ProductService : IProductService
    {
       
            private readonly IProductRepository _productRepository;

            public ProductService(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParameters queryParams)
            {
                 var products = await _productRepository.GetAllProductsAsync(queryParams);

                 var productDtos = products.Select(p => new ProductDto
                 {
                  Id = p.Id,
                  Name = p.Name,
                  Description = p.Description,
                  Price = p.Price,
                  StockQuantity =p.StockQuantity,
                  Category = p.Category,
                 });

                 return productDtos;
            }

            public async Task<ProductDto?> GetProductByIdAsync(int id)
            {
                var product= await _productRepository.GetProductByIdAsync(id);
             if (product == null)
                return null;

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,

            };
               return productDto;
                
            }

            public async Task<ProductDto> AddProductAsync(CreateProductDto dto)
            {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Category = dto.Category,
            };
                await _productRepository.AddProductAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
            };
            }

            public async Task<ProductDto> UpdateProductAsync(UpdateProductDto dto)
            {
               var product = new Product
               {
                Id= dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Category = dto.Category,
                };
                await _productRepository.UpdateProductAsync(product);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
            };
        }

            public async Task<bool> DeleteProductAsync(int id)
            {
                return await _productRepository.DeleteProductAsync(id);
            }
        
    }
}
