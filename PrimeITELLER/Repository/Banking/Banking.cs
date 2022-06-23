using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.BankingOperations;
using PrimeITELLER.Models.BankingOperations.BacthPosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Repository.Banking
{
    public class Banking : IBanking
    {


        private readonly Prime2Entities _db = new Prime2Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Banking(Prime2Entities entity)
        {
            _db = entity;

        }


        



        public BankingOpOutput FTPostTrans(BankinkOperatInput Model)
        {

            var retVal = new BankingOpOutput();
            SqlParameter Retval2 = new SqlParameter("@ResponseCode", SqlDbType.VarChar, 200);
            Retval2.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg2 = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 200);
            RetMsg2.Direction = System.Data.ParameterDirection.Output;

            SqlParameter retPostseq2 = new SqlParameter("@TransactionReference", SqlDbType.Decimal, 12);
            retPostseq2.Direction = System.Data.ParameterDirection.Output;
            try
            {
                _db.Database.CommandTimeout = 900000;
                var AppList = _db.Database.ExecuteSqlCommand("proc_ESBFTPostITELLER @RequestId, @CountryId, @SourceAccountNumber, @DestinationAccountNumber," +
                "@Amount,@Narration,@ClientReferenceId ,@IsCustomerInduced,@InitiatorUserId,@ApproverUserId, @ResponseCode OUT, @ResponseMessage OUT, @TransactionReference OUT ",
                new SqlParameter("@RequestId", Model.RequestId),
                new SqlParameter("@CountryId", Model.CountryId),
                new SqlParameter("@SourceAccountNumber", Model.SourceAccountNumber),
                new SqlParameter("@DestinationAccountNumber", Model.DestinationAccountNumber),
                new SqlParameter("@Amount", Model.Amount),
                new SqlParameter("@Narration", Model.Narration),
                new SqlParameter("@ClientReferenceId", Model.ClientReferenceId),
                new SqlParameter("@IsCustomerInduced", Model.IsCustomerInduced),
                new SqlParameter("@InitiatorUserId", Model.InitiatorUserId),
                new SqlParameter("@ApproverUserId", Model.ApproverUserId),

                  Retval2, RetMsg2, retPostseq2);
                retVal.RequestId = (Model.RequestId);
                //retVal.RequestId= Convert.ToInt32(Model.RequestId);
                retVal.ResponseMessage = RetMsg2.Value.ToString();
                retVal.ResponseCode = Retval2.Value.ToString();

                //retVal.ResponseCode = Convert.ToInt32(Retval2.Value);
                retVal.TransactionReference = Convert.ToInt32(retPostseq2.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }

        public BankingOpOutput ReversalFTPostTrans(BankinkOperatInput Model)
        {

            var retVal = new BankingOpOutput();
            SqlParameter Retval2 = new SqlParameter("@ResponseCode", SqlDbType.VarChar, 4);
            Retval2.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg2 = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 200);
            RetMsg2.Direction = System.Data.ParameterDirection.Output;

            SqlParameter retPostseq2 = new SqlParameter("@TransactionReference", SqlDbType.Decimal, 12);
            retPostseq2.Direction = System.Data.ParameterDirection.Output;
            try
            {
                _db.Database.CommandTimeout = 900000;       
                var AppList = _db.Database.ExecuteSqlCommand("proc_ESBFTPosReversalITELLER @RequestId, @CountryId,@ReturnCode, @SourceAccountNumber, @DestinationAccountNumber," +
                "@Amount,@Narration,@ClientReferenceId ,@IsCustomerInduced,@InitiatorUserId,@ApproverUserId, @ResponseCode OUT, @ResponseMessage OUT, @TransactionReference OUT ",
                new SqlParameter("@RequestId", Model.RequestId),
                new SqlParameter("@CountryId", Model.CountryId),
                new SqlParameter("@ReturnCode", Model.ReturnCode),
                new SqlParameter("@SourceAccountNumber", Model.SourceAccountNumber),
                new SqlParameter("@DestinationAccountNumber", Model.DestinationAccountNumber),
                new SqlParameter("@Amount", Model.Amount),
                new SqlParameter("@Narration", Model.Narration),
                new SqlParameter("@ClientReferenceId", Model.ClientReferenceId),
                new SqlParameter("@IsCustomerInduced", Model.IsCustomerInduced),
                new SqlParameter("@InitiatorUserId", Model.InitiatorUserId),
                new SqlParameter("@ApproverUserId", Model.ApproverUserId),

                  Retval2, RetMsg2, retPostseq2);
            
                retVal.RequestId = (Model.RequestId);
                retVal.ResponseMessage = RetMsg2.Value.ToString();
                retVal.ResponseCode = Retval2.Value.ToString();
                //retVal.ResponseCode = Convert.ToInt32(Retval2.Value);
                retVal.TransactionReference = Convert.ToInt32(retPostseq2.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }






        //public BacthPostOutput BulkFTPostTrans(List<BacthPostInput> ftInput)
        //{
        //    //BacthPostOutput ftResult = new BacthPostOutput();

           

          



        //    foreach (BacthPostInput Model in ftInput)
        //    {
   

        //        SqlParameter Retval = new SqlParameter("@Retval", SqlDbType.VarChar, 4);
        //        Retval.Direction = System.Data.ParameterDirection.Output;

        //        SqlParameter RetMsg = new SqlParameter("@retmsg", SqlDbType.VarChar, 200);
        //        RetMsg.Direction = System.Data.ParameterDirection.Output;

        //        //SqlParameter retPostseq = new SqlParameter("@retPostseq", SqlDbType.Decimal, 12);
        //        //retPostseq.Direction = System.Data.ParameterDirection.Output;

        //        _db.Database.CommandTimeout = 900000;

        //        var ftr = _db.Database.ExecuteSqlCommand("proc_ESBpostbatch @RequestId, @Narration, @InitiatorUserId, @ApproverUserId," +
        //       "@ItemSequence,@Narration,@AccountNumber ,@PartTranType,@Amount,@Currency,@ClientReferenceId,@CountryId,@IsCustomerInduced, @ResponseCode OUT, @ResponseMessage OUT",

        //       new SqlParameter("@RequestId", Model.RequestId),
        //        new SqlParameter("@Narration", Model.Narration),
        //        new SqlParameter("@InitiatorUserId", Model.InitiatorUserId),
        //        new SqlParameter("@ApproverUserId", Model.ApproverUserId),
        //        new SqlParameter("@ItemSequence", Model.ItemSequence),
        //        new SqlParameter("@AccountNumber", Model.AccountNumber),
        //        new SqlParameter("@PartTranType", Model.PartTranType),
        //        new SqlParameter("@Amount", Model.Amount),
        //        new SqlParameter("@Currency", Model.Currency),
        //        new SqlParameter("@ClientReferenceId", Model.ClientReferenceId),
        //        new SqlParameter("@CountryId", Model.CountryId),
        //        new SqlParameter("@IsCustomerInduced", Model.ApproverUserId),

        //        Retval, RetMsg);

       

        //        ftfulllist.Add(new BacthPostOutput
        //        {
        //            ResponseMessage = RetMsg.Value.ToString(),
        //            ResponseCode = Retval.Value.ToString(),
        //            //OutPostseq = retPostseq.Value.ToString()
        //        });

        //    }

           
        //    return ftfulllist;
        //}






        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}