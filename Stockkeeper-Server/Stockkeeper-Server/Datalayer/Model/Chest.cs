using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    
    public class Chest : Container
    {
        public Chest() 
        {
            Stacks = new List<Stack>();
        }
       
    }
}