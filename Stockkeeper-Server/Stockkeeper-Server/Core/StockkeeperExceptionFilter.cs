using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Core
{
    public class StockkeeperExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var IoC =
                GlobalConfiguration.Configuration.DependencyResolver as AutofacWebApiDependencyResolver;
            using (var scope = IoC.Container.BeginLifetimeScope())
            {
                var unitOfWork = scope.Resolve<IUnitOfWork>();
                var errorLog = new ErrorLog()
                {
                    Timestamp = DateTimeOffset.Now,
                    ExceptionMessage = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace
                };
                var log = unitOfWork.ErrorLogRepository.Create(errorLog);
                unitOfWork.Commit();
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, log.Id);

            }
        }
    }
}