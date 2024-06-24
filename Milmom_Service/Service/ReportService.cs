using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Report;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        public ReportService(IMapper mapper, IReportRepository reportRepository) 
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<BaseResponse<CreateReportRequest>> CreateReportFromBase(CreateReportRequest request)
        {
            Report report = _mapper.Map<Report>(request);
            await _reportRepository.AddAsync(report);

            var response = _mapper.Map<CreateReportRequest>(report);
            return new BaseResponse<CreateReportRequest>("Create Report as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<Report> DeleteReport(int id)
        {
            var reportExist = await _reportRepository.GetReportByIdAsync(id);
            return await _reportRepository.DeleteAsync(reportExist);
        }

        public async Task<BaseResponse<IEnumerable<ReportResponse>>> GetAllReportFromBase()
        {
            IEnumerable<Report> reports = await _reportRepository.GetAllReportsAsync();
            var report = _mapper.Map<IEnumerable<ReportResponse>>(reports);
            return new BaseResponse<IEnumerable<ReportResponse>>("Get all Reports as base success",
                StatusCodeEnum.OK_200, report);
        }

        public async Task<BaseResponse<ReportResponse>> GetReportByIdFromBase(int id)
        {
            Report report = await _reportRepository.GetReportByIdAsync(id);
            var result = _mapper.Map<ReportResponse>(report);
            return new BaseResponse<ReportResponse>("Get Report details success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<IEnumerable<ReportResponse>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize)
        {
            IEnumerable<Report> reports = await _reportRepository.SearchReportAsync(search, pageIndex, pageSize);
            var report = _mapper.Map<IEnumerable<ReportResponse>>(reports);
            return new BaseResponse<IEnumerable<ReportResponse>>("Get search Report as base success",
                StatusCodeEnum.OK_200, report);
        }

        public async Task<BaseResponse<UpdateReportRequest>> UpdateReportFromBase(int id, UpdateReportRequest report)
        {
            Report existingReport = await _reportRepository.GetReportByIdAsync(id);
            _mapper.Map(report, existingReport);
             await _reportRepository.UpdateAsync(existingReport);

            var result = _mapper.Map<UpdateReportRequest>(existingReport);
            return new BaseResponse<UpdateReportRequest>("Update Report as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
