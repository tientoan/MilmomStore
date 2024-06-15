
using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Response.Rating;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class RatingService : IRatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IOrderRepository _orderRepository;
    public RatingService(IRatingRepository ratingRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _ratingRepository = ratingRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> AddRating(string accountId, int productId, int rating)
    {
        if (!await _orderRepository.HasPurchasedProductAsync(accountId, productId))
            return false;
        var newRating = new Rating
        {
            AccountID = accountId,
            ProductID = productId,
            Rate = rating,
            CreatedAt = DateTime.Now
        };
        await _ratingRepository.AddAsync(newRating);
        return true;
    }
    public async Task<RatingResponse> UpdateRatingAsync(RatingRequest rating)
    {
        var ratingExist = await _ratingRepository.GetByIdAsync(rating.RatingID);
        _mapper.Map(rating, ratingExist);
        var updatedRating = await _ratingRepository.UpdateRatingAsync(ratingExist);
        return _mapper.Map<RatingResponse>(updatedRating);
    }
    public async Task<RatingResponse> DeleteRatingAsync(int ratingId)
    {
        var deletedRating = await _ratingRepository.DeleteRatingAsync(ratingId);
        return _mapper.Map<RatingResponse>(deletedRating);
    }
}