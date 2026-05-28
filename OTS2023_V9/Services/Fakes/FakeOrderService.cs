using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Fakes
{
    public class FakeOrderService : IOrderService
    {
        public List <Order> Orders { get; set; }
        public double UpdateTotalDifference { get; set; }

        public FakeOrderService()
        {
            Orders = new List<Order> ;
        }

        public Order GetOrderById(Guid id)
        {

         return Orders[0]
        }
    }
}
