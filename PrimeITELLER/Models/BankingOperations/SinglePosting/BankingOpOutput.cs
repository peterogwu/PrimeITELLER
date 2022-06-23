using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations
{
    public class BankingOpOutput
    {

        public long TransactionReference { get; set; }
        public string RequestId { get; set; }
        public string ResponseCode { get; set; }
       //public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        
    }
}