namespace InheritancePractise
{
    public class Base
    {
        public void A()
        {
            Console.WriteLine("BASE A");
        }
        public virtual void B()
        {
            Console.WriteLine("BASE VIRTUAL B");
        }
        public static void C()
        {
            Console.WriteLine("BASE STATIC C");
        }
    }

    public class Derived : Base
    {
        public new void A()
        {
            Console.WriteLine("DERIVED NEW A");
        }
        public override void B()
        {
            Console.WriteLine("DERIVED OVERRIDE B");
        }
        public static new void C()
        {
            Console.WriteLine("DERIVED STATIC NEW C");
        }
    }

    public class MoreDerived: Derived
    {
        public new void A()
        {
            Console.WriteLine("MOREDERIVED NEW A");
        }
        public override void B()
        {
            Console.WriteLine("MOREDERIVED OVERRIDE B");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new MoreDerived();
            Derived d = new MoreDerived();
            MoreDerived md = new MoreDerived();

            b.A();  // BASE A
            d.A();  // DERIVED NEW A
            md.A(); // MOREDERIVED NEW A

            b.B(); // MOREDERIVED OVERRIDE B
            d.B(); // MOREDERIVED OVERRIDE B
            md.B(); // MOREDERIVED OVERRIDE B

            Base.C(); // BASE STATIC C
            Derived.C(); // DERIVED STATIC NEW C
        }
    }
}
