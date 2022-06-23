using PrimeITELLER.Models.BankingOperations;
using PrimeITELLER.Models.BankingOperations.BacthPosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Repository.Banking
{
    public interface  IBanking : IDisposable
    {

        BankingOpOutput FTPostTrans(BankinkOperatInput Model);
        BankingOpOutput ReversalFTPostTrans(BankinkOperatInput Model);


        //List<BacthPostOutput> BatchPosting(List<BacthPostInput> ModeInput);

        //BacthPostOutput BatchPosting(BacthPostInput Model);


    }
}