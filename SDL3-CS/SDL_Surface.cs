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

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetSurfaceColorspace")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetSurfaceColorspace(IntPtr surface, Colorspace colorspace);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetSurfaceColorspace")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial Colorspace GetSurfaceColorspace(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSurfacePalette")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateSurfacePalette(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetSurfacePalette")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetSurfacePalette(IntPtr surface, IntPtr palette);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetSurfacePalette")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetSurfacePalette(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_AddSurfaceAlternateImage")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AddSurfaceAlternateImage(IntPtr surface, IntPtr image);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SurfaceHasAlternateImages")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SurfaceHasAlternateImages(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetSurfaceImages")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetSurfaceImages(IntPtr surface, IntPtr count);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RemoveSurfaceAlternateImages")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RemoveSurfaceAlternateImages(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LockSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool LockSurface(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UnlockSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UnlockSurface(IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LoadSurface_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr LoadSurface_IO(IntPtr src, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LoadSurface", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr LoadSurface(string file);

        // TODO all other functions

    }
}
