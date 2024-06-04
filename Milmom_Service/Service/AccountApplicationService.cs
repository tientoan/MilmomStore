﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.Enums;
using Milmom_Repository.IRepository;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service
{
    public class AccountApplicationService : IAccountApplicationService
    {
        
        private readonly IMapper _mapper;
        private readonly IAccountAppRepository _accountAppRepository;
        public AccountApplicationService(IMapper mapper, IAccountAppRepository accountAppRepository)
        {
            _mapper = mapper;
            _accountAppRepository = accountAppRepository;
        }


        public async Task<BaseResponse<IEnumerable<GetAllUserResponse>>> GetAllUserFromBase()
        {
            IEnumerable<AccountApplication> users = await _accountAppRepository.GetAllAsync();
            var user = _mapper.Map<IEnumerable<GetAllUserResponse>>(users);
            return new BaseResponse<IEnumerable<GetAllUserResponse>>("Get all user as base success",
                StatusCodeEnum.OK_200, user);

        }

        public async Task<BaseResponse<GetUserByIdResponse>> GetUserByIdFromBase(int id)
        {
            AccountApplication user = await _accountAppRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return new BaseResponse<GetUserByIdResponse>("Get user by id as base success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<UpdateUserResponse>> UpdateUserFromBase(int id, UpdateUserRequest request)
        {
            AccountApplication user = await _accountAppRepository.GetByIdAsync(id);
            _mapper.Map(request, user);
            await _accountAppRepository.UpdateAsync(user);
            
            var result = _mapper.Map<UpdateUserResponse>(user);
            return new BaseResponse<UpdateUserResponse>("Update user as base success", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<DeleteUserResponse>> DeleteUserFromBase(int id)
        {
            AccountApplication user = await _accountAppRepository.GetByIdAsync(id);
            await _accountAppRepository.DeleteAsync(user);
            
            var result = _mapper.Map<DeleteUserResponse>(user);
            return new BaseResponse<DeleteUserResponse>("Delete user as base success", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<CreateNewUserResponse>> CreateUserFromBase(CreateNewUserRequest request)
        {
            AccountApplication user = _mapper.Map<AccountApplication>(request);
            await _accountAppRepository.AddAsync(user);
            
            var response = _mapper.Map<CreateNewUserResponse>(user);
            return new BaseResponse<CreateNewUserResponse>("Create user as base success", StatusCodeEnum.Created_201, response);
        
        }
    }
}
