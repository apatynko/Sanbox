using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DILifetimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionFilterController : ControllerBase
    {
        //[MyActionFilter1("filter 1")]
        [ServiceFilter(typeof(MyActionFilter1))]
        [HttpGet]
        [Route("get1")]
        public string Get1()
        {
            Trace.WriteLine("Inside action method get1...");
            return "Action Get1 from Action Filters Controller";
        }

        [HttpGet]
        [Route("get2")]
        [MyActionFilter2("filter 2")]
        public string Get2()
        {
            Trace.WriteLine("Inside action method get2 ...");
            return "Action Get2 from Action Filters Controller";
        }
    }
}
