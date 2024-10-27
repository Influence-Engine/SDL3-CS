using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
       
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe void Internal_SetError(byte* fmtAndArglist);

        /// <summary>Set the SDL error message for the current thread.</summary>
        /// <param name="fmtAndArglist">Additional parameters matching % tokens in the fmt string, if any.</param>
        public static unsafe void SetError(string fmtAndArglist)
        {
            int utf8FmtAndArlistBufferSize = Utility.UTF8Size(fmtAndArglist);
            byte* utf8FmtAndArgList = stackalloc byte[utf8FmtAndArlistBufferSize];
            Internal_SetError(Utility.UTF8Encode(fmtAndArglist, utf8FmtAndArgList, utf8FmtAndArlistBufferSize));
        }

        // TODO SDL_SetErrorV

        /// <summary>Set an error indicating that memory allocation failed.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_OutOfMemory", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OutOfMemory();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetError();

        /// <summary>Retrieve a message about the last error that occurred on the current thread.</summary>
        /// <returns>The message with information about the specifiic error that occured, or NULL.</returns>
        public static string GetError() => Marshal.PtrToStringUTF8(Internal_GetError());

        /// <summary>Clear any previous error message for this thread.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_ClearError", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearError();


    }
}
