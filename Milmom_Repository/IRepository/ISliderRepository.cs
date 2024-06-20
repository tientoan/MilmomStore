using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IRepository
{
    public interface ISliderRepository:IBaseRepository<Slider>
    {
        public Task<IEnumerable<Slider>> GetSliderForHomePage();
        public Task<bool> DeleteSlider(Slider slider);
    }
}
