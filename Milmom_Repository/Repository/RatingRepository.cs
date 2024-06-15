using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using MilmomStore_DataAccessObject.BaseDAO;

namespace Milmom_Repository.Repository;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    private readonly RatingDAO _ratingDao;
    public RatingRepository(RatingDAO ratingDao) : base(ratingDao)
    {
        _ratingDao = ratingDao;
    }

    public Task<double> GetAverageRating(int productId)
    {
        return _ratingDao.GetAverageRating(productId);
    }

    public Task<Rating> UpdateRatingAsync(Rating rating)
    {
        return _ratingDao.UpdateAsync(rating);
    }

    public async Task<Rating> DeleteRatingAsync(int ratingId)
    {
         var rating = await _ratingDao.GetByIdAsync(ratingId);
         return await _ratingDao.DeleteAsync(rating);
    }
}