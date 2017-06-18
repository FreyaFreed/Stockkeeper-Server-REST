using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Datalayer
{
    public interface IUnitOfWork
    {
        void Commit();
        IRepository<Chest> ChestRepository { get; }
        IRepository<Stack> StackRepository { get; }
        IRepository<ErrorLog> ErrorLogRepository { get; }
        IRepository<ErrorReport> ErrorReportRepository { get; }
        IRepository<Item> ItemRepository { get; }
    }
}