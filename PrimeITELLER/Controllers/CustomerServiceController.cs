using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.BalanQuiry;
using PrimeITELLER.Models.BvnEnqiury;
using PrimeITELLER.Models.CustomerModel;
using PrimeITELLER.Models.CustomerServiceModel.GetStatus;
using PrimeITELLER.Models.NameEnquiry;
using PrimeITELLER.Repository;
using PrimeITELLER.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PrimeITELLER.Controllers
{
    public class CustomerServiceController : ApiController
    {

        private Prime2Entities db = new Prime2Entities();

        private ICustomerService _db;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CustomerServiceController()
        {
            _db = new CustomerService(new Models.Prime2Entities());
        }

        public CustomerServiceController(ICustomerService entity)
        {
            _db = entity;
        }



        [Route("Prime/BulkAccountEQuiry")]
        [HttpPost]
      public IHttpActionResult BulkAAccountEQuiry([FromBody]List<AccountEnQuiry> accountEnQuiry)
        {

            //logger.Info("BulkAAccount nquiry Input with Host"
            //   + "and Request Id: ," + Modelinput.RequestId + " " + "Account Number :" + Model.AccountNumber + DateTime.Now);

            var result = new List<ReturnModel>();

            try
            {
                result = _db.BulkAAccountEQuiry(accountEnQuiry);

                //logger.Info("Account Enquiry Endpoint Result" + ("Response Code :," + result.).ToString() + "Response Message :" + result.ResponseMessage + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Account Enquiry Endpoint Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }
     
         return Ok(result);
        }









        [Route("Prime/AccountEnquiry")]
        //[ResponseType(typeof(ReturnModel))]
        [HttpGet]
        public IHttpActionResult AccountEQuiry(string RequestId, string AccountNumber)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Account Enquiry Input with Host" 
                + "and Request Id: ," +RequestId + " " + "Account Number :" + AccountNumber + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = new ReturnModel();
            try
            {

                result = _db.AccountEQuiry(RequestId, AccountNumber);
                logger.Info("Account Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :" + result.ResponseMessage + DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Account Enquiry Endpoint Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }

            if (result.ResponseCode == "1")
            {
                return Ok(result);
            }
            else
            {
                result.ResponseCode = result.ResponseCode;
            }

            return Ok(result);
        }





        [Route("Prime/NameEnquiry")]
        //[ResponseType(typeof(NameEnquiryOutput))]
        [HttpGet]
        public IHttpActionResult NameEQuiry(string RequestId, string CountryId, string AccountNumber)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Name Enquiry Input with Host"
                + "and Request Id: ," + RequestId + " " + "Country Code :," +CountryId +"" + "Acc. Number :" + AccountNumber+ DateTime.Now);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = new NameEnquiryOutput();
            try
            {

                result = _db.NameEQuiry(RequestId, CountryId, AccountNumber);
                logger.Info("Name Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "Acc. Number:," + result.AccountNumber + "Acc. tName:," + result.AccountName + "RequestId:" + result.RequestId + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Name Enquiry  Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }
            if (result.ResponseCode == "00")
            {
                return Ok(result);
            }
            else
            {
                result.ResponseCode = result.ResponseCode;
            }

            return Ok(result);
        }







        [Route("Prime/BalanceEnquiry")]
        //[ResponseType(typeof(BalQuiryOutput))]
        [HttpGet]
        public IHttpActionResult BalanceEQuiry(string RequestId, string CountryId, string AccountNumber)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Balance Enquiry Input with Host"
                + "and Request Id: ," +RequestId + " " + "Country Code :," +CountryId + "" + "Acc. Number :" + AccountNumber + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var result = new BalQuiryOutput();
            try
            {
                result = _db.BalanceEQuiry( RequestId,CountryId,AccountNumber);
                logger.Info("Balance Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "Acc. Number:," + result.AccountNumber + "Acc. tName:," + result.AccountName  +"Balance:," + result.AvailableBalance + "RequestId:" + result.RequestId + DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Balance Enquiry  Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }



            //if (result.ResponseCode == "00")
            //{
            //    return Ok(result);

            //}
            //else
            //{
            //    result.ResponseCode = result.ResponseCode;
            //}

            return Ok(result);
        }





      


        [Route("Prime/BvnEnquiry")]
        //[ResponseType(typeof(BvnEnqOutput))]
        [HttpGet]
        public IHttpActionResult BvnEQuiry(string RequestId, string CountryId, string AccountNumber, string BankCode)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");
            logger.Info("Bvn Enquiry Input with Host"
                + "and Request Id: ," +RequestId + " " + "Country Code :," + CountryId + "" + "Acc. Number :," + AccountNumber + "Bank Code :" + BankCode + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = new BvnEnqOutput();
            try
            {
                result = _db.BvnEQuiry(RequestId,CountryId,AccountNumber,BankCode);
                logger.Info("Bvn Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "BVN :," + result.BVN + "Acc. Name:," + result.AccountName + "RequestId:" + result.RequestId + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Bvn Enquiry  Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }



            //if (result.ResponseCode == "00")
            //{
            //    return Ok(result);

            //}
            //else
            //{
            //    result.ResponseCode = result.ResponseCode;
            //}

            return Ok(result);
        }


        


      [Route("Prime/GetTransactionStatus")]
        [HttpGet]
        public IHttpActionResult GetStatus(string RequestId, string CountryId, long ClientReferenceId)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Get Status  Input with Host"
                + "and Request Id: ," + RequestId + " " + "Country Code :," + CountryId + "" + "ClientReferenceId :," + ClientReferenceId + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new StatusOutput();
            try
            {
                result = _db.GetStatus( RequestId,  CountryId,  ClientReferenceId);
                logger.Info("Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "requestid :," + result.RequestId + "TransactionReference:," + result.TransactionReference  + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Get Status  Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }



            //if (result.ResponseCode == "00")
            //{
            //    return Ok(result);

            //}
            //else
            //{
            //    result.ResponseCode = result.ResponseCode;
            //}

            return Ok(result);
        }

    }
}