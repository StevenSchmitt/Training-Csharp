using System;

namespace Training.Csharp.Extensibility
{
    //class Person 1
    public partial class Person : IDisposable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Dispose()
        {
            //TODO
        }

        public void Walk()
        {
            //TODO
        }
    }
    //class Person 2
    //merge: IComparable, Eat, EatHook
    public partial class Person : IComparable
    {
        public int CompareTo(object obj)
        {
            return 0;
        }

        public void Eat(string food)
        {
            //Hook call
            EatHook(food);
        }

        //Hook
        partial void EatHook(string food);
    }

    //class Person 3
    //Merge: Serializable, ICloneable, Constructor
    [Serializable]
    public partial class Person : ICloneable
    {
        //Constructor
        public Person(string firstName, string lastName)
        {
            //access properties
            FirstName = firstName;
            LastName = lastName;
        }

        public object Clone()
        {
            return new object();
        }
    }

    //class Person 4
    //Hook implementation
    public partial class Person
    {
        //Comment out this method and the program 
        //will still compile.
        partial void EatHook(string food)
        {
            if (food == "Vegetable")
                throw new ArgumentException("I don't like vegetable");
        }
    }
}
