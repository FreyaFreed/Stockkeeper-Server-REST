using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Service
{
    public class ErrorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ErrorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void SubmitErrorReport(ErrorReport report)
        {
            _unitOfWork.ErrorReportRepository.Create(report);
            _unitOfWork.Commit();
        }


    }
}