using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
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

        public async Task<BaseResponse<Product>> DeleteProduct(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return new BaseResponse<Product>("Product not found", StatusCodeEnum.NotFound_404, null);
            }
            var result = await _productRepository.DeleteProduct(existingProduct);
            if(result == 0)
            {
                return new BaseResponse<Product>("Failed to delete product", StatusCodeEnum.BadRequest_400, existingProduct);
            }
            return new BaseResponse<Product>("Product deleted successfully", StatusCodeEnum.OK_200, existingProduct);
        }

        public async Task<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>> GetAllProductsFromBase()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            var product = _mapper.Map<IEnumerable<GetAllProductsForManagerResponse>>(products);
            return new BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>("Get all product as base success",
                StatusCodeEnum.OK_200, product);
        }

        public async Task<BaseResponse<GetProductDetailForHP>> GetProductByIdFromBase(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductDetailForHP>(product);
            return new BaseResponse<GetProductDetailForHP>("Get product details success", StatusCodeEnum.OK_200,
                result);
        }

<<<<<<< Updated upstream
        public async Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductDetailsResponse>(product);
            return new BaseResponse<GetProductDetailsResponse>("Get product by id as base success", StatusCodeEnum.OK_200,
                result);
=======
        public async Task<BaseResponse<UpdateProductRequest>> UpdateProductFromBase(int id, UpdateProductRequest request)
        {
            Product existingProduct = await _productRepository.GetByIdAsync(id);
            _mapper.Map(request, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);

            var result = _mapper.Map<UpdateProductRequest>(existingProduct);
            return new BaseResponse<UpdateProductRequest>("Update user as base success", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<IEnumerable<ViewProductHomePageResponse>>> ViewProductHomePage()
        {
            IEnumerable<Product> products = await _productRepository.ViewProductForHomePage();
            var product = _mapper.Map<IEnumerable<ViewProductHomePageResponse>>(products);
            return new BaseResponse<IEnumerable<ViewProductHomePageResponse>>("Get all product for home page success",
                StatusCodeEnum.OK_200, product);
>>>>>>> Stashed changes
        }
    }
}
