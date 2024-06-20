using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Blog
{
    public class GetBlogByIdResponse
    {
        public int BlogID { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }
    }
}
