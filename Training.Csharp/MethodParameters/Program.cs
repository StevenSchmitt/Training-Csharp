using System;

namespace MethodParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywordSamples = new KeywordSamples();

            Console.WriteLine("Start");
            Console.ReadLine();

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

            Console.WriteLine("Finish");
            Console.ReadLine();
        }
    }
}
