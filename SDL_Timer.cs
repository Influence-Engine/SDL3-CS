using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetTicks", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetTicks();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetTicksNS", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetTickNS();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceCounter", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetPerformanceCounter();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceFrequency", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetPerformanceFrequency();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_Delay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Delay(uint milliseconds);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_DelayNS", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DelayNS(ulong nanoseconds);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_DelayPrecise", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DelayPrecise(ulong nanoseconds);

        // TODO SDL_AddTimer
        // TODO SDL_AddTimerNS
        // TODO SDL_RemoveTimer
    }
}
