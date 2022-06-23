using PrimeITELLER.Models.BalanQuiry;
using PrimeITELLER.Models.BankingOperations.BacthPosting;
using PrimeITELLER.Models.BvnEnqiury;
using PrimeITELLER.Models.CustomerModel;
using PrimeITELLER.Models.CustomerServiceModel.GetStatus;
using PrimeITELLER.Models.NameEnquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Repository
{
    public interface ICustomerService : IDisposable
    {



        List<ReturnModel> BulkAAccountEQuiry(List<AccountEnQuiry> accountEnQuiry);
        ReturnModel AccountEQuiry(string RequestId, string AccountNumber);
        NameEnquiryOutput NameEQuiry(string RequestId, string CountryId, string AccountNumber);
        BalQuiryOutput BalanceEQuiry(string RequestId, string CountryId, string AccountNumber);
        BvnEnqOutput BvnEQuiry(string RequestId, string CountryId, string AccountNumber, string BankCode);

        StatusOutput GetStatus(string RequestId, string CountryId, long ClientReferenceId);

        
    }
}