using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OrderDataOperation : IDataOperation<Order>
    {
        public IEnumerable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
