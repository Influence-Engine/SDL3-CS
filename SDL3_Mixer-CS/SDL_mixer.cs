using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class MIX
    {
        const string nativeLibraryName = "SDL3_mixer";

        public const int MajorVersion = 3;
        public const int MinorVersion = 3;
        public const int MicroVersion = 0;

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct StereoGains
        {
            public float left;
            public float right;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point3D
        {
            public float x;
            public float y;
            public float z;
        }

        #endregion


    }
}
