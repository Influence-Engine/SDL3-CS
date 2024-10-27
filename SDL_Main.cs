using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        // TODO SDL_AppInit
        // TODO SDL_AppIterate
        // TODO SDL_AppEvent
        // TODO SDL_AppQuit

        public delegate int main(int argc, IntPtr argv);

        // TODO SDL_main

        /// <summary>Circumvent failure of Init() when not using main() as an entry point.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetMainReady", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMainReady();

        // TODO SDL_RunApp

        // TODO SDL_EnterAppMainCallbacks

        // TODO SDL_RegisterApp

        /// <summary>Deregister the win32 window class from an RegisterApp call.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_UnregisterApp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnregisterApp();

        /// <summary>Callback from the application to let the suspend continue.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GDKSuspendComplete", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GDKSuspendComplete();
    }
}
