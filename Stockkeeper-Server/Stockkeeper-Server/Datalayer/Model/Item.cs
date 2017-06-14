using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public class Item : Base
    {
        public string UnLocalizedName { get; set; }
        public int StackLimit { get; set; }


    }
}