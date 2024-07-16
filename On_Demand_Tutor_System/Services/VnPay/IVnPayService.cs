using BusinessObjects.DTO.VnPayModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VnPay
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(string ipAddress, VnPaymentRequestModel model);
        VnPaymentResponseModel PaymentResponse(IQueryCollection collection);
    }
}
