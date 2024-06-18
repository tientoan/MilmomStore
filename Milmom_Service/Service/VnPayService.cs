﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Milmom_Service.IService;
using Milmom_Service.Model.Request.VnPayModel;
using Milmom_Service.Model.Response.VNPayModel;
using Milmom_Service.Model.VNPay;

namespace Milmom_Service.Service;

public class VnPayService : IVnPayService
{
    private readonly IConfiguration _configuration;
    public VnPayService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreatePaymentUrl(HttpContext context, VnPayRequestModel requestModel)
    {
        var tick = DateTime.Now.Ticks.ToString();
        var vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", _configuration["VnPay:Version"]);
        vnpay.AddRequestData("vnp_Command", _configuration["VnPay:Command"]);
        vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
        vnpay.AddRequestData("vnp_Amount", (requestModel.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không 
        //mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND 
            //(một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY 
        //là: 10000000

        vnpay.AddRequestData("vnp_CreateDate", requestModel.CreatedDate.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", _configuration["VnPay:Currency"]);
        vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
        vnpay.AddRequestData("vnp_Locale", _configuration["VnPay:Locale"]);
        //
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan cho don hang:" + requestModel.OrderId);
        vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
        vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:PaymentBackReturnUrl"]);
        vnpay.AddRequestData("vnp_TxnRef", $"{requestModel.OrderId}-{tick}");
        var paymentUrl = vnpay.CreateRequestUrl(_configuration["VnPay:BaseUrl"], 
            _configuration["VnPay:HashSecret"]);
        return paymentUrl;
    }

    public VnPaymentResponseModel PaymentExecute(IQueryCollection collections)
    {
        var vnpay = new VnPayLibrary();
        foreach (var (key, value) in collections)
        {
            if(string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }
        var vnp_orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
        var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
        var vnp_SecureHash = collections.FirstOrDefault(x => x.Key == "vnp_SecureHash").Value;
        var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
        var vnp_OrderInfor = vnpay.GetResponseData("vnp_OrderInfor");
        bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _configuration["VnPay:HashSecret"]);
        if (!checkSignature)
        {
            return new VnPaymentResponseModel
            {
                Success = false
            };
        }

        return new VnPaymentResponseModel
        {
            Success = true,
            PaymentMethod = "VnPay",
            OrderDescription = vnp_OrderInfor,
            OrderId = vnp_orderId.ToString(),
            TransactionId = vnp_TransactionId.ToString(),
            Token = vnp_SecureHash,
            VnPayResponseCode = vnp_ResponseCode.ToString()
        };
    }
}