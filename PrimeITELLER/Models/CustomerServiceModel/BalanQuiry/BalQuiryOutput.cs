using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BalanQuiry
{
    public class BalQuiryOutput
    {


        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }

        public decimal AvailableBalance { get; set; }
        public string RequestId { get; set; }
    }
}