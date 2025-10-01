namespace StreamWriterClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            string path = "file.txt";

            StreamWriter sw1 = new StreamWriter(new FileStream(path, FileMode.Create)); // arg1(FileStream) file to open
            // other
            // stream, encoding
            // stream, encoding, bufferSize(int)
            // stream, encoding, bufferSize(int), leaveOpen(bool)


            StreamWriter sw2 = new StreamWriter(path); // arg1(string) path
            // other
            // path, append(bool)
            // path, append(bool), encoding
            // path, append(bool), encoding, bufferSize(int)

            StreamWriter sw3 = new StreamWriter(path, new FileStreamOptions() { Mode = FileMode.Append }); // arg1(string) path, arg2(FileStreamOptions))
            // other
            // path, encoding, FileStreamOptions
        }
    }
}
