using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Service
{
    public interface IChestService
    {
        void ProcessChestData(Chest chest);
    }
}