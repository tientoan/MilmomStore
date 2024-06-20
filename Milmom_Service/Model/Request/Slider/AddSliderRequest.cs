using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Slider
{
    public class AddSliderRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Link { get; set; }

        public DateTime CreateAt { get; set; } 

        public DateTime UpdateAt { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public bool Status { get; set; }
    }
}
