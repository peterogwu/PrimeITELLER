using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.CustomerServiceModel.GetStatus
{
    public class StatusOutput
    {

      
        public long TransactionReference { get; set; }
        public string RequestId { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}