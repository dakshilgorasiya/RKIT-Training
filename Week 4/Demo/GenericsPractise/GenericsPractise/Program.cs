namespace GenericsPractise
{
    class GClass1<T>
    {
        public static int count = 0;
        public GClass1(T val)
        {
            Console.WriteLine(val);
            count++;
        }

        public void Add(T val)
        {
            Console.WriteLine(val);
        }

        public void Display<U>(U val1, T val2)
        {
            Console.WriteLine(val1 + " " + val2);
        }
    }

    interface IGen<T>
    {
        void Show(T val);
    }

    class GenClass<T> : IGen<T>
    {
        public void Show(T val)
        {
            Console.WriteLine(val);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GClass1<int> obj = new (10);
            obj.Add(20);
            obj.Display<string>("Hello", 30);

            GClass1<string> obj1 = new ("Generics");
            obj1.Add("in C#");
            obj1.Display<int>(100, "C#");

            // Static member is shared among all objects of the same generic type
            Console.WriteLine("Count of objects created: " + GClass1<int>.count);
            Console.WriteLine("Count of objects created: " + GClass1<string>.count);


            GenClass<int> genObj = new GenClass<int>();
            genObj.Show(123);
            IGen<int> igen = genObj;
            igen.Show(456);
        }
    }
}
