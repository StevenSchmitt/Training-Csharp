using System;
using System.Xml.Linq;
using System.Linq;

namespace Training.Csharp.Linq
{
    public class LinqToXmlSamples
    {
        static XDocument xDoc = new XDocument(
                new XElement("Customers",
                    new XElement("Customer",
                        new XAttribute("ID", "1"),
                        new XAttribute("City", "Berlin"),
                        new XAttribute("Region", "Europe"),
                        new XElement("Order",
                            new XAttribute("Item", "Apple"),
                            new XAttribute("Amount", 100)
                        ),
                        new XElement("Order",
                            new XAttribute("Item", "Cherry"),
                            new XAttribute("Amount", 200)
                        )
                    ),
                    new XElement("Customer",
                        new XAttribute("ID", "2"),
                        new XAttribute("City", "New York"),
                        new XAttribute("Region", "North America"),
                        new XElement("Order",
                            new XAttribute("Item", "Banana"),
                            new XAttribute("Amount", 300)
                        )
                    ),
                    new XElement("Customer",
                        new XAttribute("ID", "3"),
                        new XAttribute("City", "Paris"),
                        new XAttribute("Region", "Europe"),
                        new XElement("Order",
                            new XAttribute("Item", "Banana"),
                            new XAttribute("Amount", 300)
                        ),
                        new XElement("Order",
                            new XAttribute("Item", "Cherry"),
                            new XAttribute("Amount", 200)
                        )
                    ),
                    new XElement("Customer",
                        new XAttribute("ID", "4"),
                        new XAttribute("City", "Miami"),
                        new XAttribute("Region", "North America"),
                        new XElement("Order",
                            new XAttribute("Item", "Banana"),
                            new XAttribute("Amount", 300)
                        ),
                        new XElement("Order",
                            new XAttribute("Item", "Apple"),
                            new XAttribute("Amount", 100)
                        )
                    )
                ));

        public static void CreateXml()
        {
            Console.WriteLine(xDoc);
        }

        public static void SaveXml()
        {
            Console.WriteLine("Save");

            xDoc.Save(@"C:\customers.xml");
        }

        public static void LoadXml()
        {
            Console.WriteLine("Load");

            var loadedXml = XDocument.Load(@"C:\customers.xml");

            Console.WriteLine(loadedXml);
        }

        public static void QueryXml()
        {
            var data = from element in xDoc.Descendants("Customer")
                       select new
                       {
                           Id = element.Attribute("ID").Value,
                           City = element.Attribute("City").Value,
                           NumberOfOrders = element.Elements("Order").Count()
                       };

            foreach (var item in data)
            {
                Console.WriteLine(string.Format("ID: {0}, City: {1}, Number of orders: {2}", item.Id, item.City, item.NumberOfOrders));
            }
        }
    }
}
