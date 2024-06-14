﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAppController : ControllerBase
    {
        private readonly IAccountApplicationService _userService;
        public AccountAppController(IAccountApplicationService userService)
        {
            _userService = userService;
        }
        //
        [HttpPost]
        [Route("base")]
        public async Task<ActionResult<BaseResponse<CreateNewUserResponse>>> CreateUserFromBase([FromBody] CreateNewUserRequest request)
        {
            var user = await _userService.CreateUserFromBase(request);
            return user;
        }
        //
        [HttpGet]
        [Route("base/{id}")]
        public async Task<ActionResult<BaseResponse<GetUserByIdResponse>>> GetUserByIdFromBase(int id)
        {
            return await _userService.GetUserByIdFromBase(id);
        }
        //
        [HttpGet]
        [Route("base/string/{id}")]
        public async Task<ActionResult<BaseResponse<GetUserByStringIdResponse>>> GetUserByStringIdFromBase(string id)
        {
            return await _userService.GetUserByStringIdFromBase(id);
        }
        //
        [HttpGet]
        [Route("base")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllUserResponse>>>> GetAllUserFromBase()
        {
            var users = await _userService.GetAllUserFromBase();
            return Ok(users);
        }
        //
        [HttpDelete]
        [Route("base/{id}")]
        public async Task<ActionResult<BaseResponse<DeleteUserResponse>>> DeleteUserFromBase(int id)
        {
            return await _userService.DeleteUserFromBase(id);
        }
        //
        [HttpPut]
        [Route("base/{id}")]
        public async Task<ActionResult<BaseResponse<UpdateUserResponse>>> UpdateUserFromBase(int id, [FromBody] UpdateUserRequest user)
        {
            return await _userService.UpdateUserFromBase(id, user);
        }

        [HttpPut]
        [Route("base/string/{id}")]
        public async Task<ActionResult<BaseResponse<UpdateUserResponseByString>>> UpdateUserByStringFromBase(string id, [FromBody] UpdateUserRequestByString user)
        {
            return await _userService.UpdateUserByStringFromBase(id, user);
        }
    }
}
