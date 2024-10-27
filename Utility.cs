using System.Text;

namespace SDL3
{
    internal static class Utility
    {
        internal static int UTF8Size(string str)
        {
            if (str == null)
                return 0;

            return (str.Length * 4) + 1;
        }

        internal static unsafe byte* UTF8Encode(string str, byte* buffer, int bufferSize)
        {
            if (str == null)
                return (byte*)0;

            fixed (char* strPtr = str)
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);

            return buffer;
        }
    }
}
