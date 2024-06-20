﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Blog
{
    public class UpdateBlogRequest
    {
        
        public string Title { get; set; }

        public string Image { get; set; }
        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
