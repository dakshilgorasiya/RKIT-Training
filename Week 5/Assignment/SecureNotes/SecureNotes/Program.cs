using Models;
using IO;
using Operations;

namespace SecureNotes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set the current directory to the project root
            string root = AppContext.BaseDirectory;
            string projectRoot = Path.Combine(root, @"../../../");
            Directory.SetCurrentDirectory(projectRoot);

            // Display the menu
            Menu menu = new Menu();
            menu.Display();
        }
    }
}
