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


        /// <summary>Determine whether thr CPU has AltiVec features.</summary>
        /// <returns>True of the CPU has AlitVec features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAltiVec", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAltiVec();

        /// <summary>Determine whether thr CPU has MMX features.</summary>
        /// <returns>True of the CPU has MMX features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasMMX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasMMX();

        /// <summary>Determine whether thr CPU has SSE features.</summary>
        /// <returns>True of the CPU has SSE features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE();

        /// <summary>Determine whether thr CPU has SSE2 features.</summary>
        /// <returns>True of the CPU has SSE2 features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE2", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE2();

        /// <summary>Determine whether thr CPU has SSE3 features.</summary>
        /// <returns>True of the CPU has SSE3 features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE3", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE3();

        /// <summary>Determine whether thr CPU has SSE41 features.</summary>
        /// <returns>True of the CPU has SSE41 features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE41", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE41();

        /// <summary>Determine whether thr CPU has SSE42 features.</summary>
        /// <returns>True of the CPU has SSE42 features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasSSE42", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasSSE42();

        /// <summary>Determine whether thr CPU has AVX features.</summary>
        /// <returns>True of the CPU has AVX features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAVX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAVX();

        /// <summary>Determine whether thr CPU has AVX2 features.</summary>
        /// <returns>True of the CPU has AVX2 features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAVX2", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAVX2();

        /// <summary>Determine whether thr CPU has AVX-512F features.</summary>
        /// <returns>True of the CPU has AVX-512F features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasAVX512F", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasAVX512F();

        /// <summary>Determine whether thr CPU has ARM SIMD (ARMv6) features.</summary>
        /// <returns>True of the CPU has ARM SIMD features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasARMSIMD", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasARMSIMD();

        /// <summary>Determine whether thr CPU has NEON (ARM SIMD) features.</summary>
        /// <returns>True of the CPU has ARM NEON features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasNEON", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasNEON();

        /// <summary>Determine whether thr CPU has LSX (LOONGARCH SIMD) features.</summary>
        /// <returns>True of the CPU has LOONGARCH LSX features, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasLSX", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasLSX();

        /// <summary>Determine whether thr CPU has LASX (LOONGARCH SIMD) features.</summary>
        /// <returns>True of the CPU has LOONGARCH LASX features, false otherwise.</returns>
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
