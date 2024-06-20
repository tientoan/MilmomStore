using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Slider
{
    public class GetSliderByIdResponse
    {
        public int SliderID { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }

    }
}
