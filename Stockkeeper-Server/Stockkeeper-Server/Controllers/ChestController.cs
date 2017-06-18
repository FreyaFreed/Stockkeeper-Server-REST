using Stockkeeper_Server.Datalayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Context;
using Stockkeeper_Server.Service;

namespace Stockkeeper_Server.Controllers
{
    [RoutePrefix("chest")]
    public class ChestController : ApiController
    {
        private readonly IChestService _chestService;
        private readonly IUnitOfWork _unitOfWork;
        public ChestController(IChestService chestService, IUnitOfWork unitOfWork)
        {
            _chestService = chestService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("process")]
        public HttpResponseMessage ProcessChestData(Chest chest)
        {
            _chestService.ProcessChestData(chest);
            return Request.CreateResponse(HttpStatusCode.OK);
            
         
        }
        [HttpPost]
        [Route("item")]
        public HttpResponseMessage InitializeItemData(List<Item> items)
        {
            using (var ctx = new StockkeeperContext())
            {
                foreach (var item in items)
                {
                    ctx.Items.Add(item);
                }
                
                ctx.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
