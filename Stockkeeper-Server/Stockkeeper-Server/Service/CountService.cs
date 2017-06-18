using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Stockkeeper_Server.Datalayer;

namespace Stockkeeper_Server.Service
{
    public class CountService : ICountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public object All()
        {
            var countedItems = _unitOfWork.StackRepository.All().Where(s => s.ItemId != null).GroupBy(s => s.ItemId).Select(group => new
                {
                ItemId = group.Key,
                Count = group.Sum(s => s.Count)
                });
            return countedItems.ToList();
        }
    }
}