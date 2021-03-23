using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo14_ONG.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class VerifyLogin : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((User)HttpContext.Current.Session["User"] != null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
                base.OnAuthorization(filterContext);
            }
        }

    }
}