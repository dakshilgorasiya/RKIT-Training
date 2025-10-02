using System.Diagnostics;

namespace TypesPractise
{
    public abstract class BaseClass
    {
        protected BaseClass(int value)
        {
            Console.WriteLine($"BaseClass constructor called with value: {value}");
        }

        private int _v1;

        public int V1
        {
            get { return _v1; }
            set { _v1 = value; }
        }

        public abstract int AbstractProperty { get; set; }

        public virtual void VirtualMethod()
        {
            Console.WriteLine("BaseClass VirtualMethod called");
        }

        public void NonVirtualMethod()
        {
            Console.WriteLine("BaseClass NonVirtualMethod called; value is " + _v1);
        }

        public static void StaticMethod()
        {
            Console.WriteLine("BaseClass StaticMethod called");
        }

        public abstract void AbstractMethod();

    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass(int value) : base(value)
        {
            Console.WriteLine($"DerivedClass constructor called with value: {value}");
        }
        public override int AbstractProperty { get; set; }

        public override void VirtualMethod()
        {
            Console.WriteLine("DerivedClass VirtualMethod called");
        }

        public override void AbstractMethod()
        {
            Console.WriteLine("DerivedClass AbstractMethod implementation");
        }
    }

    
    


    internal class AbstractPractise
    {
        static void Main(string[] args)
        {
            DerivedClass derived = new DerivedClass(10);
            derived.V1 = 20;
            Console.WriteLine($"V1: {derived.V1}");
            derived.VirtualMethod();
            derived.NonVirtualMethod();
            BaseClass.StaticMethod();
            derived.AbstractMethod();
            derived.AbstractProperty = 30;
            Console.WriteLine("AbstractProperty: " + derived.AbstractProperty);
        }
    }
}
