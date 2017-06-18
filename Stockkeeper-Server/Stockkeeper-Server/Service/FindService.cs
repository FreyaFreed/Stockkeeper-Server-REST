using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stockkeeper_Server.Datalayer;
using Stockkeeper_Server.Datalayer.Model;
using WebGrease.Css.Extensions;

namespace Stockkeeper_Server.Service
{
    public class FindService : IFindService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FindService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Chest Closest(FindClosest closest)
        {
            int closestDistance = int.MaxValue;
            Chest closestChest = null;
            Item item = _unitOfWork.ItemRepository.All().FirstOrDefault(i => i.UnLocalizedName == closest.ItemName);
            var foundChests = _unitOfWork.StackRepository.All().Join(_unitOfWork.ChestRepository.All(), stack => stack.ContainerId,
                chest => chest.Id, (stack, chest) => chest);
            foundChests.ForEach(chest =>
            {
                var distance = Math.Pow(chest.X - closest.X, 2) + Math.Pow(chest.Y - closest.Y, 2) + Math.Pow(chest.Z - closest.Z, 2);
                if (distance < closestDistance)
                {
                    closestChest = chest;
                }
            });
            return closestChest;
        }
    }
}