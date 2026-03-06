using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        /// <summary>Get the number of milliseconds since SDL library initialization.</summary>
        /// <returns>The number of milliseconds since the SDL library initialized.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTicks")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial ulong GetTicks();

        /// <summary>Get the number of nanoseconds since SDL library initialization.</summary>
        /// <returns>The number of nanaseconds since the SDL library initialized.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTicksNS")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial ulong GetTicksNS();

        /// <summary>Get the current value of the high resolution counter.</summary>
        /// <returns>The current counter value.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceCounter")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial ulong GetPerformanceCounter();

        /// <summary>Get the count per second of the high resolution counter.</summary>
        /// <returns>A platform-specific count per second.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPerformanceFrequency")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial ulong GetPerformanceFrequency();

        /// <summary>Wait a specified number of milliseconds before returning.</summary>
        /// <param name="milliseconds">The number of milliseconds to delay.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Delay")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Delay(uint milliseconds);

        /// <summary>Wait a specified number of nanoseconds before returning.</summary>
        /// <param name="nanoseconds">The number of nanoseconds to delay.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DelayNS")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DelayNS(ulong nanoseconds);

        /// <summary>Wait a sepcified number of nanoseconds before returning.</summary>
        /// <param name="nanoseconds">The number of nanseconds to delay.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DelayPrecise")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DelayPrecise(ulong nanoseconds);

        // TODO SDL_AddTimer
        // TODO SDL_AddTimerNS
        // TODO SDL_RemoveTimer
    }
}
