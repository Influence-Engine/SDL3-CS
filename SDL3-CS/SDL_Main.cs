using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        #region App callback delegates

        /// <summary>
        /// App-implemented intitial entry point for SDL_MAIN_USE_CALLBACKS apps. <br></br>
        /// Called once at startup.
        /// </summary>
        /// <returns><see cref="AppResult.Continue"/> to proceed, <see cref="AppResult.Success"/> or <see cref="AppResult.Failure"/> to termiante.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate AppResult AppInit_func(out nint appstate, int argc, nint argv);

        /// <summary>
        /// App-implemted iteration entry point for SDL_MAIN_USE_CALLBACKS apps. <br></br>
        /// Called repeatedly after <see cref="AppInit_func"/> returns <see cref="AppResult.Continue"/>
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate AppResult AppIterate_func(nint appstate);

        /// <summary>
        /// App-implemented event entry point for SDL_MAIN_USE_CALLBACKS apps. <br></br>
        /// Called once before new event after <see cref="AppInit_func"/> returns <see cref="AppResult.Continue"/>
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate AppResult AppEvent_func(nint appstate, ref Event sdlEvent);

        /// <summary>
        /// App-implemented deinit entry point for SDL_MAIN_USE_CALLBACKS apps. <br></br>
        /// Called once before the program terminates, in all cases.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AppQuit_func(nint appstate, AppResult result);

        /// <summary>The prototype for the application's main() function.</summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int main_func(int argc, nint argv);

        #endregion

        /// <summary>
        /// An app-supplied function for program entry.<br></br>
        /// Apps should not call this directly. SDL redirects the platform entry point here.
        /// </summary>
        /// <param name="argc">An ANSI-C style main function's argc.</param>
        /// <param name="argv">An ANSI-C style main function's argv</param>
        /// <returns>An ANSI-C main return code; generally 0 is considered successful program completion, and otherwise values are considered errors.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_main")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int Main(int argc, IntPtr argv);

        /// <summary>
        /// Circumvent failure of <see cref="Init"/> when not using <see cref="Main"/> as an entry point.
        /// Must be called before <see cref="Init"/> if SDL_MAIN_HANDLED is defined.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetMainReady")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetMainReady();

        /// <summary>
        /// Intializes and launches an SDL application, performing platform-specific initialization 
        /// before calling <paramref name="mainFunction"/> and cleanup after in returns. <br></br>
        /// Use this when handling your own <see cref="Main"/> with SDL_MAIN_HANDLED. You do not need <see cref="SetMainReady"/> when using this.
        /// </summary>
        /// <param name="argc">The argc from the application's main(), or 0 if not available.</param>
        /// <param name="argv">The argv from the application's main(), or NULL if not available.</param>
        /// <param name="mainFunction">Your SDL app's C-style main function.</param>
        /// <param name="reserved">Reserved for future use; pass NULL.</param>
        /// <returns>The return value from <paramref name="mainFunction"/>: 0 on success, otherwise failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RunApp")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int RunApp(int argc, nint argv, main_func mainFunction, nint reserved);

        /// <summary>
        /// An entry point for SDL's use in SDL_MAIN_USE_CALLBACKS. <br></br>
        /// Do not call this directly. It is invoked by SDL's magic header-only library.
        /// </summary>
        /// <param name="argc">Standard Unix main argc.</param>
        /// <param name="argv">Standard Unix main argv.</param>
        /// <param name="appInit">The application's <see cref="AppInit_func"/> function.</param>
        /// <param name="appIter">The application's <see cref="AppIterate_func"/> function.</param>
        /// <param name="appEvent">The application's <see cref="AppEvent_func"/> function.</param>
        /// <param name="appQuit">The application's <see cref="AppQuit_func"/> function.</param>
        /// <returns>Standard Unix main return value.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EnterAppMainCallbacks")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int EnterAppMainCallbacks(int argc, nint argv, AppInit_func appInit, AppIterate_func appIter, AppEvent_func appEvent, AppQuit_func appQuit);

        /// <summary>
        /// Register a Win32 window class for SDL's use (Windows only) <br></br>
        /// Most applications do not need to call this directly. SDL calls it when initializing the video subsystem.
        /// </summary>
        /// <param name="name">The window class name in UTF-8, or null to use SDL's default.</param>
        /// <param name="style">The value to use in WNDCLASSEX::style</param>
        /// <param name="hInst">The HINSTANCE for WNDCLASSEX::hInstance, or zero to use GetModuleHandle(NULL).</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RegisterApp", StringMarshalling =StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RegisterApp(string? name, uint style, nint hInst);

        /// <summary>
        /// Deregister the Win32 window class from a <see cref="RegisterApp"/> call. (Windows only) <br></br>
        /// Most applications do not need to call this directly. SDL calls it when deinitializing the video subsystem.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UnregisterApp")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UnregisterApp();

        /// <summary>
        /// Callback from the application to let the GDK suspend continue. (Xbox GDK only) <br></br>
        /// Should be called in response to SDL_EVENT_DID_ENTER_BACKGROUND from the render thread,
        /// after suppressing all rendering operations. <br></br>
        /// All other platforms do nothing.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GDKSuspendComplete")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GDKSuspendComplete();
    }
}
