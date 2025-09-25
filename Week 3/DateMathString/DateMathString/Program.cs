using System.Text;
using System.Text.RegularExpressions;

namespace DateMathString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Date
            //Console.WriteLine("DATE");
            //Console.WriteLine(DateTime.Now); // Current date and time  -> 22/09/2025 3:06:11 pm
            //Console.WriteLine(DateTime.Today.Month); // Current month -> 9
            //Console.WriteLine(DateTime.Now.DayOfWeek); // Current day of the week Monday, Tuesday, etc. -> Monday
            //Console.WriteLine(DateTime.Today.AddDays(5).AddHours(3).AddMinutes(30)); // Date and time 5 days, 3 hours, and 30 minutes from now -> 27/09/2025 3:30:00 am

            //DateTime dt = new DateTime(2026, 1, 1);
            //Console.WriteLine(dt.Subtract(DateTime.Now));  // Timespan -> 100.08:53:11.3445369
            //Console.WriteLine(dt.ToString("d")); // 01/01/2026
            //Console.WriteLine(dt.ToString("D")); // Wednesday, 01 January 2026
            //Console.WriteLine(DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss tt")); // Custom format -> 22-07-2025 15:07:06 pm

            //bool isValid = DateTime.TryParse("01/01/01 15:01:20", out DateTime parsedDate);
            //if (isValid)
            //{
            //    Console.WriteLine(parsedDate); // 01/01/2001 3:01:20 PM
            //}

            //DateTime diwali = new DateTime(2025, 10, 20);
            //Console.WriteLine(diwali.Subtract(DateTime.Now));  // diwali - currentTime -> 27.09:05:38.7503654   27 days 9 hours 5 minutes 38 seconds
            //Console.WriteLine(diwali.Subtract(DateTime.Now).TotalDays); // 27.37812572086574  total days as fraction
            //Console.WriteLine(diwali.Subtract(DateTime.Now).TotalHours); // 657.0662035800833
            //Console.WriteLine(diwali.Subtract(DateTime.Now).Hours); // 9 hours part only

            //TimeSpan duration = diwali - DateTime.Now;
            //Console.WriteLine($"Time until Diwali: {duration.Days} days, {duration.Hours} hours, {duration.Minutes} minutes, {duration.Seconds} seconds");

            //DateTime now = DateTime.Now;
            //TimeSpan fiveHour = TimeSpan.FromHours(5);
            //Console.WriteLine(now + fiveHour); // current time + 5 hours -> 22/09/2025 8:07:54 pm
            //Console.WriteLine(now.Add(fiveHour)); // current time + 5 hours -> 22/09/2025 8:07:54 pm

            //DateTimeOffset local = DateTimeOffset.Now;
            //Console.WriteLine(local); // current date and time with offset  22/09/2025 3:04:26 pm +05:30
            //Console.WriteLine(local.Offset); // 05:30:00

            //DateTimeOffset utc = DateTimeOffset.UtcNow;
            //Console.WriteLine(utc); // 22/09/2025 9:34:43 am +00:00


            //Console.WriteLine(DateOnly.FromDateTime(DateTime.Now)); // Current date -> 22/09/2025
            //Console.WriteLine(DateOnly.FromDateTime(DateTime.Now).AddDays(10)); // Date 10 days from now -> 02/10/2025
            //Console.WriteLine(DateOnly.Parse("01/01/2026").Year); // 2026

            //Console.WriteLine(TimeOnly.FromDateTime(DateTime.Now)); // Current time -> 3:11 pm

            //TimeOnly start = new TimeOnly(9, 0, 0); // 9 AM
            //TimeOnly end = new TimeOnly(17, 0, 0); // 5 PM
            //TimeOnly currTime = TimeOnly.FromDateTime(DateTime.Now);
            //Console.WriteLine(currTime.IsBetween(start, end) ? "Working hours" : "Off hours"); // Working hours


            // String
            //Console.WriteLine("STRING");
            //string message = "Hello, World! Welcome to C# programming.";
            //Console.WriteLine(message);
            //Console.WriteLine(message.Length); // Length of the string -> 40
            //Console.WriteLine(message.IndexOf("C#"));  // Position of substring -> 25
            //Console.WriteLine(message.Substring(25)); // start index -> C# programming.
            //Console.WriteLine(message.Substring(25, 2)); // start index, len -> C#
            //Console.WriteLine(message.Replace("C#", "CSharp")); // Hello, World! Welcome to CSharp programming.
            //Console.WriteLine(message.ToUpper()); // HELLO, WORLD! WELCOME TO C# PROGRAMMING.

            //string m2 = "     hi     ";
            //Console.WriteLine(m2.Trim()); // "hi"
            //Console.WriteLine(m2.TrimStart()); // "hi     "
            //Console.WriteLine(m2.TrimEnd()); // "     hi"

            //string[] words = message.Split(' ');
            //foreach (var word in words)
            //{
            //    Console.WriteLine(word);
            //}

            //Console.WriteLine(string.Join(" ", words));  // separator, IEnumerable<string> -> Hello, World! Welcome to C# programming.

            //Console.WriteLine(string.IsNullOrEmpty(""));  // True
            //Console.WriteLine(string.IsNullOrEmpty(" ")); // False
            //Console.WriteLine(string.IsNullOrEmpty(" ABC ")); // False

            //string name = "dakshil";
            //Console.WriteLine(string.Format("Hello {0}", name)); // Hello dakshil

            //Console.WriteLine(message.Contains("C#") ? "Found" : "Not Found"); // Found
            //Console.WriteLine(message.StartsWith("Hello") ? "Yes" : "No"); // Yes
            //Console.WriteLine("abc" + "def"); // abcdef
            //Console.WriteLine("abc" == "abc"); // True




            //StringBuilder stringBuilder = new StringBuilder("Hello ");
            //stringBuilder.Append("Dakshil");
            //Console.WriteLine(stringBuilder); // Hello Daskhil

            //stringBuilder.Insert(0, "HI"); // start index, string
            //Console.WriteLine(stringBuilder);  // HiHello Dakshil

            //stringBuilder.Remove(0, 2); // start index, len
            //Console.WriteLine(stringBuilder);  // Hello Dakshil

            //stringBuilder.Replace("Dakshil", "World");
            ////stringBuilder[5] = 'H';   // no error
            //Console.WriteLine(stringBuilder);  // Hello World

            //string final = stringBuilder.ToString(); // Converts to immutable string
            ////final[5] = ','; // error: cannot modify but can read
            //Console.WriteLine(final);  // Hello World
            //Console.WriteLine(final[1]);


            //string pattern = @"^\w+@\w+\.\w{2,4}$";
            //Console.WriteLine(Regex.IsMatch("test@gmail.com", pattern));

            //string patternNumber = @"\d";
            //Match result = Regex.Match("ab32b32n2234nj", patternNumber);
            //if (result.Success)
            //{
            //    Console.WriteLine(result.Value); // 3
            //}

            //MatchCollection result2 = Regex.Matches("ab32b32n2234nj", patternNumber);
            //foreach (Match m in result2)
            //{
            //    Console.Write(m.Value + " "); // 3 2 3 2 2 2 3 4  
            //}
            //Console.WriteLine();

            //string replaced = Regex.Replace("ab32b32n2234nj", patternNumber, "#");
            //Console.WriteLine(replaced); // ab##b##n####nj


            Console.WriteLine("MATH");
            //Console.WriteLine("PI : " + Math.PI); // 3.141592653589793
            //Console.WriteLine("E : " + Math.E); // 2.718281828459045

            //double num = 5.67;
            //Console.WriteLine("Abs : " + Math.Abs(-num)); // 5.67
            //Console.WriteLine("Ceiling : " + Math.Ceiling(num)); // 6
            //Console.WriteLine("Floor : " + Math.Floor(num)); // 5
            //Console.WriteLine("Round : " + Math.Round(num)); // 6
            //Console.WriteLine("Truncate : " + Math.Truncate(num)); // 5

            //Console.WriteLine(Math.Pow(2, 8)); // 256
            //Console.WriteLine(Math.Sqrt(64)); // 8

            //Console.WriteLine(Math.Max(10, 20)); // 20
            //Console.WriteLine(Math.Min(10, 20)); // 10

            //Console.WriteLine(Math.Sign(-55)); // -1
            //Console.WriteLine(Math.Sign(0)); // 0
            //Console.WriteLine(Math.Sign(55)); // 1

            //Console.WriteLine(Math.Sin(15)); // 0.6502878401571168

            //Console.WriteLine(Math.Exp(1)); // 2.718281828459045
            //Console.WriteLine(Math.Log(Math.E)); // natural log -> 1
            //Console.WriteLine(Math.Log10(100)); // base 10 log -> 2
            //Console.WriteLine(Math.Log(256, 2)); // base 2 log -> 8
        }
    }
}
