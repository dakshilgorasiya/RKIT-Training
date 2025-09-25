namespace DataTypePractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 0.1f;
            double b = 0.1;
            // Not recommended for financial calculations
            Console.WriteLine(a + b); // 0.20000000149011612

            // Use decimal for financial calculations
            decimal c = 0.1m;
            decimal d = 0.2m;
            Console.WriteLine(c + d); // 0.3
        }
    }
}
