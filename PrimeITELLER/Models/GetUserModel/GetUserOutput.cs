using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeITELLER.Models.GetUserModel
{
    public class GetUserOutput
    {

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }


        public string fullname { get; set; }

        public string phoneno { get; set; }

        public int RoleId { get; set; }
        public string BranchName { get; set; }
    }
}