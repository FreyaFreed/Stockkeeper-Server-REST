using Stockkeeper_Server.Datalayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Context;
using Stockkeeper_Server.Service;

namespace Stockkeeper_Server.Controllers
{
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
        [Route("chest")]
        public HttpResponseMessage ProcessChestData(Chest chest)
        {
            try
            {
                _chestService.ProcessChestData(chest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                var errorLog = new ErrorLog()
                {
                    Timestamp = DateTimeOffset.Now,
                    ExceptionMessage = e.Message,
                    InnerException = e.InnerException?.Message,
                    StackTrace = e.StackTrace
                };

                _unitOfWork.ErrorLogRepository.Create(errorLog);
                _unitOfWork.Commit();
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
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
