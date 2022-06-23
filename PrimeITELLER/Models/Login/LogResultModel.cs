using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.Login
{
    public class LogResultModel
    {

        
         public long RequestId { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Bankcode { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string MobileNo { get; set; }
        


    }
}