using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            FileStream fs1 = new FileStream("example1.txt", FileMode.Create, FileAccess.Write, FileShare.None, 8096, FileOptions.None);
            FileStream fs2 = new FileStream("example.txt", FileMode.Open, FileAccess.Read, FileShare.None, 8096);

            //fs2.CopyTo(fs1); // void CopyTo(Stream destination)
            // Also CopyToAsync

            fs1.Flush();
            // Also FlushAsync

            // Stop other operations on the stream until the lock is removed
            fs1.Lock(0, fs1.Length); // void Lock(long position, long length)
            fs1.Unlock(0, fs1.Length); // void Unlock(long position, long length)

            //byte[] buffer = new byte[15];
            //fs2.Read(buffer, 0, buffer.Length); // int Read(byte[] array, int offset, int count)
            //Console.WriteLine(Encoding.UTF8.GetString(buffer));
            // Also ReadAsync

            byte oneByte = (byte)fs2.ReadByte(); // int ReadByte()
            Console.WriteLine((char)oneByte);

            //fs1.Seek(0, SeekOrigin.Begin); // long Seek(long offset, SeekOrigin origin)

            //fs1.SetLength(0); // void SetLength(long value) // making it 0 truncates the file

            byte[] toWrite = Encoding.UTF8.GetBytes("HELLO HOW ARE YOU?");
            fs1.Write(toWrite, 0, toWrite.Length); // void Write(byte[] array, int offset, int count)
            // Also WriteAsync and WriteByte

            fs1.Dispose();
            fs2.Dispose();
            // Also DisposeAsync
        }
    }
}
