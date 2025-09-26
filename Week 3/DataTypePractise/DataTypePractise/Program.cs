namespace DataTypePractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 0.1f;
            double b = 0.1;
            // Not recommended for financial calculations
            //Console.WriteLine(a + b); // 0.20000000149011612

            // Use decimal for financial calculations
            decimal c = 0.1m;
            decimal d = 0.2m;
            //Console.WriteLine(c + d); // 0.3

            // Null coalescing operator
            string? str = null;
            string result = str ?? "Default Value" ?? "HI";

            //Console.WriteLine(result); // Outputs "Default Value"


            // as keyword
            object obj1 = "Hello, World!";
            object obj2 = 12345;

            string? str1 = obj1 as string; // Successful cast
            string? str2 = obj2 as string; // Unsuccessful cast, str2 will be null

            Console.WriteLine(str1 == null ? "null" : str1); // Outputs: Hello, World!
            Console.WriteLine(str2 == null ? "null" : str2); // Outputs: null

            // string interpolation
            Console.WriteLine($"String interpolation: {str1}, {result}");
            Console.WriteLine(string.Format("String format: {0}, {1}", str1, result));

            HttpClient client = new HttpClient();
        }
    }
}
