using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations.BacthPosting
{
    public class Transaction
    {
   
        public long? ItemSequence { get; set; }

        public string AccountNumber { get; set; }

        public string PartTranType { get; set; }

        public decimal? Amount { get; set; }

        public string Narration { get; set; }

        public string Currency { get; set; }
    }
}