using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AppInit", CallingConvention = CallingConvention.Cdecl)]
        public static extern AppResult AppInit(out IntPtr appState, int argc, IntPtr argv);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AppIterate", CallingConvention = CallingConvention.Cdecl)]
        public static extern AppResult AppIterate(IntPtr appState);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AppEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern AppResult AppEvent(IntPtr appState, ref Event _event);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AppQuit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppQuit(IntPtr appState, AppResult result);

        public delegate int main(int argc, IntPtr argv);

        /// <summary>An app-supplied function for program entry.</summary>
        /// <param name="argc">An ANSI-C style main function's argc.</param>
        /// <param name="argv">An ANSI-C style main function's argv</param>
        /// <returns>An ANSI-C main return code; generally 0 is considered successful program completion, and otherwise values are considered errors.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_main", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Main(int argc, IntPtr argv);

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
