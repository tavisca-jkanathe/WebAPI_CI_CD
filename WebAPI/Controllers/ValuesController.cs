using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Enter hello Or hi";
        }

        // GET api/anystring
        [HttpGet("{value}")]
        public ActionResult<string> Get(string value)
        {
            if (value == "hello")
                return "hi";
            if (value == "hi")
                return "hello";

            return "Enter hello Or hi";
        }
    }
}
