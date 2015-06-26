using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Csharp.Linq
{
    class LinqToObjectSamples
    {
        public static void SimpleFilter()
        {
            //simple strings
            string[] names = { "Tom", "Max", "Harry" };

            //Call Extension method directly: Press F12 to show all extensions of Enumerable
            IEnumerable<string> filteredNames =
                Enumerable.Where(names, n => n.Length >= 4);

            foreach (string n in filteredNames)
                Console.Write(n + "|");            // Dick|Harry|

            Console.ReadLine();

            //Default Linq call with lambda expression --> method syntax
            filteredNames = names.Where(n => n.Length >= 4);

            foreach (string n in filteredNames)
                Console.Write(n + "|");            // Dick|Harry|

            Console.ReadLine();

            //Default Linq call --> query syntax: simple to understand and to read but limited (ex. Count()). SQL like
            filteredNames = from name in names
                            where name.Length >= 4
                            select name;

            foreach (string n in filteredNames)
                Console.Write(n + "|");            // Dick|Harry|

            Console.ReadLine();
        }

//code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b

        public static void ModifyData()
        {
            //simple strings
            string[] names = { "Tom", "Max", "Harry" };

            //query syntax
            var firstAndLastNames = from name in names
                                    select name + " Müller";

            foreach (string n in firstAndLastNames)
                Console.WriteLine(n);

            Console.ReadLine();

            //method syntax
            firstAndLastNames = names.Select(n => n + " Müller");

            foreach (string n in firstAndLastNames)
                Console.WriteLine(n);

            Console.ReadLine();
        }

        public static void CalculationQueries()
        {
            Random random = new Random();
            var numbers = new List<int>();

            var length = random.Next(50, 150);

            for (int i = 0; i < length; i++)
                numbers.Add(random.Next(100));

            Console.WriteLine("Count: " + numbers.Count());
            Console.WriteLine("Lowest: " + numbers.Min());
            Console.WriteLine("Greatest: " + numbers.Max());
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Sum: " + numbers.Average());
            Console.ReadLine();
        }

        public static void ComplexObjects()
        {
            var persons = new List<Person>()
            {
                new Person() { FirstName = "Tom", LastName = "Schmitt", Age = 20},
                new Person() { FirstName = "Michael", LastName = "Müller", Age = 25},
                new Person() { FirstName = "Stefan", LastName = "Maier", Age = 19},
                new Person() { FirstName = "Max", LastName = "Müller", Age = 30},
                new Person() { FirstName = "Rudi", LastName = "Beckenbauer", Age = 50},
                new Person() { FirstName = "Sebastian", LastName = "Müller", Age = 25},
                new Person() { FirstName = "Harry", LastName = "Schmitt", Age = 60},
                new Person() { FirstName = "Gerd", LastName = "Schmitt", Age = 44},
            };

            int age = 18;

            //Grouping of complex objects?
            var result = from person in persons
                         where person.Age > age
                         group person by person.LastName into grouping // --> new grouped scope
                         orderby grouping.Key
                         select grouping;

            age = 25;

            //Result? age > 18 or age > 25;
            var personsGrouped = result.ToList();

            Console.WriteLine("Age == 18 or 25?");
            Console.ReadLine();

            foreach (var group in personsGrouped)
            {
                Console.WriteLine("Group: " + group.Key);

                foreach (var name in group)
                {
                    Console.WriteLine(" -" + name.FirstName);
                }
            }
        }
    }
}
