using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwind db = new Northwind();

            IEnumerable<Customer> customers = db.Customers.Get();

            foreach (Customer c in customers)
            {
                Console.WriteLine("Customer ID:{0},\t Company:{1}", c.CustomerID, c.CompanyName);
            }
        }
    }
}
