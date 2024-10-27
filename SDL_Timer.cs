using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        /// <summary>Get the number of milliseconds since SDL library initialization.</summary>
        /// <returns>The number of milliseconds since the SDL library initialized.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetTicks", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetTicks();

        /// <summary>Get the number of nanoseconds since SDL library initialization.</summary>
        /// <returns>The number of nanaseconds since the SDL library initialized.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetTicksNS", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetTickNS();

        /// <summary>Get the current value of the high resolution counter.</summary>
        /// <returns>The current counter value.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceCounter", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetPerformanceCounter();

        /// <summary>Get the count per second of the high resolution counter.</summary>
        /// <returns>A platform-specific count per second.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceFrequency", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetPerformanceFrequency();

        /// <summary>Wait a specified number of milliseconds before returning.</summary>
        /// <param name="milliseconds">The number of milliseconds to delay.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_Delay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Delay(uint milliseconds);

        /// <summary>Wait a specified number of nanoseconds before returning.</summary>
        /// <param name="nanoseconds">The number of nanoseconds to delay.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_DelayNS", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DelayNS(ulong nanoseconds);

        /// <summary>Wait a sepcified number of nanoseconds before returning.</summary>
        /// <param name="nanoseconds">The number of nanseconds to delay.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_DelayPrecise", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DelayPrecise(ulong nanoseconds);

        // TODO SDL_AddTimer
        // TODO SDL_AddTimerNS
        // TODO SDL_RemoveTimer
    }
}
