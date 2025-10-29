using System.Reflection;

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
        private void PrivateMethod()
        {
            Console.WriteLine("This is a private method.");
        }

        private int PrivateField = 10;

        public void GenericMethod<T>(T param)
        {
            Console.WriteLine("Generic method called with parameter: " + param);
        }

        public void GenericMethodWithTwoParams<T1, T2>(T1 param1, T2 param2)
        {
            Console.WriteLine("Generic method with two parameters called with: " + param1 + ", " + param2);
        }
    }
    
    public class GenericClass<T>
    {
        public GenericClass()
        {
            Console.WriteLine("Generic Constructor with type" + typeof(T));
        }
        public void fun(T param)
        {
            Console.WriteLine("Generic class method called : " + param);
        }
    }
    
    internal class ReflectionPractise
    {
        static void Main(string[] args)
        {
            Type type = typeof(SampleClass);

            //Console.WriteLine("Class Name: " + type.Name);
            //Console.WriteLine("Namespace: " + type.Namespace);
            //Console.WriteLine("Is Class: " + type.IsClass);
            //Console.WriteLine("Is Public: " + type.IsPublic);
            //Console.WriteLine("Base Type: " + type.BaseType);

            //Console.WriteLine();

            //// Constructors
            //ConstructorInfo[] constructorInfos = type.GetConstructors();
            //foreach (var constructor in constructorInfos)
            //{
            //    Console.WriteLine("Constructor: " + constructor.Name);
            //    ParameterInfo[] parameters = constructor.GetParameters();
            //    foreach (var param in parameters)
            //    {
            //        Console.WriteLine("  Parameter: " + param.Name + " Type: " + param.ParameterType);
            //    }
            //}

            //// Fields
            //FieldInfo[] fieldInfos = type.GetFields();
            //foreach (var field in fieldInfos)
            //{
            //    Console.WriteLine("Field: " + field.Name + " Type: " + field.FieldType);
            //}

            //// Properties
            //PropertyInfo[] propertyInfos = type.GetProperties();
            //foreach (var property in propertyInfos)
            //{
            //    Console.WriteLine("Property: " + property.Name + " Type: " + property.PropertyType);
            //}

            //// Methods
            //MethodInfo[] methodInfos = type.GetMethods();
            //foreach (var method in methodInfos)
            //{
            //    Console.WriteLine("Method: " + method.Name + " Return Type: " + method.ReturnType);
            //    ParameterInfo[] parameters = method.GetParameters();
            //    foreach (var param in parameters)
            //    {
            //        Console.WriteLine("  Parameter: " + param.Name + " Type: " + param.ParameterType);
            //    }
            //}


            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Console.WriteLine("Assembly Full Name: " + assembly.FullName);
            //Type[] types = assembly.GetTypes();
            //foreach (var t in types)
            //{
            //    Console.WriteLine("Type: " + t.Name);
            //}

            // Creating instance using reflection
            object obj = Activator.CreateInstance(type, new object[] { 10 });
            MethodInfo sampleMethod = type.GetMethod("SampleMethod");
            sampleMethod.Invoke(obj, null);


            // Invoke private method
            MethodInfo privateMethod = type.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(obj, null);


            // Invoke private field
            FieldInfo privateField = type.GetField("PrivateField", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Private Field Value: " + privateField.GetValue(obj));


            // Invoke generic method
            MethodInfo genericMethod = type.GetMethod("GenericMethod");
            MethodInfo genericMethodInt = genericMethod.MakeGenericMethod(typeof(int));
            genericMethodInt.Invoke(obj, new object[] { 100 });
            MethodInfo genericMethodString = genericMethod.MakeGenericMethod(typeof(string));
            genericMethodString.Invoke(obj, new object[] { "Hello" });

            MethodInfo genericMethod2 = type.GetMethod("GenericMethodWithTwoParams");

            // Generic method with multiple param
            MethodInfo genericMethod2IntString = genericMethod2.MakeGenericMethod(typeof(int), typeof(string));
            genericMethod2IntString.Invoke(obj, new object[] { 200, "World" });




            // Generic class
            object gc = Activator.CreateInstance(typeof(GenericClass<int>), null);
            MethodInfo gcMethod = typeof(GenericClass<int>).GetMethod("fun");
            gcMethod.Invoke(gc, new object[] { 500 });
        }
    }
}
