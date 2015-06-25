using System;
using System.Collections.Generic;

namespace Training.Csharp.Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoExtensionMethodSamples();

            //DoPartialTypesMethodsSample();
        }

        private static void DoExtensionMethodSamples()
        {
            var newString = "! h e l l o w o r l d !".MyStringManipulation();

            var data = new List<string> { "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello" };
            int count = data.MyCount<string>();
        }

        private static void DoPartialTypesMethodsSample()
        {
            //Show Person calls here
            //var person = new Person("Steven", "Schmitt");
            //person.Eat("Vegetable");
        }
    }
}
