using System;

internal class MyFile
{
    public static void MyMethod()
    {
        Console.WriteLine("MyMethod in MyFile global namespace");
    }
}


// Namespace can be written in multiple files
namespace myNamespace1
{
    class B
    {
        public static void MyMethod()
        {
            Console.WriteLine("MyMethod in myNamespace1.B");
        }
    }
}
