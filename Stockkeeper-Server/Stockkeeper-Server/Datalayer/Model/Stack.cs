using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public class Stack 
    {
        public virtual Container Container { get; set; }

        [Key, ForeignKey("Container"), Column(Order = 0)]
        public string ContainerId { get; set; }
        [Key, Column(Order = 1)]
        public int Slot { get; set; }

        public Item Item { get; set; }

        [ForeignKey("Item")]
        public int? ItemId { get; set; }
        public int? Count { get; set; }
    }
}