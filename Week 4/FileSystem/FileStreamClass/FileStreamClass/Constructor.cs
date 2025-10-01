namespace FileStreamClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {

            FileStream fs1 = new FileStream("example1.txt", FileMode.Create, FileAccess.Write, FileShare.None, 8096, FileOptions.None); // arg1(string) path, arg2(FileMode) mode, arg3(FileAccess) access, arg4(FileShare) share, arg5(int) bufferSize, arg6(FileOptions) options

            FileStream fs2 = new FileStream("example2.txt", FileMode.Create, FileAccess.Write, FileShare.None, 8096); // arg1(string) path, arg2(FileMode) mode, arg3(FileAccess) access, arg4(FileShare) share, arg5(int) bufferSize

            // Other
            // path, mode, access, share, bufferSize, isAsync
            // path, mode, access, share
            // path, mode, access
            // path, mode

            FileStream fs3 = new FileStream("example3.txt", new FileStreamOptions() { Access = FileAccess.Write, Mode = FileMode.Create, Share = FileShare.None, BufferSize = 8096, Options = FileOptions.None }); // arg1(string) path, arg2(FileStreamOptions) options)
        }
    }
}
