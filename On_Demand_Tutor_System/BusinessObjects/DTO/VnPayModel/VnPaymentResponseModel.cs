using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.VnPayModel
{
    public class VnPaymentResponseModel
    {
        public bool Status { get; set; }
        public string ResponseCode { get; set; }
        public string Description { get; set; }
        public string TransactionId { get; set; }
    }
}
