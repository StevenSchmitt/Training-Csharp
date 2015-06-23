namespace Training.Csharp.MethodParameters
{
    public class Car
    {
        //public Car()
        //{
        //    //TODO
        //}

        public Car(string modelName)
        {
            ModelName = modelName;
        }

        public string ModelName { get; set; }

        public int Kw { get; set; }

        public decimal Price { get; set; }

        public Producer Producer { get; set; }
    }

    public class Producer
    {
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
