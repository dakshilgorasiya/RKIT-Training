using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritancePractise
{
    class A
    {
        public virtual void WhoAreYou() { Console.WriteLine("I am an A"); }
    }
    class B : A
    {
        public override void WhoAreYou() { Console.WriteLine("I am a B"); }
    }
    class C : B
    {
        public new virtual void WhoAreYou() { Console.WriteLine("I am a C"); }
    }
    class D : C
    {
        public override void WhoAreYou() { Console.WriteLine("I am a D"); }
    }
    internal class Progam2
    {
        static void Main(string[] args)
        {
            A a = new D();
            B b = new D();
            C c = new D();
            D d = new D();

            a.WhoAreYou(); // I am a B
            b.WhoAreYou(); // I am a B
            c.WhoAreYou(); // I am a D
            d.WhoAreYou(); // I am a D
        }
    }
}
