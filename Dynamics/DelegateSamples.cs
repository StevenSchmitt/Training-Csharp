using System;
using System.IO;

namespace Training.Csharp.Dynamics
{
    public class MethodPointerSample
    {
        public delegate int DoArithmeticOperation(int value);

        private int _startValue;

        public MethodPointerSample(int start)
        {
            _startValue = start;
        }

        public int Add(int value)
        {
            _startValue += value;
            return _startValue;
        }

        public int Sub(int value)
        {
            _startValue -= value;
            return _startValue;
        }

        public int Mul(int value)
        {
            _startValue *= value;
            return _startValue;
        }

        public int GetResult()
        {
            return _startValue;
        }
    }

    public class MethodParamterSample
    {
        //Delegate
        public delegate void DoPrint(string valueToPrint);

        //Delegate caller --> delegate is method parameter
        public void Print(DoPrint print, string value)
        {
            print(value);
        }

        //1 Print to console 
        public static void ConsolePrint(string value)
        {
            Console.WriteLine(value);
        }

        //2 Print to file system
        public static void FileSystemPrint(string value)
        {
            File.WriteAllText(@"C:\DelegatePrint.txt", value);
        }
    }
}
