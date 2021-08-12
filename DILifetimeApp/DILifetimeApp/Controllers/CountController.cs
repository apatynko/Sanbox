using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DILifetimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly IFirstCounter _firstCounter;
        private readonly ISecondCounter _secondCounter;
        public CountController(IFirstCounter fisrstCounter, ISecondCounter secondCounter)
        {
            this._firstCounter = fisrstCounter;
            this._secondCounter = secondCounter;
        }
        // GET: api/<CountController>
        [HttpGet]
        public int Get()
        {
            _firstCounter.IncrementAndGet();
            return _secondCounter.IncrementAndGet();
        }
    }
}
