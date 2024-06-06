using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<BaseResponse<IEnumerable<GetAllProductsResponse>>> GetAllProductsFromBase()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            var product = _mapper.Map<IEnumerable<GetAllProductsResponse>>(products);
            return new BaseResponse<IEnumerable<GetAllProductsResponse>>("Get all product as base success",
                StatusCodeEnum.OK_200, product);
        }

        public async Task<BaseResponse<GetProductByIdResponse>> GetProductByIdFromBase(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductByIdResponse>(product);
            return new BaseResponse<GetProductByIdResponse>("Get product by id as base success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductDetailsResponse>(product);
            return new BaseResponse<GetProductDetailsResponse>("Get product by id as base success", StatusCodeEnum.OK_200,
                result);
        }
    }
}
