using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.Csharp.Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //old style --> everything allow in compile time: not type safety
            ArrayList persons = new ArrayList
            {
                new Student { FirstName = "Tom", LastName = "Meier", RegistrationId = 1234 },
                new Teacher { FirstName = "Franz", LastName = "Schmitt", EmployeeId = 22 },
                new FacilityManager { FirstName = "Peter", LastName = "Lustig", EmployeeId = 47 }
            };

            foreach (var person in persons)
            {
                Console.WriteLine(((ISchoolEmployee)person).EmployeeId);//You need cast
                //runtime error --> InvalidCastException!!!
            }

            IList<ISchoolEmployee> persons2 = new List<ISchoolEmployee>
            {
                //new Student { FirstName = "Tom", LastName = "Meier", RegistrationId = 1234 }, //--> compile time error
                new Teacher { FirstName = "Franz", LastName = "Schmitt", EmployeeId = 22 },
                new FacilityManager { FirstName = "Peter", LastName = "Lustig", EmployeeId = 47 }
            };

            foreach (var person in persons2)
            {
                Console.WriteLine(person.EmployeeId);//No cast needed
            }

            Console.ReadLine();
        }

        //Restriction T is any class
        public class GenericClass<T> where T : class
        {
            //Generic method
            public T Do(T type)
            {
                return type;
            }
        }

        //Normal class
        public class NormalClass
        {
            //Generic method in normal class
            public T Do<T>(T type) where T : class
            {
                return type;
            }
        }

        //Restriction T direve from class Person
        public class GenericClass2<T> where T : Person
        {
            //Generic method
            public T Do(T type)
            {
                return type;
            }
        }

        //Restriction T implement interface ISchoolEmployee
        public class GenericClass3<T> where T : ISchoolEmployee
        {
            //Generic method
            public T Do(T type)
            {
                return type;
            }
        }

        //Restriction T has public parameterless constructor
        public class GenericClass4<T> where T : new()
        {
            //Generic method
            public T Do(T type)
            {
                return type;
            }
        }
    }
}
