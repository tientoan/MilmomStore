using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Repository.IRepository;

public interface IRatingRepository : IBaseRepository<Rating>
{
    public Task<double> GetAverageRating(int productId);
    public Task<Rating> UpdateRatingAsync(Rating rating);
    //public Task<Rating> GetRatingAsync(string accountId, int productId);
    public Task<Rating> DeleteRatingAsync(int ratingId);
}