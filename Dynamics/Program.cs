using System;

namespace Training.Csharp.Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadLine();

            //DoMethodPointSample();

            //DoDelegateLikeEvents();

            //DoMethodParamterSample();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static void DoMethodPointSample()
        {
            var methodPointerSample = new MethodPointerSample(20);

            //Create pointer to add method
            var arithmeticOperationAdd = new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Add);
            //Create pointer to sub method
            var arithmeticOperationSub = new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Sub);
            //Create pointer to mul method
            var arithmeticOperationMul = new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Mul);

            //Call pointer
            Console.WriteLine(arithmeticOperationAdd(10));

            Console.ReadLine();

            //Call pointer
            Console.WriteLine(arithmeticOperationSub(25));

            Console.ReadLine();

            //Call pointer
            Console.WriteLine(arithmeticOperationMul(2));

            Console.ReadLine();
        }

        private static void DoDelegateLikeEvents()
        {
            MethodPointerSample.DoArithmeticOperation arithmeticOperations = null;

            var methodPointerSample = new MethodPointerSample(20);

            //Attach method to delegate like event
            arithmeticOperations += new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Add);
            //Attach method to delegate like event
            arithmeticOperations += new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Sub);
            //Attach method to delegate like event
            arithmeticOperations += new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Mul);

            //call delegate --> call attached events
            arithmeticOperations(10);

            Console.WriteLine(methodPointerSample.GetResult());
        }

        private static void DoMethodParamterSample()
        {
            var methodParameterSample = new MethodParamterSample();

            //Delegate as parameter
            methodParameterSample.Print(MethodParamterSample.ConsolePrint, "Hello World to console");

            Console.ReadLine();

            //Delegate as parameter
            methodParameterSample.Print(MethodParamterSample.FileSystemPrint, "Hello World to file system");
        }
    }
}
