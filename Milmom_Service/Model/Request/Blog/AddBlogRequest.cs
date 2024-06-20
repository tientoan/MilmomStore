using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Blog
{
    public class AddBlogRequest
    {
        
        public string AccountID { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
