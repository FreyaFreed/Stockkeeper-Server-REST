using Stockkeeper_Server.Datalayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Context
{
    public class StockkeeperContext : DbContext
    {

        public DbSet<Container> Containers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<ErrorReport> ErrorReports { get; set; }


    }
}