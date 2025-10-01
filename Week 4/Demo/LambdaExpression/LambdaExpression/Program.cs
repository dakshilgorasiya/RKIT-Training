namespace LambdaExpression
{
    class MyClass
    {
        public Func<int> printIt; 
        public void Fun()
        {
            int x = 5;

            printIt = () => x;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lambda with single parameter and a return value
            Func<int, int> Square = x => x * x;
            Console.WriteLine(Square(5)); // Output: 25

            // Lambda with multiple parameters with no return value
            Action<string> Greet = name => Console.WriteLine($"Hello, {name}!");
            Greet("Alice"); // Output: Hello, Alice!

            // multiple statements in the lambda body
            Action<string> Greet2 = (name) =>
            {
                string greeting = $"Hello, {name}!";
                Console.WriteLine(greeting);
            };
            Greet2("Bob"); // Output: Hello, Bob!

            // Lambda with no parameters
            Action printMessage = () => Console.WriteLine("No parameters here!");
            printMessage(); // Output: No parameters here!

            // Default parameter values in lambda expressions
            var Increment = (int x, int incrementBy = 1) => x + incrementBy;
            Console.WriteLine(Increment(5)); // Output: 6
            Console.WriteLine(Increment(5, 3)); // Output: 8

            // async lambda expressions
            var wait = async (int milliseconds) =>
            {
                await Task.Delay(milliseconds);
                Console.WriteLine($"Waited for {milliseconds} milliseconds");
            };
            wait(500).Wait();

            // Tuple parameters in lambda expressions
            Func<(int, int), (int, int)> doubleIt = (tuple) => (tuple.Item1 * 2, tuple.Item2 * 2);
            (int, int) result = doubleIt((3, 4));
            Console.WriteLine(result.Item1 + " " + result.Item2); // Output: (6, 8)


            // Closure example
            MyClass myClass = new MyClass();
            //Console.WriteLine(myClass.printIt()); // Error : printIt is not assigned
            myClass.Fun();
            Console.WriteLine(myClass.printIt());


            // Lambda expression in LINQ
            List<int> l = new List<int> { 1, 2, 3, 4, 5 };
            l.Where(x => x%2 == 0).ToList().ForEach(x => Console.WriteLine(x)); // Output: 2 4
        }
    }
}
