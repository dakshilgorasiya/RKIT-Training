using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesPractise
{
    interface IFirstInterface
    {
        void MethodA();
        public void MethodB();

        protected void MethodC()
        {
            Console.WriteLine("Private MethodC in IFirstInterface");
        }
        static int a = 15;

        int prop { get; }
    }

    class FirstClass : IFirstInterface
    {
        public int prop { get; set; }

        public void MethodA()
        {
            Console.WriteLine("MethodA implementation in FirstClass");
        }

        public void MethodB()
        {
            Console.WriteLine("MethodB implementation in FirstClass");
        }

        public void MethodC()
        {
            Console.WriteLine("MethodC implementation in FirstClass");
        }
    }


    interface ISecondInterface
    {
        void MethodD();
    }

    class SecondClass : ISecondInterface
    {
        // Explicit interface implementation
        void ISecondInterface.MethodD()
        {
            Console.WriteLine("MethodD implementation in SecondClass");
        }
    }

    internal class InterfacePractise
    {
        static void Main(string[] args)
        {
            // It refers to the methods defined in the interface only
            IFirstInterface firstInterface = new FirstClass();
            firstInterface.MethodA();
            firstInterface.MethodB();
            //firstInterface.MethodC();  // Error: MethodC is not accessible because it is protected in the interface
            Console.WriteLine(IFirstInterface.a);
            //firstInterface.prop = 20; // Error: Cannot assign to 'prop' because it is read-only in interface
            Console.WriteLine(firstInterface.prop);

            // It refers to all the methods defined in the class
            FirstClass firstClass = new FirstClass();
            firstClass.MethodA();
            firstClass.MethodB(); 
            firstClass.MethodC();  // Can access as method is public in the class
            firstClass.prop = 25; // Can assign as property has both get and set in the class
            Console.WriteLine(firstClass.prop);


            ISecondInterface secondInterface = new SecondClass();
            secondInterface.MethodD();

            SecondClass secondClass = new SecondClass();
            //secondClass.MethodD(); // Error: MethodD is not accessible because it is implemented explicitly
        }
    }
}
