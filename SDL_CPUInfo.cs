using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Get the number of logical CPU cores available.</summary>
        /// <returns>The total number of logical CPU cores. The number of logical cores may be more than physical cores.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetNumLogicalCPUCores", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCPUCount();

        /// <summary>Determine the L1 cache line size of the CPU.</summary>
        /// <returns>The L1 cache line size of the CPU, in bytes.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetCPUCacheLineSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCPUCacheLineSize();


        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAltiVec", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAltiVec();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasMMX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasMMX();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE2", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE2();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE3", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE3();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE41", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE41();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE42", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE42();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAVX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAVX();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAVX2", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAVX2();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasARMSIMD", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasARMSIMD();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasNEON", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasNEON();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasLSX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasLSX();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasLASX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasLASX();

        /// <summary>Get the amount of RAM configured in the system.</summary>
        /// <returns>The amount of RAM configured in the system in MiB.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetSystemRAM", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSystemRAM();

        /// <summary>Gets the alignment this system needs for SIMD allocations.</summary>
        /// <returns>The alignment in bytes needed for available, known SIMD instructions.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GETSIMDAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetSIMDAlignment();
    }
}
