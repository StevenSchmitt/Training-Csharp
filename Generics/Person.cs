using System;

namespace Training.Csharp.Generics
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
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
