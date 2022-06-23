using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations.BacthPosting
{
    public class BacthOutput
    {
        [StringLength(50)]
        public String RequestId { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string TransactionReference { get; set; }

        //public Nullable<long> TransactionReference { get; set; }

        //public decimal? TransactionReference { get; set; }



    }
}