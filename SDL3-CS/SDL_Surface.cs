using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        /// <summary>The flags on a <see cref="Surface"/>.</summary>
        [Flags]
        public enum SurfaceFlags : uint
        {
            /// <summary>Surface uses preallocated pixel memory.</summary>
            Preallocated = 0x00000001u,

            /// <summary>Surface needs to be locked to access pixels.</summary>
            LockNeeded = 0x00000002u,

            /// <summary>Surface is currently locked.</summary>
            Locked = 0x00000004u,

            /// <summary>Surface uses pixel memory allocated with <see cref="AlignedAlloc"/></summary>
            SIMDAligned = 0x00000008u
        }

        /// <summary>The scaling mode.</summary>
        public enum ScaleMode
        {
            /// <summary>Not valid.</summary>
            Invalid = -1,

            /// <summary>Nearest pixel sampling.</summary>
            Nearest,

            /// <summary>Linear filtering.</summary>
            Linear,

            /// <summary>Nearest pixel sampling with improved scaling for pixel art.</summary>
            PixelArt,
        }

        /// <summary>The flip mode.</summary>
        public enum FlipMode
        {
            /// <summary>Do not flip.</summary>
            None,

            /// <summary>Flip horizontally.</summary>
            Horizontal,

            /// <summary>Flip vertically.</summary>
            Vertical,

            /// <summary>Flip horizontally and vertically (not a diagonal flip).</summary>
            HorizontalAndVertical = Horizontal | Vertical
        }

        /// <summary>A collection of pixels used in software blitting.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Surface
        {
            /// <summary>The flags of the surface, read-only.</summary>
            public SurfaceFlags flags;

            /// <summary>The forat of the surface, read-only.</summary>
            public PixelFormat format;

            /// <summary>The width of the surface, read-only.</summary>
            public int w;

            /// <summary>The height of the surface, read-only.</summary>
            public int h;

            /// <summary>The distance in bytes between roys of pixels, read-only.</summary>
            public int pitch;

            /// <summary>A pointer to the pixels of the surface, the pixels are writable if non-null.</summary>
            public IntPtr pixels;

            /// <summary>Application reference count, used when freeing surface.</summary>
            public int refCount;

            /// <summary>Reserved for internal use.</summary>
            IntPtr reserved;
        }

        /// <summary>Allocate a new surface with a specified pixel format.</summary>
        /// <param name="width">The width of the surface.</param>
        /// <param name="height">The height of the surface.</param>
        /// <param name="format">The PixelFormat for the new surface's pixe format.</param>
        /// <returns>The new Surface structure that is created or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateSurface(int width, int height, PixelFormat format);

        /// <summary>Allocate a new surface with a specified pixel format and existing pixel data.</summary>
        /// <param name="width">The width of the surface.</param>
        /// <param name="height">The height of the surface.</param>
        /// <param name="format">The PixelFormat for the new surface's pixel format.</param>
        /// <param name="pixels">A pointer to existing pixel data.</param>
        /// <param name="pitch">The number of bytes between each row, including padding.</param>
        /// <returns>The new Surface structure that is created or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSurfaceFrom")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateSurfaceFrom(int width, int height, PixelFormat format, IntPtr pixels, int pitch);

        /// <summary>Free a surface.</summary>
        /// <param name="surface">The Surface to free.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroySurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroySurface(IntPtr surface);

        /// <summary>Get the properties associated with a surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetSurfaceProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetSurfaceProperties(IntPtr surface);

        // TODO all other functions

    }
}
