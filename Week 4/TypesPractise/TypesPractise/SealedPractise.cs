using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesPractise
{
    public sealed class SealedClass
    {
        public void Display()
        {
            Console.WriteLine("This is a sealed class.");
        }
    }
    //public class derived: SealedClass // This will cause a compile-time error
    //{
    //}

    public class BaseClass1
    {
        public virtual void Show()
        {
            Console.WriteLine("BaseClass Show method");
        }
    }

    public class DerivedClass1 : BaseClass1
    {
        public sealed override void Show()
        {
            Console.WriteLine("DerivedClass Show method");
        }
    }

    public class FurtherDerivedClass1 : DerivedClass1
    {
        //public override void Show() // This will cause a compile-time error
        //{
        //    Console.WriteLine("FurtherDerivedClass Show method");
        //}
    }

    internal class SealedPractise
    {
        static void Main(String[] args)
        {
            DerivedClass1 obj = new DerivedClass1();
            obj.Show();
        }
    }
}
