using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfoClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            DriveInfo driveInfo = new DriveInfo("D");

            // Avaliable to the user on the drive in bytes
            // Available free space on the drive in bytes
            Console.WriteLine("Available Free Space: " + driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024 + " GB");

            // Total free space available
            // Total free space on the drive in bytes
            Console.WriteLine("Total Free Space: " + driveInfo.TotalFreeSpace / 1024 / 1024 / 1024 + " GB");

            // Total size of the drive in bytes
            Console.WriteLine("Total Size: " + driveInfo.TotalSize / 1024 / 1024 / 1024 + " GB");

            // Drive format (e.g., NTFS, FAT32)
            Console.WriteLine("Drive Format: " + driveInfo.DriveFormat);

            // Drive type (e.g., Fixed, Removable)
            Console.WriteLine("Drive Type: " + driveInfo.DriveType);

            // IsReady indicates if the drive is ready
            Console.WriteLine("Is Drive Ready: " + driveInfo.IsReady);

            // Name
            Console.WriteLine("Drive Name: " + driveInfo.Name);

            // Root directory of the drive
            DirectoryInfo rootDir = driveInfo.RootDirectory;
            Console.WriteLine("Root Directory: " + rootDir.FullName);

            // Volume label of the drive
            Console.WriteLine("Volume Label: " + driveInfo.VolumeLabel);
        }
    }
}
