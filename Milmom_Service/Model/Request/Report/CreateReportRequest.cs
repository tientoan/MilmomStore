using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Report
{
    public class CreateReportRequest
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string ReportText { get; set; }
        public string ResponseText { get; set; }
        public string AccountID { get; set; }
        public int ProductID { get; set; }   
        
    }
}
