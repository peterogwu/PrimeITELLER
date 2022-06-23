using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.GetUserModel
{
    public class GetUserInput
    {

        public string RequestId { get; set; }
        public string CountryId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}