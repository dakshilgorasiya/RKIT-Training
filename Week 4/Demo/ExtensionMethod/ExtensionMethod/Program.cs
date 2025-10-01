namespace ExtensionMethod
{
    public static class StringExtension
    {
        public static int WordCount(this string s)
        {
            return s.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static void Substring(this string s, int start, int count)
        {
            Console.WriteLine("Never called");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello how are you?";
            Console.WriteLine(s.WordCount());

            s.Substring(0, s.Length - 1);  // Will call instance method not extension one
        }
    }
}
