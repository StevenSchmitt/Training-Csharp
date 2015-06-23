using System;
using System.Collections.Generic;

namespace Training.Csharp.MethodParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadLine();

            //DoKeywordSamples();

            //DoOptionalAndNamedParameters();

            DoInitializerSamples();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static void DoKeywordSamples()
        {
            var keywordSamples = new KeywordSamples();

            //Call by value with value types
            int intValue = 100;
            keywordSamples.ByValue(intValue);
            Console.WriteLine("By Value: " + intValue);
            Console.ReadLine();

            //Call by reference with ref and value types
            intValue = 100;
            keywordSamples.ByReference(ref intValue);
            Console.WriteLine("By Reference: " + intValue);
            Console.ReadLine();

            //Call by reference with out, value types and multiple return values
            int intValue2; //initializing not necessary
            int intValue3; //initializing not necessary
            keywordSamples.ByReference(out intValue2, out intValue3);
            Console.WriteLine("intValue2: " + intValue2 + ", intValue3: " + intValue3);
            Console.ReadLine();

            //Call by value with reference types
            KeywordSamples.Data data = new KeywordSamples.Data("old value", 100);
            keywordSamples.ByValue(data);
            Console.WriteLine("By Value: StringValue-Property: " + data.StringValue + ", IntValue-Property: " + data.IntValue);
            Console.ReadLine();

            //Call by reference with reference types
            data = new KeywordSamples.Data("old value", 100);
            keywordSamples.ByReference(ref data);
            Console.WriteLine("By Reference: StringValue-Property: " + data.StringValue + ", IntValue-Property: " + data.IntValue);
            Console.ReadLine();

            //Call by value with reference types but no new instance of 'data' variable 
            data = new KeywordSamples.Data("old value", 100);
            keywordSamples.ByValue2(data);
            Console.WriteLine("By Value: StringValue-Property: " + data.StringValue + ", IntValue-Property: " + data.IntValue);
            Console.ReadLine();

            //Not possible!!!
            //KeywordSamples.Data data = new KeywordSamples.Data("old value", 1);
            //keywordSamples.ByReference(ref data.IntValue);

            //Call method with params by comma-separated list
            int sum;
            sum = keywordSamples.Sum(1, 2, 3, 4, 5);
            Console.WriteLine("Params Sum comma-separated list: " + sum);
            Console.ReadLine();

            //Call method with params by array
            int[] intArray = { 1, 2, 3, 4, 5 };
            sum = keywordSamples.Sum(intArray);
            Console.WriteLine("Params Sum array: " + sum);
            Console.ReadLine();

            //Call method with params 0 arguments
            sum = keywordSamples.Sum();
            Console.WriteLine("Params Sum 0: " + sum);
            Console.ReadLine();

            //Call method with params
            int diff = keywordSamples.Sub(10, 1, 2, 3);// Minuend: 10, Subtrahend: 1, 2, 3
            Console.WriteLine("Params Sub: " + diff);
            Console.ReadLine();
        }

        private static void DoOptionalAndNamedParameters()
        {
            var optionalAndNamedSamples = new OptionalAndNamedSamples();

            //Default call
            Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature(20, 10, 40));
            Console.ReadLine();

            //Call with optional parameters and default values
            Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature(20));
            Console.ReadLine();

            //Call with named arguments
            Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature(20, min: 15, max: 19));
            Console.ReadLine();

            //Call with optional parameters and named arguments
            Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature(20, max: 15));
            Console.ReadLine();

            //Wrong call
            //Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature(max: 15, 20, min: 20));
            //Console.ReadLine();

            //Which method is called???
            Console.WriteLine("Is temperature okay: " + optionalAndNamedSamples.CheckTemperature2(20));
            Console.ReadLine();
        }

        private static void DoInitializerSamples()
        {
            //Object initializers

            //Old style
            Car focus = new Car("Focus");
            focus.Kw = 74;
            focus.Price = 25000;

            Producer ford = new Producer();
            ford.Name = "Ford";
            ford.Location = "Detroit";

            focus.Producer = ford;

            //object initializer --> need default constructor
            //Car mondeo = new Car { ModelName = "Mondeo", Kw = 100, Price = 35000, Producer = ford };

            //object initializer --> attention double initialization: ModelName!!!
            Car kuga = new Car("Mondeo") { ModelName = "Kuga", Kw = 100, Price = 35000, Producer = ford };

            //Nested object initializer
            //Car a3 = new Car
            //{
            //    ModelName = "A3",
            //    Kw = 135,
            //    Price = 40000,
            //    Producer = new Producer() { Name = "Audi", Location = "Ingolstadt" }
            //};

            //Collection initializers

            //Old style
            var cars = new List<Car>();
            Car a4 = new Car("A4");
            focus.Kw = 200;
            focus.Price = 45000;
            cars.Add(a4);
            //...
            //...
            //...

            //Collection initializer
            var producers = new List<Producer>
            { 
                new Producer { Name = "Mercedes", Location = "Stuttgart" },
                new Producer { Name = "BMW", Location = "München" },
                new Producer { Name = "Opel", Location = "Rüsselsheim" }
            };
        }
    }
}
