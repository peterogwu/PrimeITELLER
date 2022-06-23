using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.BankingOperations;
using PrimeITELLER.Models.BankingOperations.BacthPosting;
using PrimeITELLER.Repository.Banking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace PrimeITELLER.Controllers
{
    public class BankingOperationController : ApiController
    {

        private Prime2Entities db = new Prime2Entities();

        private IBanking _db;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BankingOperationController()
        {
            _db = new Banking(new Models.Prime2Entities());
        }

        public BankingOperationController(IBanking entity)
        {
            _db = entity;
        }





        [Route("Prime/SingleTransaction")]
        [HttpPost]
        public IHttpActionResult FTPostTrans([FromBody] BankinkOperatInput Model)
        {



            logger.Info("Account Enquiry Input with Host"
                + "and Request Id: ," + Model.RequestId + " " + "Account Number :" + Model.Amount + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new BankingOpOutput();


            try
            {

                result = _db.FTPostTrans(Model);



                logger.Info("Account Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :" + result.ResponseMessage + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Account Enquiry Endpoint Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }

            return Ok(result);
        }





        [Route("Prime/ReversalFTPostTrans")]
        [HttpPost]
        public IHttpActionResult ReversalFTPostTrans([FromBody] BankinkOperatInput Model)
        {



            logger.Info("Account Enquiry Input with Host"
                + "and Request Id: ," + Model.RequestId + " " + "Account Number :" + Model.Amount + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new BankingOpOutput();


            try
            {

                result = _db.ReversalFTPostTrans(Model);



                logger.Info("Account Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :" + result.ResponseMessage + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Account Enquiry Endpoint Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }

            return Ok(result);
        }


        //private string RandomName()
        //{
        //    return new string(
        //        Enumerable.Repeat("1234567890", 6)
        //            //Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6)
        //            .Select(s =>
        //            {
        //                var cryptoResult = new byte[4];
        //                using (var cryptoProvider = new RNGCryptoServiceProvider())
        //                    cryptoProvider.GetBytes(cryptoResult);

        //                return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
        //            })
        //            .ToArray());
        //}




        [Route("Prime/BatchPosting")]
        public IHttpActionResult BulkFTPostTrans5(BatchInput ftInput)
        {
            BacthPostOutput ftResult = new BacthPostOutput();

            List<BacthPostOutput> ftfulllist = new List<BacthPostOutput>();
            //var randomRef = RandomName();


            Random RandomClass = new Random();

            int RandomNumber;
            RandomNumber = RandomClass.Next(6, 9000000);

            //RandomNumber= idv.Trim() + RandomNumber;

            string menuid = "73";
            string rolelevel = "10";

            string rr = "0";

           //string narration = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
                foreach (var model in ftInput.Transactions)
            {
                //List<FTResult> fttemlist = new List<FTResult>();

                SqlParameter Retval = new SqlParameter("@ResponseCode", SqlDbType.VarChar, 4);
                Retval.Direction = System.Data.ParameterDirection.Output;

                SqlParameter RetMsg = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 200);
                RetMsg.Direction = System.Data.ParameterDirection.Output;

                //SqlParameter retPostseq = new SqlParameter("@retPostseq", SqlDbType.Decimal, 12);
                //retPostseq.Direction = System.Data.ParameterDirection.Output;

                db.Database.CommandTimeout = 900000;
                var AppList = db.Database.ExecuteSqlCommand("proc_ESBpostbatch @batchno, @RequestId, @Narration, @InitiatorUserId, @ApproverUserId," +
               "@ItemSequence,@AccountNumber ,@PartTranType,@Amount,@Currency,@ClientReferenceId,@CountryId,@IsCustomerInduced, @ResponseCode OUT, @ResponseMessage OUT",
               
                 new SqlParameter("@batchno", RandomNumber),
                 new SqlParameter("@RequestId", ftInput.RequestId),
                 new SqlParameter("@Narration", model.Narration),
                 new SqlParameter("@InitiatorUserId", ftInput.InitiatorUserId),
                 new SqlParameter("@ApproverUserId", ftInput.ApproverUserId),
                 new SqlParameter("@ItemSequence", model.ItemSequence),
                 new SqlParameter("@AccountNumber", model.AccountNumber),
                 new SqlParameter("@PartTranType", model.PartTranType),
                 new SqlParameter("@Amount", model.Amount),
                 new SqlParameter("@Currency", model.Currency),
                 new SqlParameter("@ClientReferenceId", ftInput.ClientReferenceId),
                 new SqlParameter("@CountryId", ftInput.CountryId),
                 new SqlParameter("@IsCustomerInduced", ftInput.IsCustomerInduced),

                Retval, RetMsg);

                //CreateReferee(Model);

                ftfulllist.Add(new BacthPostOutput
                {
                    ResponseMessage = RetMsg.Value.ToString(),
                    ResponseCode = Retval.Value.ToString(),

                    //OutPostseq = retPostseq.Value.ToString()
                });

            }

            

            BacthOutput BacthOutput = new BacthOutput();

            SqlParameter Retval22 = new SqlParameter("@retval", SqlDbType.VarChar, 100);
            Retval22.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg22 = new SqlParameter("@retmsg", SqlDbType.VarChar, 200);
            RetMsg22.Direction = System.Data.ParameterDirection.Output;

            SqlParameter @postseq = new SqlParameter("@postseq", SqlDbType.VarChar, 40);
            @postseq.Direction = System.Data.ParameterDirection.Output;
            db.Database.CommandTimeout = 900000;

            try
            {
                var App = db.Database.ExecuteSqlCommand("proc_ESBpostbatchITELLER @batchno,@RequestId,@CountryId,@narration,@userid,@authid," +
                "@menuid,@rolelevel,@comment,@AuthorisationID,@retval OUT,@retmsg OUT,@postseq OUT",
                 new SqlParameter("@batchno", RandomNumber),
                 new SqlParameter("@RequestId", ftInput.RequestId),
                 new SqlParameter("@CountryId", ftInput.CountryId),
                 new SqlParameter("@narration", ""),
                 new SqlParameter("@userid", ftInput.InitiatorUserId),
                 new SqlParameter("@authid", ftInput.ApproverUserId),
                 //new SqlParameter("@ClientReferenceId", ftInput.ClientReferenceId),
                 new SqlParameter("@menuid", menuid),
                 new SqlParameter("@rolelevel", rolelevel),
                 new SqlParameter("@comment", rr),
                 new SqlParameter("@AuthorisationID", rr),
                 Retval22, RetMsg22, postseq);

                BacthOutput.RequestId = ftInput.RequestId;
                BacthOutput.ResponseCode = Retval22.Value.ToString();
                BacthOutput.ResponseMessage = RetMsg22.Value.ToString();
                BacthOutput.TransactionReference = postseq.Value.ToString();
                //BacthOutput.RequestId = (ftInput.RequestId);
                //BacthOutput.TransactionReference = Convert.ToDecimal(postseq.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(BacthOutput);

        }


    }

}