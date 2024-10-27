using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetPlatform();

        /// <summary>Gets the name of the platform.</summary>
        /// <returns>The name of the platform. If the correct name is not available, returns string starting with "Unknown".</returns>
        public static string GetPlatform() => Marshal.PtrToStringUTF8(Internal_GetPlatform());
    }
}
