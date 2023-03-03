using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Models
{
   public class Productmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public virtual Categorymodel Category { get; set; }
    }
}
