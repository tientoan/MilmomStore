using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Report
{
    public class ReportResponse
    {
        public int ReportID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string ReportText { get; set; }
        public string ResponseText { get; set; }

        public string AccountID { get; set; }
        
        public MilmomStore_BusinessObject.Model.AccountApplication AccountsApplication { get; set; }

        public int ProductID { get; set; }
       
        public MilmomStore_BusinessObject.Model.Product Products { get; set; }
    }
}
