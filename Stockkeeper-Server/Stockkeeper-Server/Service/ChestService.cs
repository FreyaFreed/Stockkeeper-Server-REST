using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Model;
using WebGrease.Css.Extensions;

namespace Stockkeeper_Server.Service
{
    public class ChestService : IChestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ProcessChestData(Chest chest)
        {
            if (_unitOfWork.ChestRepository.All().Any(c => c.Id == chest.Id))
            {


                _unitOfWork.ChestRepository.Update(chest);
                chest.Stacks.ForEach(stack =>
                {
                    _unitOfWork.StackRepository.Update(stack);
                });

            }
            else
            {
                _unitOfWork.ChestRepository.Create(chest);
                chest.Stacks.ForEach(stack =>
                {
                    _unitOfWork.StackRepository.Create(stack);
                });
            }
            _unitOfWork.Commit();

        }
    }
}