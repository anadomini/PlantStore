using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Store.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PlantId { get; set; }
        public float Price { get; set; }
        public virtual Plant plant { get; set; }
        public virtual Order order { get; set; }
    }
}
