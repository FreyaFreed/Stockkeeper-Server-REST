using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public class ErrorReport : Base
    {
        public string Message { get; set; }

        [ForeignKey("ErrorLog")]
        public int ErrorLogId { get; set; }

        public ErrorLog ErrorLog { get; set; }
    }
}