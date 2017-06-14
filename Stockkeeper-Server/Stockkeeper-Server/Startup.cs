using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Stockkeeper_Server.Datalayer.Context;
using Stockkeeper_Server.Datalayer.Model;

[assembly: OwinStartup(typeof(Stockkeeper_Server.Startup))]

namespace Stockkeeper_Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          
        }
    }
}
