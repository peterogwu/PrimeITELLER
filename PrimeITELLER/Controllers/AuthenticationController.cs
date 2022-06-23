using NLog;
using PrimeITELLER.Models;
using PrimeITELLER.Models.AuthenticationModel.GetUserDetailsModel;
using PrimeITELLER.Models.AuthenticationModel.ValidateUser;
using PrimeITELLER.Models.GetUserModel;
using PrimeITELLER.Models.Login;
using PrimeITELLER.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrimeITELLER.Controllers
{
    public class AuthenticationController : ApiController
    {

        private Prime2Entities db = new Prime2Entities();
        private IAuthentication _db;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AuthenticationController()
        {
            _db = new Authentication(new Models.Prime2Entities());
        }

        public AuthenticationController(IAuthentication entity)
        {
            _db = entity;
        }




     

    


        [Route("Prime/ValidateUser")]
        //[ResponseType(typeof(ValidateOutput))]
        [HttpGet]
        public IHttpActionResult ValidateUser([FromBody] ValidateInput Model)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Validate User Input with Host"
                + "and Request Id: ," + Model.RequestId + " " + "Country Code :," + Model.CountryId + "" + "User Name :," + Model.Username +  DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new ValidateOutput();


            try
            {

                result = _db.ValidateUser(Model);



                //logger.Info("Validate User Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "Status :," + result.Status +  "RequestId:" + result.RequestId + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Validate User  Exception" + ex.Message + ex.InnerException + DateTime.Now);
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




        [Route("Prime/GetUserDetails")]
        //[ResponseType(typeof(ValidateOutput))]
        [HttpGet]
        public IHttpActionResult GetUserDetails([FromBody] ValidateInput Model)
        {
           


            logger.Info("GetUserDetails  Input with Host"
                + "and Request Id: ," + Model.RequestId + " " + "Country Code :," + Model.CountryId + "" + "User Name :," + Model.Username + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new GetUserDetailsOutput();


            try
            {

                result = _db.GetUserDetails(Model);



                //logger.Info("Validate User Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "Status :," + result.Status +  "RequestId:" + result.RequestId + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("GetUserDetails   Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }


            return Ok(result);
        }



        



        [Route("Prime/getuserdetails")]
        //[ResponseType(typeof(ValidateOutput))]
        [HttpPost]
        public IHttpActionResult GetUser([FromBody] LogInputModel Model)
        {
            //var request = HttpContext.Current.Request;

            //var host = request.Headers.GetValues("Host");


            logger.Info("Validate User Input with Host"
                + "and Request Id: ," + Model.RequestId + " " + "Country Code :," + Model.CountryId + "" + "User Name :," + Model.Username + DateTime.Now);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new LogResultModel();


            try
            {

                result = _db.GetUser(Model);



                //logger.Info("Validate User Enquiry Endpoint Result" + ("Response Code :," + result.ResponseCode).ToString() + "Response Message :," + result.ResponseMessage + "Status :," + result.Status +  "RequestId:" + result.RequestId + DateTime.Now);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Validate User  Exception" + ex.Message + ex.InnerException + DateTime.Now);
            }


            return Ok(result);
        }

    }
}
