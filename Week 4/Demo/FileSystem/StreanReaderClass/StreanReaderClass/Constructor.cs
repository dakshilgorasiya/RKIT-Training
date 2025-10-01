using System.Text;

namespace StreanReaderClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            string path = "example.txt";
            StreamReader sr1 = new StreamReader(new FileStream(path, FileMode.Create, FileAccess.Read)); // arg1(FileStream) file to open

            StreamReader sr2 = new StreamReader(new FileStream(path, FileMode.Create), Encoding.UTF8, true, 128, false); // arg1(FileStream) file to open, arg2(Encoding) character encoding, arg3(bool) detect encoding from byte order marks, arg4(int) buffer size, arg5(bool) leave open

            StreamReader sr3 = new StreamReader(path, Encoding.UTF8, true, 128); // arg1(string) path, arg2(Encoding) character encoding, arg3(bool) detect encoding from byte order marks, arg4(int) buffer size

            // Other
            // stream, encoding, detectEncodingFromByteOrderMarks, bufferSize
            // stream, encoding, detectEncodingFromByteOrderMarks
            // stream, encoding

            // path, encoding, detectEncodingFromByteOrderMarks
            // path, encoding
            // path

        }
    }
}
