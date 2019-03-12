using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Security
{
    public class SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
         {
            var data = filterContext.RouteData;
            var controllerName = data.Values["controller"];
            var actionName = data.Values["action"];


            if (actionName.Equals("ECustomers"))
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

        }
    }
}