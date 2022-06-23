using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BvnEnqiury
{
    public class BvnEnqInput
    {

        public string RequestId { get; set; }
        public string CountryId { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
    }
}