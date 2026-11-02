using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        /// <summary>The flags on a Surface.</summary>
        [Flags]
        public enum SurfaceFlags : uint
        {
            Preallocated = 0x00000001u,
            LockNeeded = 0x00000002u,
            Locked = 0x00000004u,
            SIMDAligned = 0x00000008u
        }

        /// <summary>The scaling mode.</summary>
        public enum ScaleMode
        {
            Invalid = -1,
            Nearest,
            Linear,
            PixelArt,
        }

        /// <summary>The flip mode.</summary>
        public enum FlipMode
        {
            None,
            Horizontal,
            Vertical
            Vertical,
            HorizontalAndVertical = Horizontal | Vertical
        }

        /// <summary>A collection of pixels used in software blitting.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Surface
        {
            public SurfaceFlags flags;
            public PixelFormat format;
            public int w;
            public int h;
            public int pitch;
            public IntPtr pixels;

            public int refCount;

            IntPtr reserved;
        }

        /// <summary>Allocate a new surface with a specified pixel format.</summary>
        /// <param name="width">The width of the surface.</param>
        /// <param name="height">The height of the surface.</param>
        /// <param name="format">The PixelFormat for the new surface's pixe format.</param>
        /// <returns>The new Surface structure that is created or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial Surface CreateSurface(int width, int height, PixelFormat format);

        /// <summary>Allocate a new surface with a specified pixel format and existing pixel data.</summary>
        /// <param name="width">The width of the surface.</param>
        /// <param name="height">The height of the surface.</param>
        /// <param name="format">The PixelFormat for the new surface's pixel format.</param>
        /// <param name="pixels">A pointer to existing pixel data.</param>
        /// <param name="pitch">The number of bytes between each row, including padding.</param>
        /// <returns>The new Surface structure that is created or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSurfaceFrom")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial Surface CreateSurfaceFrom(int width, int height, PixelFormat format, IntPtr pixels, int pitch);

        /// <summary>Free a surface.</summary>
        /// <param name="surface">The Surface to free.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroySurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroySurface(Surface surface);

        /// <summary>Free a surface.</summary>
        /// <param name="surface">The Surface to free.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroySurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroySurface(IntPtr surface);

        // TODO all other functions

    }
}
