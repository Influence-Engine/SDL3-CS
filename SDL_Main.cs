using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public delegate int main(int argc, IntPtr argv);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetMainReady", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMainReady();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_WinRTRunApp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WinRTRunApp(main mainFunction, IntPtr reserved);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GDKRunApp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GDKRunApp(main mainFunction, IntPtr reserved);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_UIKitRunApp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UIKitRunApp(int argc, IntPtr argv, main mainFunction);
    }
}
