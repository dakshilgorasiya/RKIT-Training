namespace DesignPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton ob1 = Singleton.Instance;
            Console.WriteLine(ob1.Id);

            Singleton ob2 = Singleton.Instance;
            Console.WriteLine(ob2.Id);

            Singleton ob3 = Singleton.Instance;
            Console.WriteLine(ob3.Id);



            VehicleFactory factory = new CarFactory();
            factory.StartJourney();
        }
    }
}