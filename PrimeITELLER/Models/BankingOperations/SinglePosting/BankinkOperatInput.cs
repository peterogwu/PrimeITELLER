using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations
{
    public class BankinkOperatInput
    {

        public string RequestId { get; set; }
        public string CountryId { get; set; }
        public string ReturnCode { get; set; }
        public string SourceAccountNumber{ get; set; }
        public string DestinationAccountNumber { get; set; }

        public decimal Amount { get; set; }
        public string Narration { get; set; }

        public long ClientReferenceId { get; set; }
        public string IsCustomerInduced { get; set; }

        public string InitiatorUserId { get; set; }

        public string ApproverUserId { get; set; }
    }
}