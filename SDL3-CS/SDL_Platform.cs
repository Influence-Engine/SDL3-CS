using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Gets the name of the platform.</summary>
        /// <returns>The name of the platform. If the correct name is not available, returns string starting with "Unknown".</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPlatform")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string GetPlatform();
    }
}
