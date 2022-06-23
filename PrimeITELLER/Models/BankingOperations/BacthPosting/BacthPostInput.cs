using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.BankingOperations.BacthPosting
{
    public class BacthPostInput
    {





        public string RequestId { get; set; }

        public string narration { get; set; }

        public string InitiatorUserId { get; set; }
        public string ApproverUserId { get; set; }

        public string ItemSequence { get; set; }

        public string AccountNumber { get; set; }

        public string PartTranType { get; set; }

        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public string ClientReferenceId { get; set; }

        public string CountryId { get; set; }

        public string IsCustomerInduced { get; set; }




        //public int menuid { get; set; }


        //public int rolelevel { get; set; }

        //public string comment { get; set; }

        //public int AuthorisationID { get; set; }

        //public string narration { get; set; }

        



    }
}