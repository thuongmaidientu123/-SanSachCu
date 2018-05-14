using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web1._0.Controllers
{
    
    public class BaseController : Controller
    {
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ses = Session[Common.CommonConstrants.USER_SESSION];
            if (ses == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {controller = "TaiKhoan", action = "Index"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}