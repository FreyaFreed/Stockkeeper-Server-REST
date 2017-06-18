using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Service
{
    public interface IFindService
    {
        Chest Closest(FindClosest closest);
    }
}