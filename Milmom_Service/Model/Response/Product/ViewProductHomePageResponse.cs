﻿using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class ViewProductHomePageResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        //thieu rating voi image
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

        public ICollection<GetRatingResponse> Rating { get; set; }
        public double AverageRating { get; set; }

    }
}
