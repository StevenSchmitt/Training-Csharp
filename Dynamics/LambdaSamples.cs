using System;
namespace Training.Csharp.Dynamics
{
    public class LambdaSamples
    {
        //Delegate
        public delegate int DoArithmeticOperation(int value1, int value2);

        //Pointer method of delegate
        public int Sum(int value1, int value2)
        {
            Console.WriteLine("Default delegate call");
            return value1 + value2;
        }

        //Short review
        //1. Default delegate call
        public void CallDefaultDelegate()
        {
            DoArithmeticOperation operation = new DoArithmeticOperation(Sum);
            
            //Call
            var result = operation(5, 6);
            Console.WriteLine(result);
        }

        //Short review
        //2. Anonymous method call
        //Equals to 1. but another syntax
        public void CallAnonymousMethod()
        {
            //difference: no 'new DoArithmeticOperation'
            DoArithmeticOperation operation = delegate(int value1, int value2)
            {
                Console.WriteLine("Anonymous method call");
                return value1 + value2;
            };

            //Call
            var result = operation(5, 6);
            Console.WriteLine(result);
        }

        //3. Lambda expression call
        public void CallLambdaExpression()
        {
            //difference: no delegate keyword and type definition
            //only one expression possible!!
            DoArithmeticOperation operation = (value1, value2) => value1 + value2;

            //Call
            var result = operation(5, 6);
            Console.WriteLine("Lambda expression call");
            Console.WriteLine(result);
        }

        //4. Lambda statement call
        public void CallLambdaStatement()
        {
            //difference: you can define more than one statement / expression
            DoArithmeticOperation operation = (value1, value2) => 
            {
                Console.WriteLine("Lambda Statement call");
                return value1 + value2;
            };

            //Call
            var result = operation(5, 6);
            Console.WriteLine(result);
        }

        //5. Lambda expression is parameter
        public int CallLambdaParameter(DoArithmeticOperation operation, int value1, int value2)
        {
            return operation(value1, value2);
        }

        //5. Lambda expression is parameter with default delegate Func: https://msdn.microsoft.com/en-us/library/bb534960(v=vs.110).aspx
        //<int, int> --> first is parameter type, last is return type
        public int CallLambdaParameter(Func<int, int> func, int value1)
        {
            return func(value1);
        }
    }
}
