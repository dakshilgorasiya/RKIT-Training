using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDemo
{
    public class Singleton
    {
        public readonly Guid Id;
        private Singleton()
        {
            Id = Guid.NewGuid();
        }
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => _instance.Value;
    }
}
