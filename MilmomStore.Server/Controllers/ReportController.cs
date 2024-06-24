using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Report;
using Milmom_Service.Service;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService) 
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("GetAllReports")]
        public async Task<ActionResult<BaseResponse<IEnumerable<ReportResponse>>>> GetAllReports()
        {
            var reports = await _reportService.GetAllReportFromBase();
            return Ok(reports);
        }

        [HttpGet]
        [Route("base/search")]
        public async Task<ActionResult<BaseResponse<IEnumerable<ReportResponse>>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize)
        {
            return await _reportService.GetSearchReportFromBase(search, pageIndex, pageSize);
        }

        [HttpGet]

        [Route("GetReportById/{id}")]
        public async Task<ActionResult<BaseResponse<ReportResponse>>> GetReportById(int id)
        {
            return await _reportService.GetReportByIdFromBase(id);
        }

        [HttpPost]
        [Route("CreateReport")]
        public async Task<ActionResult<BaseResponse<CreateReportRequest>>> CreateReportFromBase([FromBody] CreateReportRequest request)
        {
            var report = await _reportService.CreateReportFromBase(request);
            return report;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<BaseResponse<Report>>> DeleteProduct(int id)
        {
            var existingProduct = await _reportService.GetReportByIdFromBase(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Report not found" });
            }

            var success = await _reportService.DeleteReport(id);

            if (success == null)
            {
                return BadRequest(new { message = "Failed to delete report" });
            }

            return Ok(new { message = "Delete Report Successful" });
        }

        [HttpPut]
        [Route("UpdateReport")]
        public async Task<ActionResult<BaseResponse<UpdateReportRequest>>> UpdateReportFromBase(int id,
            [FromBody] UpdateReportRequest report)
        {
            return await _reportService.UpdateReportFromBase(id, report);
        }
    }
}
