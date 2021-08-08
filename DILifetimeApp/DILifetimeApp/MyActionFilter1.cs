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
    public class MyActionFilter1 : Attribute, IActionFilter
    {
        public string id { get; set; }
        public MyActionFilter1(string name)
        {
            id = name;
        }
        public bool AllowMultiple => true;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext,
                                                                  CancellationToken cancellationToken,
                                                                  Func<Task<HttpResponseMessage>> continuation)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;
            Trace.WriteLine($"{id} Before execution of {actionName}");
            // before action method execution
            
            var result = continuation();
            result.Wait();

            // after  action method excution
            Trace.WriteLine($"{id} After execution of {actionName}");

            return result;
        }
    }
}
