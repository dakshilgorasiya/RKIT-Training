using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public class SampleClass
    {
        public int SampleField;
        public int SampleProperty { get; set; }

        public SampleClass()
        {
            Console.WriteLine("SampleClass constructor");
        }
        public SampleClass(int value)
        {
            SampleField = value;
            Console.WriteLine("SampleClass constructor with parameter: " + value);
        }
        public void SampleMethod()
        {
            Console.WriteLine("This is a sample method.");
        }
        public int SampleMethodWithReturn()
        {
            return 42;
        }
        public int SampleMethodWithParameters(int x, int y)
        {
            return x + y;
        }
        public static void StaticSampleMethod()
        {
            Console.WriteLine("This is a static sample method.");
        }
    }
    internal class ReflectionPractise
    {
        static void Main(string[] args)
        {
            Type type = typeof(SampleClass);

            Console.WriteLine("Class Name: " + type.Name);
            Console.WriteLine("Namespace: " + type.Namespace);
            Console.WriteLine("Is Class: " + type.IsClass);
            Console.WriteLine("Is Public: " + type.IsPublic);
            Console.WriteLine("Base Type: " + type.BaseType);

            Console.WriteLine();

            // Constructors
            ConstructorInfo[] constructorInfos = type.GetConstructors();
            foreach (var constructor in constructorInfos)
            {
                Console.WriteLine("Constructor: " + constructor.Name);
                ParameterInfo[] parameters = constructor.GetParameters();
                foreach (var param in parameters)
                {
                    Console.WriteLine("  Parameter: " + param.Name + " Type: " + param.ParameterType);
                }
            }

            // Fields
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var field in fieldInfos)
            {
                Console.WriteLine("Field: " + field.Name + " Type: " + field.FieldType);
            }

            // Properties
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var property in propertyInfos)
            {
                Console.WriteLine("Property: " + property.Name + " Type: " + property.PropertyType);
            }

            // Methods
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (var method in methodInfos)
            {
                Console.WriteLine("Method: " + method.Name + " Return Type: " + method.ReturnType);
                ParameterInfo[] parameters = method.GetParameters();
                foreach (var param in parameters)
                {
                    Console.WriteLine("  Parameter: " + param.Name + " Type: " + param.ParameterType);
                }
            }


            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("Assembly Full Name: " + assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (var t in types)
            {
                Console.WriteLine("Type: " + t.Name);
            }

            // Creating instance using reflection
            object obj = Activator.CreateInstance(type, new object[] { 10 });
            MethodInfo sampleMethod = type.GetMethod("SampleMethod");
            sampleMethod.Invoke(obj, null);
        }
    }
}
