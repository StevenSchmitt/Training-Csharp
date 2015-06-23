namespace MethodParameters
{
    public class KeywordSamples
    {
        #region ref and out

        #region ref

        public void ByReference(ref int number)
        {
            number = 2;
        }

        public void ByReference(ref Data data)
        {
            data = new Data("New value", 2);
        }

        #endregion

        #region out

        public void ByReference(out int number, out int number2)
        {
            number = 2;
            number2 = 3;
        }

        #endregion

        public void ByValue(int number)
        {
            number = 2;
        }

        public void ByValue(Data data)
        {
            data = new Data("New value", 2);
        }

        public void ByValue2(Data data)
        {
            data.StringValue = "New value";
            data.IntValue = 2;
        }

        public class Data
        {
            public Data(string stringValue, int intValue)
            {
                StringValue = stringValue;
                IntValue = intValue;
            }

            public string StringValue { get; set; }

            public int IntValue { get; set; }
        }

        #endregion

        #region params

        public int Sum(params int[] values)
        {
            int sum = 0;

            foreach (var value in values)
            {
                sum = sum + value;
            }

            return sum;
        }

        public int Sub(int minuend, params int[] values)
        {
            int diff = minuend;

            foreach (var value in values)
            {
                diff = diff - value;
            }

            return diff;
        }

        #endregion
    }
}
