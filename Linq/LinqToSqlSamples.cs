using System;
using System.Data.Linq;
using System.Linq;

namespace Training.Csharp.Linq
{
    public class LinqToSqlSamples
    {
        public static void Read()
        {
            //Connection string in Settings file
            var dataContext = new LinqToSqlClassesDataContext();

            //only one sql call
            var result = from c in dataContext.Customers
                         where c.Country == "Germany"
                         orderby c.CompanyName
                         select new
                         {
                             CompanyName = c.CompanyName,
                             LastOrderDate = c.Orders.Max(o => o.OrderDate)
                         };

            //Call ToList() == commit of sql query
            //Show sql query
            foreach (var item in result.ToList())
            {
                Console.WriteLine("Company: " + item.CompanyName + " | Last order: " + item.LastOrderDate.Value);
            }

            //Attention!!
            //Many calls to database!!!
            foreach (var c in dataContext.Customers)
                foreach (var o in c.Orders)
                    Console.WriteLine("Company: " + c.CompanyName + " | Order Date: " + o.OrderDate.Value);

            //Eager loading --> only one sql database call
            //Copy in line 30
            //var options = new DataLoadOptions();
            //options.LoadWith<Customer>(c => c.Orders);
            //dataContext.LoadOptions = options;
        }

        public static void Create()
        {
            var dataContext = new LinqToSqlClassesDataContext();

            //define new customer
            var newCustomer = new Customer();
            newCustomer.CustomerID = "1000";
            newCustomer.CompanyName = "Test";
            
            //Insert customer
            dataContext.Customers.InsertOnSubmit(newCustomer);

            //Commit to database
            dataContext.SubmitChanges();
        }

        public static void Update()
        {
            var dataContext = new LinqToSqlClassesDataContext();

            //define new customer
            var newCustomer = new Customer();
            newCustomer.CustomerID = "1001";
            newCustomer.CompanyName = "Test";

            //Insert customer
            dataContext.Customers.InsertOnSubmit(newCustomer);

            //Commit to database
            dataContext.SubmitChanges();

            //Update
            newCustomer.Country = "Germany";

            //commit to database
            dataContext.SubmitChanges();
        }

        public static void Delete()
        {
            var dataContext = new LinqToSqlClassesDataContext();

            var customersToRemove = dataContext.Customers.Where(c => c.CustomerID == "1000" || c.CustomerID == "1001");

            dataContext.Customers.DeleteAllOnSubmit(customersToRemove);
            dataContext.SubmitChanges();
        }
    }
}
