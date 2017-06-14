using System.Linq;

namespace Stockkeeper_Server.Datalayer
{
    public interface IRepository<T> where T : class
    {
        T Create(T obj);
        void Update(T obj);
        IQueryable<T> All();
        T Find(int id);
        T Find(params object[] keys);
    }
}