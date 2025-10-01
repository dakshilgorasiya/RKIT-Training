using System.IO;

namespace PathClass
{
    internal class Fields
    {
        static void Main(string[] args)
        {
            // Alternative directory separator character
            Console.WriteLine("AltDirectorySeparatorChar: " + Path.AltDirectorySeparatorChar);

            // Character used to separate directory levels
            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);

            // Character used to separate path strings in environment variables
            Console.WriteLine("PathSeparator: " + Path.PathSeparator);

            // Character used to separate volume from path
            Console.WriteLine("VolumeSeparatorChar: " + Path.VolumeSeparatorChar);

            // Invalid file name characters
            char[] invalidPathChar = Path.InvalidPathChars; // Obsolete
            foreach (char c in invalidPathChar)
            {
                Console.WriteLine("InvalidPathChars: " + c);
            }
        }
    }
}
