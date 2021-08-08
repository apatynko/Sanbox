using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DILifetimeApp
{
    public class MyActionFilter2 : ActionFilterAttribute
    {
        public string id { get; set; }
        public MyActionFilter2(string name)
        {
            id = name;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;
            Trace.WriteLine($"{id} Before execution of {actionName}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // after action method excution
            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            Trace.WriteLine($"{id} After execution of {actionName}");
        }
        
    }
}
