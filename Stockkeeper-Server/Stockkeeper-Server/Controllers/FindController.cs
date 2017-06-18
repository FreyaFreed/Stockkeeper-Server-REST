using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Stockkeeper_Server.Datalayer.Model;
using Stockkeeper_Server.Service;

namespace Stockkeeper_Server.Controllers
{
    [RoutePrefix("find")]
    public class FindController : ApiController
    {
        private readonly IFindService _findService;
        public FindController(IFindService findService)
        {
            _findService= findService;
        }
        [HttpPost]
        [Route("closest")]
        public HttpResponseMessage Closest(FindClosest closest)
        {
            
           var returnVal = _findService.Closest(closest);
           return Request.CreateResponse(HttpStatusCode.OK, returnVal);

        }
        [HttpGet]
        [Route("test")]
        public HttpResponseMessage Test()
        {
           
            return Request.CreateResponse(HttpStatusCode.OK, "Test");

        }
    }
}
