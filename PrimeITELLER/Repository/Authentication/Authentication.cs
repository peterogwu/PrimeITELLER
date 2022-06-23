using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.AuthenticationModel.GetUserDetailsModel;
using PrimeITELLER.Models.AuthenticationModel.ValidateUser;
using PrimeITELLER.Models.GetUserModel;
using PrimeITELLER.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PrimeITELLER.Repository.Authentication
{
    public class Authentication : IAuthentication
    {


        private readonly Prime2Entities _db = new Prime2Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Authentication(Prime2Entities entity)
        {
            _db = entity;

        }



        public ValidateOutput ValidateUser(ValidateInput model)
        {
            var retVal = new ValidateOutput();
        

            SqlParameter Retval3 = new SqlParameter("@ResponseCode", SqlDbType.VarChar, 150);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter Status1 = new SqlParameter("@Status", SqlDbType.VarChar, 150);
            Status1.Direction = System.Data.ParameterDirection.Output;
            try
            {
                _db.Database.CommandTimeout = 900000;
                var datat = _db.Database.ExecuteSqlCommand("Proc_ESBValidateuser @RequestId," +
                "@CountryId,@Username,@Status output ,@ResponseCode output,@ResponseMessage output",
                 new SqlParameter("@RequestId", model.RequestId),
                new SqlParameter("@CountryId", model.CountryId),
                new SqlParameter("@Username ", model.Username),
                Status1, Retval3, RetMsg3);

                //retVal.RequestId = Convert.ToInt32(model.RequestId);
                //retVal.RequestId = model.RequestId;
                //retVal.ResponseCode = Convert.ToInt32(Retval3.Value);
                retVal.ResponseCode = Retval3.Value.ToString();
                retVal.ResponseMessage = RetMsg3.Value.ToString();
                retVal.Status = Status1.Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }



        //error
        public GetUserDetailsOutput GetUserDetails(ValidateInput Model)

        {
            var CatList = new GetUserDetailsOutput();
            try
            {
                _db.Database.CommandTimeout = 900000;
                CatList = _db.Database.SqlQuery<GetUserDetailsOutput>("Proc_ESBGetUserDetails @RequestId,@CountryId,@Username",
               new SqlParameter("@RequestId", Model.RequestId),
               new SqlParameter("@CountryId ", Model.CountryId),
               new SqlParameter("@Username", Model.Username)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public LogResultModel GetUser(LogInputModel Model)

        {
            var CatList = new LogResultModel();
            try
            {



                GetUserInput m;
                string ipadd = "";
                string machaddress;

                IPHostEntry Host = default(IPHostEntry);

                string Hostname = null;
                Hostname = System.Environment.MachineName;
                Host = Dns.GetHostEntry(Hostname);
                foreach (IPAddress IP in Host.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipadd = Convert.ToString(IP);
                    }
                }

                Guid sessid;

                sessid = Guid.NewGuid();


                string enpwd = Encrypt(Model.password, ":&;,#@?*");
                string sessionid = sessid.ToString();
                machaddress = System.Net.Dns.GetHostEntry
               (System.Net.Dns.GetHostName()).AddressList.GetValue(0).ToString();
                SqlParameter ResponseCode = new SqlParameter("@ResponseCode", SqlDbType.VarChar, 200);
                ResponseCode.Direction = System.Data.ParameterDirection.Output;

                SqlParameter ResponseMessage = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 200);
                ResponseMessage.Direction = System.Data.ParameterDirection.Output;
                _db.Database.CommandTimeout = 900000;
           CatList = _db.Database.SqlQuery<LogResultModel>("Proc_ValidateloginITELLER @RequestId,@CountryId , @Username,@Password,@sessionid,@ipadd,@comp,@machaddress,"+
            "@ResponseCode OUT, @ResponseMessage OUT",
             new SqlParameter("@RequestId", Model.RequestId),
                 new SqlParameter("@CountryId ", Model.CountryId),
                  new SqlParameter("@Username", Model.Username),
                 new SqlParameter("@Password", enpwd),
                 new SqlParameter("@sessionid", sessionid),
                 new SqlParameter("@ipadd", ipadd),
                 new SqlParameter("@comp", Hostname),
                 new SqlParameter("@machaddress", machaddress),
                 ResponseCode, ResponseMessage).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }



        public string Encrypt(string stringToEncrypt, string SEncryptionKey)
        {
            byte[] key = { };
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}