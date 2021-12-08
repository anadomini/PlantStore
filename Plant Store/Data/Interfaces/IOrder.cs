using Plant_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Store.Data.Interfaces
{
    public interface IOrder
    {
        void createOrder(Order order);
    }
}
