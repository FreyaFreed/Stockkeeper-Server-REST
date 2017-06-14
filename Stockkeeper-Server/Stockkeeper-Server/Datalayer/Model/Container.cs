using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stockkeeper_Server.Datalayer.Model
{
    public abstract class Container    {

        [Key]
        public string Id { get; set; }
        public World World { get; set; }
        public int X { get; set; }
     
        public int Y { get; set; }
       
        public int Z { get; set; }

        public virtual ICollection<Stack> Stacks { get; set; }

        public override bool Equals(object obj)
        {
            
            Container o = obj as Container;
            if (o == null) return false;
            if (X == o.X && Y == o.Y && Z == o.Z) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static bool operator ==(Container left, Container right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Container left, Container right)
        {
            return !left.Equals(right);
        }

        public void generateId()
        {
            var separator = ",";
            Id = World.ToString() + separator + X + separator + Y + separator + Z;
        }
    }
}