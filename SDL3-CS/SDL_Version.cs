using System;
using System.Runtime.CompilerServices;
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
        public const int minorVersion = 5;

        /// <summary>The current patch version of the SDL headers.</summary>
        public const int patchLevel = 0;

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
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetVersion")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetVersion();

        /// <summary>Get the code revision of SDL that is linked.</summary>
        /// <returns>An arbitrary string, uniquely identifying the exact revision of the SDL library in use.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRevision")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetRevisionPtr();

        /// <inheritdoc cref="GetRevisionPtr"/>
        public static string? GetRevision()
        {
            IntPtr ptr = GetRevisionPtr();
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
        }
    }
}
