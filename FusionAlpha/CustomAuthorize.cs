using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FusionAlpha
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string SuperUsers { get; set; }
        public int UserGroupID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //string user = httpContext.Request.Form["username"];
            //string pw = httpContext.Request.Headers["Authorize"];
            return Membership.ValidateUser("user", "pw");
        }
    }
}