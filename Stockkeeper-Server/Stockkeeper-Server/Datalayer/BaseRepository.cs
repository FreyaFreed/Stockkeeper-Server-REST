using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Stockkeeper_Server.Datalayer.Context;

namespace Stockkeeper_Server.Datalayer
{
    public class BaseRepository<T> : IRepository<T> where T: class
    {
        protected IDbSet<T> _entities;
        protected StockkeeperContext _context;

        public BaseRepository(StockkeeperContext context)
        {
            _context = context;
        }

        protected IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        public virtual T Create(T obj)
        {
            return Entities.Add(obj);
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual IQueryable<T> All()
        {
            return Entities.AsQueryable();
        }

        public virtual T Find(int id)
        {
            return Entities.Find(id);
        }
        public virtual T Find(params object[] keys)
        {
            return Entities.Find(keys);
        }


    }
}