using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations.BacthPosting
{
    public class Postbatch
    {

        public string RequestId { get; set; }
  
        public int menuid { get; set; }

        public string InitiatorUserId { get; set; }
        public string ApproverUserId { get; set; }
        public int rolelevel { get; set; }

        public string comment { get; set; }

        public string AuthorisationID { get; set; }

        public string narration { get; set; }

    }
}