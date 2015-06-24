namespace Training.Csharp.Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ?:

            var temperature = 25;
            string infoMessage;

            //normal if-else style
            if (temperature >= 17)
            {
                infoMessage = "You can wear a t-shirt";
            }
            else
            {
                infoMessage = "A t-shirt is not recommended";
            }

            //short if-else
            infoMessage = temperature >= 17 ? "You can wear a t-shirt" : "A t-shirt is not recommended";

            //Nested short if-else
            infoMessage = temperature >= 17 ? temperature >= 30 ? "You can wear a tank top" : "You can wear a t-shirt" : "A t-shirt is not recommended";

            #endregion

            #region ??

            decimal? price = null;
            decimal result;

            //normal if-null-else style
            if (price == null) // or price.HasValue
            {
                result = default(int);
            }
            else
            {
                result = price.Value;
            }

            //Short if-null-else
            result = price ?? default(int);

            #endregion

            #region is, as

            //all persons, but not all school employees
            Person[] persons = new Person[3] { new Teacher(), new Student(), new FacilityManager() };

            //is as style
            foreach (var person in persons)
            {
                if (person is ISchoolEmployee)
                {
                    var schoolemployee = person as ISchoolEmployee;
                    schoolemployee.Do();
                }
            }

            //as statement
            var schoolEmployee2 = new Teacher() is ISchoolEmployee ? (ISchoolEmployee)new Teacher() : null;

                                                                   //                          ^  
            var schoolEmployee = new Teacher() as ISchoolEmployee; // <-- short statement for -|

            #endregion
        }
    }
}
