using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.CustomerServiceModel.GetStatus
{
    public class StatusInput
    {
        public string  RequestId { get; set; }
        public string CountryId { get; set; }
        public long ClientReferenceId { get; set; }
    }
}