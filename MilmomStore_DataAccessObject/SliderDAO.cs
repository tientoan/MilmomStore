using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class SliderDAO : BaseDAO<Slider>
    {
        private readonly MilmomSystemContext _context;

        public SliderDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slider>> GetSliderForHomepage()
        {
            return await _context.Slider
                .Where(p => p.Status == true)
                .ToListAsync();

        }

        public async Task<bool> DeleteSlider(Slider slider)
        {
            slider.Status = false;
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }


    }
}
