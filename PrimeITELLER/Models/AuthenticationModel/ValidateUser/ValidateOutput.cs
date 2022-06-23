using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.AuthenticationModel.ValidateUser
{
    public class ValidateOutput
    {
        public long RequestId { get; set; }
        //public string ResponseCode { get; set; }
        //public string ResponseMessage { get; set; }


        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Status { get; set; }
       
       
    }
}