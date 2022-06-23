using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.CustomerModel
{
    public class ReturnModel
    {

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        //public long customerid { get; set; }
        public string RequestId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string ProductCode { get; set; }
        public string Product { get; set; }
        public string CurrencyCode { get; set; }
        public string BranchName { get; set; }
        public string AccountStatus { get; set; }
        public Decimal BookBalance { get; set; }
        public int LienAmount { get; set; }
        public string UnclearedBalance { get; set; }
        public string MobileNo { get; set; }
    }

       
    }
