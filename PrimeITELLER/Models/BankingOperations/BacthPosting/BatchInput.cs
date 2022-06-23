using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations.BacthPosting
{
    public class BatchInput
    {
        public List<Transaction> Transactions { get; set; }
        [StringLength(50)]
        public string RequestId { get; set; }
        public string ClientReferenceId { get; set; }
        public string CountryId { get; set; }
        public string IsCustomerInduced { get; set; }
        public string InitiatorUserId { get; set; }
        public string ApproverUserId { get; set; }
    }
}