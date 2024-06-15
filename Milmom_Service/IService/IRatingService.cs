using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Response.Rating;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface IRatingService
{
    
    public Task<bool> AddRating(string accountId, int productId, int rating);
    public Task<RatingResponse> UpdateRatingAsync(RatingRequest rating);
    public Task<RatingResponse> DeleteRatingAsync(int ratingId);
}