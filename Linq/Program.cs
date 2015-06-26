using System;

namespace Training.Csharp.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadLine();

            //LinqToObjectSamples.SimpleFilter();

            //LinqToObjectSamples.ModifyData();

            //LinqToObjectSamples.CalculationQueries();

            //LinqToObjectSamples.ComplexObjects();

            //LinqToXmlSamples.CreateXml();

            //LinqToXmlSamples.SaveXml();

            //LinqToXmlSamples.LoadXml();

            //LinqToXmlSamples.QueryXml();

            LinqToSqlSamples.Read();

            //LinqToSqlSamples.Create();

            //LinqToSqlSamples.Update();

            //LinqToSqlSamples.Delete();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }
    }
}
