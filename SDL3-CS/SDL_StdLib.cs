using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate nint MallocFunc(nuint size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate nint CallocFunc(nuint nmemb, nuint size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate nint ReallocFunc(nint mem, nuint size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FreeFunc(nint mem);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CompareCallback(nint a, nint b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CompareCallback_r(nint userdata, nint a, nint b);

        #endregion

        #region Memory Allocation

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_malloc")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint Malloc(nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_calloc")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint Calloc(nuint nmemb, nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_realloc")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint Realloc(nint mem, nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_free")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial void Free(nint mem);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_aligned_alloc")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint AlignedAlloc(nuint alignment, nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_aligned_free")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial void AlignedFree(nint mem);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNumAllocations")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetNumAllocations();

        #endregion

        // TODO a lot more
    }
}
