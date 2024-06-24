using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Report
{
    public class UpdateReportRequest
    {
        public string ReportText { get; set; }
        public string ResponseText { get; set; }
        public string AccountID { get; set; }
        public int ProductID { get; set; }
    }
}
