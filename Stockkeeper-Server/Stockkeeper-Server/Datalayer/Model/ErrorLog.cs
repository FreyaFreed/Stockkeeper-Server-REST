using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public class ErrorLog : Base
    {
        public DateTimeOffset Timestamp { get; set; }
        public String ExceptionMessage { get; set; }

        public String InnerException { get; set; }

        public String StackTrace { get; set; }
    }
}