namespace Training.Csharp.Operators
{
    public class Person
    {
    }

    interface ISchoolEmployee
    {
        void Do();
    }

    public class Student : Person
    {
    }

    public class FacilityManager : Person, ISchoolEmployee
    {
        public void Do()
        {
            //TODO
        }
    }

    public class Teacher : Person, ISchoolEmployee
    {
        public void Do()
        {
            //TODO
        }
    }
}
