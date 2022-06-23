using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.BalanQuiry;
using PrimeITELLER.Models.BvnEnqiury;
using PrimeITELLER.Models.CustomerModel;
using PrimeITELLER.Models.CustomerServiceModel.GetStatus;
using PrimeITELLER.Models.NameEnquiry;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace PrimeITELLER.Repository.Customer
{
    public class CustomerService : ICustomerService
    {



        private readonly Prime2Entities _db = new Prime2Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public CustomerService(Prime2Entities entity)
        {
            _db = entity;

        }



       



       
        public List<ReturnModel> BulkAAccountEQuiry(List<AccountEnQuiry> accountEnQuiry)
        {


            List<ReturnModel> AccountDetRes = new List<ReturnModel>();

            //ReturnModel ADetRes = new ReturnModel();
            foreach (AccountEnQuiry Model in accountEnQuiry)
            {

                
                List<ReturnModel> abc = new List<ReturnModel>();
                _db.Database.CommandTimeout = 900000;
                abc = _db.Database.SqlQuery<ReturnModel>("Proc_ESBAccValidation @RequestId,@AccountNumber",
                new SqlParameter("@RequestId", Model.RequestId),
                new SqlParameter("@AccountNumber", Model.AccountNumber)).ToList();
                AccountDetRes.AddRange(abc);

            }
            return (AccountDetRes);

        }







        public ReturnModel AccountEQuiry(string RequestId, string AccountNumber)

        {
            var CatList = new ReturnModel();
            try
            {
             _db.Database.CommandTimeout = 900000;
              CatList = _db.Database.SqlQuery<ReturnModel>("Proc_ESBAccValidation @RequestId,@AccountNumber",
             new SqlParameter("@RequestId", RequestId),
             new SqlParameter("@AccountNumber", AccountNumber)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public NameEnquiryOutput NameEQuiry(string RequestId, string CountryId, string AccountNumber)

        {
            var CatList = new NameEnquiryOutput();
            try
            {
             _db.Database.CommandTimeout = 900000;
              CatList = _db.Database.SqlQuery<NameEnquiryOutput>("Proc_ESBNameEnQuiry @RequestId,@CountryId,@AccountNumber",
             new SqlParameter("@RequestId", RequestId),
             new SqlParameter("@CountryId ",CountryId),
             new SqlParameter("@AccountNumber",AccountNumber)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }





        public BalQuiryOutput BalanceEQuiry(string RequestId, string CountryId, string AccountNumber)

        {
            var CatList = new BalQuiryOutput();
            try
            {
                _db.Database.CommandTimeout = 900000;
                CatList = _db.Database.SqlQuery<BalQuiryOutput>("Proc_ESBBalanceEnQuiry @RequestId,@CountryId,@AccountNumber",
               new SqlParameter("@RequestId", RequestId),
               new SqlParameter("@CountryId ", CountryId),
               new SqlParameter("@AccountNumber", AccountNumber)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }





        public BvnEnqOutput BvnEQuiry(string RequestId, string CountryId, string AccountNumber, string BankCode)

        {
            var CatList = new BvnEnqOutput();
            try
            {
             _db.Database.CommandTimeout = 900000;
             CatList = _db.Database.SqlQuery<BvnEnqOutput>("Proc_ESBBVNEnQuiry @RequestId,@CountryId,@AccountNumber,@BankCode",
             new SqlParameter("@RequestId",RequestId),
             new SqlParameter("@CountryId ", CountryId),
             new SqlParameter("@AccountNumber", AccountNumber),
             new SqlParameter("@BankCode", BankCode)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }





        public StatusOutput GetStatus(string RequestId, string CountryId, long ClientReferenceId)

        {
            var CatList = new StatusOutput();
            try
            {
                _db.Database.CommandTimeout = 900000;
                CatList = _db.Database.SqlQuery<StatusOutput>("Proc_ESBStatus @RequestId,@CountryId,@ClientReferenceId",
              new SqlParameter("@RequestId",RequestId),
              new SqlParameter("@CountryId ",CountryId),
              new SqlParameter("@ClientReferenceId", ClientReferenceId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}