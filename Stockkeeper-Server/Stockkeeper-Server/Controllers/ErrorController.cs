using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpPost]
        [Route("submit")]
        public void SubmitErrorReport(ErrorReport report)
        {
            
        }
    }
}
