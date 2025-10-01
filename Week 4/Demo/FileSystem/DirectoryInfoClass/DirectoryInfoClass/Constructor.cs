namespace DirectoryInfoClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\\RKIT Training");
            Console.WriteLine("Directory Name: " + directoryInfo.FullName);
        }
    }
}
