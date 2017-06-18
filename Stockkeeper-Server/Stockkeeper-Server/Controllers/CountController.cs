using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stockkeeper_Server.Service;

namespace Stockkeeper_Server.Controllers
{
    [RoutePrefix("count")]
    public class CountController : ApiController
    {
        private readonly ICountService _countService;
        public CountController(ICountService countService)
        {
            _countService = countService;
        }
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage All()
        {
            object  counted =_countService.All();
            return Request.CreateResponse(HttpStatusCode.OK, counted);
        }
    }
}
