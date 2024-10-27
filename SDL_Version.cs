using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDLVersion
        {
            public byte major;
            public byte minor;
            public byte patch;
        }

        /// <summary>The current major version of SDL headers.</summary>
        public const int majorVersion = 3;

        /// <summary>The current minor version of the SDL headers.</summary>
        public const int minorVersion = 1;

        /// <summary>The current patch version of the SDL headers.</summary>
        public const int patchLevel = 5;

        public static void Version(out SDLVersion version)
        {
            version.major = majorVersion;
            version.minor = minorVersion;
            version.patch = patchLevel;
        }

        public static int VersionNum(int x, int y, int z) => (x << 24 | y << 8 | z << 0);

        public static readonly int compiledVersion = VersionNum(majorVersion, minorVersion, patchLevel);

        public static bool VersionAtleast(int x, int y, int z) => compiledVersion >= VersionNum(x, y, z);

        /// <summary>Get the version of SDL that is linked.</summary>
        /// <returns>The version of the linked library.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVersion();


        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetRevision();

        /// <summary>Get the code revision of SDL that is linked.</summary>
        /// <returns>An arbitrary string, uniquely identifying the exact revision of the SDL library in use.</returns>
        public static string GetRevision() => Marshal.PtrToStringUTF8(Internal_GetRevision());
    }
}
