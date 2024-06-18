using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Milmom_Service.Model.Request.AccountApplication;
<<<<<<< Updated upstream
=======
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Rating;
>>>>>>> Stashed changes
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Cart;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Product;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateNewUserRequest, AccountApplication>().ReverseMap();
            CreateMap<AccountApplication, CreateNewUserResponse>().ReverseMap();
            CreateMap<AccountApplication, GetAllUserResponse>();
            CreateMap<AccountApplication, GetUserByIdResponse>();
            CreateMap<AccountApplication, GetUserByStringIdResponse>();
            CreateMap<AccountApplication, DeleteUserResponse>();
            CreateMap<AccountApplication, UpdateUserResponse>();
            CreateMap<UpdateUserRequest, AccountApplication>().ReverseMap();
            CreateMap<AccountApplication, UpdateUserResponseByString>();
            CreateMap<UpdateUserRequestByString, AccountApplication>().ReverseMap();
            CreateMap<Product, GetAllProductsResponse>();
            CreateMap<Product, GetProductByIdResponse>();
            CreateMap<Product, GetSearchProductResponse>();
            CreateMap<Product, GetFilterProductResponse>();
            CreateMap<ImageProduct, GetAllImageProductsResponse>();
<<<<<<< Updated upstream
=======
            CreateMap<Product, ViewProductHomePageResponse>();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>();
            CreateMap<AddProductRequest, Product>().ReverseMap();
            CreateMap<Product, AddProductRequest>();
            CreateMap<Product, GetFilterProductResponse>();
            CreateMap<Product, GetSearchProductResponse>();

            CreateMap<Category, GetAllCategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();

            //
            CreateMap<Rating, GetRatingResponse>();

            //

>>>>>>> Stashed changes
            CreateMap<Cart, CartResponse>();
            CreateMap<CartItem, CartItemResponse>();
        }
    }
}
