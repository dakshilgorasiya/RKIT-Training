namespace EnumPractise
{
    public enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    [Flags]
    public enum FileAccess
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Days today = Days.Wednesday;
            //Console.WriteLine($"Today is {today} value is {(int)today}");

            bool isValid = Enum.IsDefined(typeof(Days), "Sunday");
            //Console.WriteLine($"Is 'Sunday' a valid day? {isValid}");
            //Days parsed = Enum.Parse<Days>("Friday");
            Days parsed = (Days)Enum.Parse(typeof(Days), "Friday");
            //Days parsed;
            //isValid = Enum.TryParse<Days>("Sunday", out parsed);
            //Console.WriteLine($"Parsed day: {parsed} value is {(int)parsed}");

            FileAccess permission = FileAccess.Read | FileAccess.Write;
            Console.WriteLine($"Permission: {permission} value is  { (int)permission }");

            if((permission & FileAccess.Write) == FileAccess.Write)
            {
                Console.WriteLine("Write permission granted.");
            }
            else
            {
                Console.WriteLine("Write permission denied.");
            }


            // Typecasting
            Days day = (Days)2;
            Console.WriteLine($"Day: {day} value is {(int)day}");
        }
    }
}
