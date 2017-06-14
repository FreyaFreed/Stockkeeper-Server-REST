using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}