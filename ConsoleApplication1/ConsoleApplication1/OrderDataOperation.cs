using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    public class OrderDataOperation : IDataOperation<Order>
    {
        public string _path = Environment.CurrentDirectory;

        public string _connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + Environment.CurrentDirectory + @"\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";        

        public IEnumerable<Order> Get()
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            IDbCommand cmd = new SqlCommand("SELECT * FROM Orders");

            cmd.Connection = connection;

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Order order = new Order() 
                {
                    OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID"))),
                    CustomerID = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDate"))),
                    EmployeeID = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("EmployeeID"))),
                    Freight = reader.IsDBNull(reader.GetOrdinal("Freight")) ? new Nullable<double>() : Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Freight"))),
                    RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("RequiredDate"))),
                    ShipAddress = reader.GetValue(reader.GetOrdinal("ShipAddress")).ToString(),
                    ShipCity = reader.GetValue(reader.GetOrdinal("ShipCity")).ToString(),
                    ShipCountry = reader.GetValue(reader.GetOrdinal("ShipCountry")).ToString(),
                    ShipName = reader.GetValue(reader.GetOrdinal("ShipName")).ToString(),
                    ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShippedDate"))),
                    ShipPostalCode = reader.GetValue(reader.GetOrdinal("ShipPostalCode")).ToString(),
                    ShipRegion = reader.GetValue(reader.GetOrdinal("ShipPostalCode")).ToString(),
                    ShipVia = reader.IsDBNull(reader.GetOrdinal("ShipVia")) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ShipVia"))),
                };

                yield return order;
            }

            connection.Close();

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
