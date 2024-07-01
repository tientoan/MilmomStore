﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Response.Rating;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Route("addRating")]
        public async Task<ActionResult<BaseResponse<RatingResponse>>> AddRating(CreateRatingRequest request)
        {
            return await _ratingService.AddRating(request);
        }
        [HttpPut]
        [Route("updateRating")]
        public async Task<ActionResult<BaseResponse<RatingResponse>>> UpdateRatingAsync([FromBody]UpdateRatingRequest request)
        {
            return await _ratingService.UpdateRatingAsync(request);
        }
        [HttpDelete]
        [Route("deleteRating")]
        public async Task<ActionResult<bool>> DeleteRatingAsync(int ratingId)
        {
            return await _ratingService.DeleteRatingAsync(ratingId);
        }
        [HttpGet]
        [Route("getRatingByAccountId")]
        public async Task<ActionResult<BaseResponse<IEnumerable<RatingResponse>>>> 
            GetRatingByAccountId(string accountId)
        {
            return await _ratingService.GetRatingByAccountId(accountId);
        }
    }
}