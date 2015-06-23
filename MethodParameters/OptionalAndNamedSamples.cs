namespace Training.Csharp.MethodParameters
{
    public class OptionalAndNamedSamples
    {
        public bool CheckTemperature(int temperature, int min = 15, int max = 30)
        {
            if (temperature < min || temperature > max)
                return false;
            else
                return true;
        }

        public bool CheckTemperature2(int temperature)
        {
            return true;
        }

        public bool CheckTemperature2(int temperature, int max = 19)
        {
            if (temperature > max)
                return false;
            else
                return true;
        }
    }
}
