using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Milmom_Service.IService;
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
        [Route("addRating/{accountId}")]
        public async Task<ActionResult<bool>> AddRating(string accountId, int productId, int rating)
        {
            return await _ratingService.AddRating(accountId, productId, rating);
        }
        [HttpPost]
        [Route("updateRating")]
        public async Task<ActionResult<RatingResponse>> UpdateRatingAsync(RatingRequest rating)
        {
            return await _ratingService.UpdateRatingAsync(rating);
        }
        [HttpDelete]
        [Route("deleteRating")]
        public async Task<ActionResult<RatingResponse>> DeleteRatingAsync(int ratingId)
        {
            return await _ratingService.DeleteRatingAsync(ratingId);
        }
    }
}