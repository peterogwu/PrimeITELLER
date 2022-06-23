using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BvnEnqiury
{
    public class BvnEnqOutput
    {


        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string AccountName { get; set; }

        public string BVN { get; set; }
        public string RequestId { get; set; }
    }
}