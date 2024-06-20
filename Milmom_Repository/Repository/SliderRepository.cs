using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.Repository
{
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        private readonly SliderDAO _sliderDao;

        public SliderRepository(SliderDAO sliderDao) : base(sliderDao)
        {
            _sliderDao = sliderDao;
        }

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _sliderDao.GetAllAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            return await _sliderDao.GetByIdAsync(id);
        }

        public async Task<Slider> GetByStringIdAsync(string id)
        {
            return await _sliderDao.GetByStringIdAsync(id);
        }

        public async Task<Slider> AddAsync(Slider entity)
        {
            return await _sliderDao.AddAsync(entity);
        }

        public async Task<Slider> UpdateAsync(Slider entity)
        {
            return await _sliderDao.UpdateAsync(entity);
        }

        public async Task<Slider> DeleteAsync(Slider entity)
        {
            return await _sliderDao.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Slider>> GetSliderForHomePage()
        {
            return await _sliderDao.GetSliderForHomepage();
        }

        public async Task<bool> DeleteSlider(Slider slider)
        {
            return await _sliderDao.DeleteSlider(slider);
        }
    }
}
