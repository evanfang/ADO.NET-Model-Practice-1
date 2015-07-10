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
    public class CustomerDataOperation : IDataOperation<Customer>
    {
        public string _path = Environment.CurrentDirectory;

        public string _connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + Environment.CurrentDirectory + @"\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";        

        public IEnumerable<Customer> Get()
        {
            IDbConnection connection = new SqlConnection(this._connectionString);

            IDbCommand cmd = new SqlCommand("SELECT * FROM Customers");

            cmd.Connection = connection;

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while(reader.Read())
            {
                Customer customer = new Customer() 
                {
                    CustomerID = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    CompanyName = reader.GetValue(reader.GetOrdinal("CompanyName")).ToString(),
                    Address = reader.GetValue(reader.GetOrdinal("Address")).ToString(),
                    City = reader.GetValue(reader.GetOrdinal("City")).ToString(),
                    ContactName = reader.GetValue(reader.GetOrdinal("ContactName")).ToString(),
                    ContactTitle = reader.GetValue(reader.GetOrdinal("ContactTitle")).ToString(),
                    Country = reader.GetValue(reader.GetOrdinal("Country")).ToString(),
                    Fax = reader.GetValue(reader.GetOrdinal("Fax")).ToString(),
                    Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString(),
                    PostalCode = reader.GetValue(reader.GetOrdinal("PostalCode")).ToString(),
                    Region = reader.GetValue(reader.GetOrdinal("Region")).ToString(),
                };

                yield return customer;
            }

            connection.Close();
        }

        public void Create(Customer item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);

            IDbCommand cmd = new SqlCommand(
                @"INSERT INTO Customers(
                    CustomerID, CompanyName, Address, City, ContactName, ContactTitle, Country, Fax, Phone, PostalCode, Region
                ) VALUES (
                    @CustomerID, @CompanyName, @Address, @City, @ContactName, @ContactTitle, @Country, @Fax, @Phone, @PostalCode, @Region)"
                );

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@CustomerID", item.CustomerID));
            cmd.Parameters.Add(new SqlParameter("@CompanyName", item.CompanyName));
            cmd.Parameters.Add(new SqlParameter("@Address", item.Address));
            cmd.Parameters.Add(new SqlParameter("@City", item.City));
            cmd.Parameters.Add(new SqlParameter("@ContactName", item.ContactName));
            cmd.Parameters.Add(new SqlParameter("@ContactTitle", item.ContactTitle));
            cmd.Parameters.Add(new SqlParameter("@Country", item.Country));
            cmd.Parameters.Add(new SqlParameter("@Fax", item.Fax));
            cmd.Parameters.Add(new SqlParameter("@Phone", item.Phone));
            cmd.Parameters.Add(new SqlParameter("@PostalCode", item.PostalCode));
            cmd.Parameters.Add(new SqlParameter("@Region", item.Region));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Customer item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);

            IDbCommand cmd = new SqlCommand(
                @"UPDATE Customers SET 
                    CompanyName = @CompanyName, 
                    Address = @Address, 
                    City = @City, 
                    ContactName = @ContactName, 
                    ContactTitle = @ContactTitle, 
                    Country = @Country, 
                    Fax = @Fax, 
                    Phone = @Phone, 
                    PostalCode = @PostalCode, 
                    Region = @Region WHERE CustomerId = @CustomerId"
                );

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@CustomerID", item.CustomerID));
            cmd.Parameters.Add(new SqlParameter("@CompanyName", item.CompanyName));
            cmd.Parameters.Add(new SqlParameter("@Address", item.Address));
            cmd.Parameters.Add(new SqlParameter("@City", item.City));
            cmd.Parameters.Add(new SqlParameter("@ContactName", item.ContactName));
            cmd.Parameters.Add(new SqlParameter("@ContactTitle", item.ContactTitle));
            cmd.Parameters.Add(new SqlParameter("@Country", item.Country));
            cmd.Parameters.Add(new SqlParameter("@Fax", item.Fax));
            cmd.Parameters.Add(new SqlParameter("@Phone", item.Phone));
            cmd.Parameters.Add(new SqlParameter("@PostalCode", item.PostalCode));
            cmd.Parameters.Add(new SqlParameter("@Region", item.Region));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Customer item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);

            IDbCommand cmd = new SqlCommand(@"DELETE FROM Customers WHERE CustomerId = @CustomerId");

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@CustomerId", item.CustomerID));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
