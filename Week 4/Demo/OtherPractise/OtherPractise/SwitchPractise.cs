using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherPractise
{
    internal class SwitchPractise
    {
        static void Main(string[] args)
        {
            int day = 3;

            switch(day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                default:
                    Console.WriteLine("Invalid day");
                    break;
            }

            switch(day)
            {
                case 1:
                case 7:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Weekday");
                    break;
            }

            // switch expression
            string dayName = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Invalid" // Default
            };

            Console.WriteLine(dayName);

            int i = 10;
            switch(i)
            {
                case int when (i < 0):
                    Console.WriteLine("Negative number");
                    break;

                case int when (i > 0):
                    Console.WriteLine("Positive number");
                    break;

                default:
                    Console.WriteLine("Zero");
                    break;
            }

            // switch expression
            string category = i switch
            {
                > 0 => "Positive",
                < 0 => "Negative",
                0 => "Zero",
            };

            Console.WriteLine(category);
        }
    }
}
