using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Blog
{
    public class GetBlogForManageResponse
    {
        public int BlogID { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
