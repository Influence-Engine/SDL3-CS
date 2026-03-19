using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Set the SDL error message for the current thread.</summary>
        /// <param name="fmtAndArglist">The error message</param>
        /// <returns>False</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetError", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetError(string fmtAndArglist);

        // TODO SDL_SetErrorV

        /// <summary>Set an error indicating that memory allocation failed.</summary>
        /// <returns>False</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_OutOfMemory")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool OutOfMemory();

        /// <summary>Retrieve a message about the last error that occurred on the current thread.</summary>
        /// <returns>The message with information about the specifiic error that occured, or NULL.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetError")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetError();

        /// <summary>Clear any previous error message for this thread.</summary>
        /// <returns>True</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ClearError")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ClearError();
    }
}
