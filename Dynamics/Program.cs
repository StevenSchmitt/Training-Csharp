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

            //DoAnonymousTypesSample();

            //DoAnonymousMethodSample();

            //DoLambdaSamples();

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

        private static void DoAnonymousTypesSample()
        {
            var anonymeType = new { FirstName = "Steven", LastName = "Schmitt", Age = 30};
            
            //Now available in intellisense!!!

            //useful ToString()-Method
            Console.WriteLine(anonymeType.ToString());

            Console.ReadLine();

            //Can call properties
            Console.WriteLine(string.Format("My name is {0}. I'm {1} years old.", anonymeType.FirstName, anonymeType.Age));
        }

        private static void DoAnonymousMethodSample()
        {
            var methodPointerSample = new MethodPointerSample(20);

            //Define anonymous method
            MethodPointerSample.DoArithmeticOperation operation = delegate(int number)
            {
                Console.WriteLine("This is an anomymous method call", number);
                return number;
            };

            //Call delegate
            operation(10);

            //Check result
            Console.WriteLine(methodPointerSample.GetResult());

            Console.ReadLine();

            //Attach other method to delegate
            operation = new MethodPointerSample.DoArithmeticOperation(methodPointerSample.Add);

            //Call delegate
            operation(10);

            //Check result
            Console.WriteLine(methodPointerSample.GetResult());
        }

        private static void DoLambdaSamples()
        {
            var lambdaSamples = new LambdaSamples();

            lambdaSamples.CallDefaultDelegate();

            Console.ReadLine();

            lambdaSamples.CallAnonymousMethod();

            Console.ReadLine();

            lambdaSamples.CallLambdaExpression();

            Console.ReadLine();

            lambdaSamples.CallLambdaStatement();

            Console.ReadLine();

            //Lambda as parameter inline
            Console.WriteLine("Lambda as parameter: " + lambdaSamples.CallLambdaParameter((a, b) => a + b, 5, 6));

            Console.ReadLine();

            //Lambda as parameter inline
            Console.WriteLine("Lambda as parameter: " + lambdaSamples.CallLambdaParameter((a, b) => a * b, 5, 6));

            Console.ReadLine();

            //Lambda as parameter inline
            //Only 1 parameter!!
            Console.WriteLine("Lambda as parameter: " + lambdaSamples.CallLambdaParameter(a => a * 5, 6));

            Console.ReadLine();
        }
    }
}
