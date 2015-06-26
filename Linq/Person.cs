using System;

namespace Training.Csharp.Linq
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    public interface ISchoolEmployee
    {
        int EmployeeId { get; set; }
    }

    public class Student : Person
    {
        public int RegistrationId { get; set; }
    }

    public class FacilityManager : Person, ISchoolEmployee
    {
        public int EmployeeId { get; set; }
    }

    public class Teacher : Person, ISchoolEmployee
    {
        public int EmployeeId { get; set; }
    }
}
