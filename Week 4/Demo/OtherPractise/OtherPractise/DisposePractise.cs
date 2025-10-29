namespace OtherPractise
{
    class MyClass : IDisposable
    {
        public MyClass() 
        {
            Console.WriteLine("MyClass constructor");
        }
        public void MyMethod()
        {
            Console.WriteLine("MyMethod called");
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing MyClass resources.");
        }
    }
    internal class DisposePractise
    {
        static void Main(string[] args)
        {
            using (MyClass myClass = new MyClass())
            {
                myClass.MyMethod();
            } // Dispose is called automatically here

            // It is syntax sugar for:
            //try
            //{

            //}
            //finally
            //{
            //    myClass.Dispose();
            //}
        }
    }
}
