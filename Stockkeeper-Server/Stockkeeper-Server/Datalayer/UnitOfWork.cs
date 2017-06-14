using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stockkeeper_Server.Datalayer.Context;
using Stockkeeper_Server.Datalayer.Model;

namespace Stockkeeper_Server.Datalayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockkeeperContext _context;
        public UnitOfWork(StockkeeperContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private IRepository<ErrorLog> _errorLogRepository;

        public IRepository<ErrorLog> ErrorLogRepository
        {
            get
            {
                if (_errorLogRepository == null) _errorLogRepository = new BaseRepository<ErrorLog>(_context);

                return _errorLogRepository;
            }
        }

        private IRepository<Chest> _chestRepository;

        public IRepository<Chest> ChestRepository
        {
            get
            {
                if (_chestRepository == null) _chestRepository = new BaseRepository<Chest>(_context);

                return _chestRepository;
            }
        }

        private IRepository<Stack> _stackRepository;

        public IRepository<Stack> StackRepository
        {
            get
            {
                if (_stackRepository == null) _stackRepository = new BaseRepository<Stack>(_context);

                return _stackRepository;
            }
        }






    }
}