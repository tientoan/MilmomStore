using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Cart;
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
            CreateMap<ImageProduct, GetAllImageProductsResponse>();
            CreateMap<Cart, CartResponse>();
            CreateMap<CartItem, CartItemResponse>();
        }
    }
}
