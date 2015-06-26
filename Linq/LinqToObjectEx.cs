using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Csharp.Linq
{
    public class LinqToObjectEx
    {
        //Helper
        //https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
        static IEnumerable<Person> Persons = new List<Person>()
        {
            new Person() { Department = "Sales", FirstName = "Tom", LastName = "Schütz", Age = 20},
            new Person() { Department = "Marketing", FirstName = "Stefan", LastName = "Meier", Age = 19},
            new Person() { Department = "Development", FirstName = "Michael", LastName = "Marx", Age = 25},
            new Person() { Department = "Sales", FirstName = "Max", LastName = "Müller", Age = 30},
            new Person() { Department = "Marketing", FirstName = "Harry", LastName = "Schwamm", Age = 60},
            new Person() { Department = "Development", FirstName = "Rudi", LastName = "Bauer", Age = 50},
            new Person() { Department = "Sales", FirstName = "Sebastian", LastName = "Maas", Age = 25},
            new Person() { Department = "Development", FirstName = "Maggi", LastName = "Scheid", Age = 34},
            new Person() { Department = "Marketing", FirstName = "Sabine", LastName = "Schürle", Age = 23},
            new Person() { Department = "Marketing", FirstName = "Pascal", LastName = "Schwamm", Age = 60},
            new Person() { Department = "Development", FirstName = "Moritz", LastName = "Bauer", Age = 50},
            new Person() { Department = "Sales", FirstName = "Gerd", LastName = "Schmitt", Age = 44},
            new Person() { Department = "Marketing", FirstName = "Freddi", LastName = "Schmitt", Age = 65},
            new Person() { Department = "Development", FirstName = "Markus", LastName = "Michels", Age = 34},
            new Person() { Department = "Sales", FirstName = "Stephan", LastName = "Maier", Age = 34},
            new Person() { Department = "Marketing", FirstName = "Patrick", LastName = "Meiser", Age = 12},
            new Person() { Department = "Development", FirstName = "Viktor", LastName = "Beckenbauer", Age = 78},
            new Person() { Department = "Sales", FirstName = "Maike", LastName = "Müller", Age = 56},
            new Person() { Department = "Development", FirstName = "Siggi", LastName = "Scheid", Age = 34},
            new Person() { Department = "Marketing", FirstName = "Julia", LastName = "Schürle", Age = 23},
            new Person() { Department = "Development", FirstName = "Lisa", LastName = "Marx", Age = 25},
            new Person() { Department = "Sales", FirstName = "Maik", LastName = "Müller", Age = 30},
            new Person() { Department = "Marketing", FirstName = "Irina", LastName = "Schwamm", Age = 60},
            new Person() { Department = "Development", FirstName = "Steven", LastName = "Bauer", Age = 50},
        };
































        #region Solution

        public static void Do()
        {
            var result = from people in Persons
                         group people by people.Department into departmentGroup
                         orderby departmentGroup.Key descending
                         where departmentGroup.Average(x => x.Age) > 35
                         select new
                         {
                             Department = departmentGroup.Key,
                             Peoples = from d in departmentGroup
                                      group d by d.LastName into lastNameGroup
                                      orderby lastNameGroup.Key
                                      select new 
                                      {
                                          LastName = lastNameGroup.Key,
                                          FirstNames = from n in lastNameGroup
                                                       select n.FirstName
                                      }
                         };

            foreach (var item in result)
            {
                Console.WriteLine("Department: " + item.Department);

                foreach (var people in item.Peoples)
                {
                    Console.WriteLine(" -" + people.LastName);

                    foreach (var firstName in people.FirstNames)
                    {
                        Console.WriteLine("   -" + firstName);
                    }
                }
            }
        }

        #endregion
    }
}
