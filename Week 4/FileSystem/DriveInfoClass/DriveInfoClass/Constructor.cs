namespace DriveInfoClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            DriveInfo driveInfo = new DriveInfo("D");
            Console.WriteLine("Drive Name: " + driveInfo.Name);
        }
    }
}
