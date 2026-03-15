using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {

        #region Constants

        public const string SoftwareRenderer = "software";
        public const string GPURenderer = "gpu";
        public const int DebugTextFontCharacterSize = 8;
        public const int RendererVSyncDisabled = 0;
        public const int RendererVSyncAdaptive = -1;

        #endregion

        /// <summary>Vertex Structure</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Vertex
        {
            public FPoint position;
            public FColor color;
            public FPoint text_coord;
        }

        /// <summary>The access pattern allowed for a texture.</summary>
        public enum TextureAccess
        {
            Static,
            Streaming,
            Target
        }

        /// <summary>The addressing mode for a texture when used in RenderGeometry().</summary>
        public enum TextureAddressMode
        {
            Invalid = -1,

            /// <summary>Default: Wrap if coordinate are outside [0, 1]</summary>
            Auto,

            /// <summary>Clamp coordinates to [0, 1]</summary>
            Clamp,

            /// <summary>Tile/Repeat the texture</summary>
            Wrap
        }

        /// <summary>How the logical size is mapped to the output.</summary>
        public enum RendererLogicalPresentation
        {
            Disabled,
            Stretch,
            Letterbox,
            Overscan,
            IntegerScale
        }

        /// <summary>Any efficient driver-specific representation of pixel data</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Texture
        {
            PixelFormat format;
            int w;
            int h;

            int refCount;
        }

        // [LibraryImport(nativeLibraryName, EntryPoint = "Entry")]
        // [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]

        #region Rendere Creation / Query

        /// <summary>Get the numver of 2D rendering drivers available for the current display. </summary>
        /// <returns></returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNumRenderDrivers")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetNumRenderDrivers();

        /// <summary>Get the name of a built-in 2D rendering driver.</summary>
        /// <param name="index">Index from 0 to (<see cref="GetNumRenderDrivers"/> - 1).</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDriver")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetRenderDriver(int index);

        /// <summary>Create a window and default renderer.</summary>
        /// <param name="title">Title of the window.</param>
        /// <param name="width">Width of the window.</param>
        /// <param name="height">Height of the window.</param>
        /// <param name="flags">Flags used to create the window.</param>
        /// <param name="window">Pointer filled with the window.</param>
        /// <param name="renderer">Pointer filled with the renderer.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowAndRenderer", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool CreateWindowAndRenderer(string title, int width, int height, WindowFlags flags, out nint window, out nint renderer);

        /// <summary>Create a 2D rendering context for a window.</summary>
        /// <param name="window">The window where rendering is displayed.</param>
        /// <param name="name">The name of the rendering driver to initialize, or NULL to let SDL choose one.</param>
        /// <returns>A valid rendering pointer or 0 on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateRenderer", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateRenderer(nint window, string? name);

        /// <summary>Create a 2D rendering context for a window, with the specified properties.</summary>
        /// <param name="props">The properties ID to use.</param>
        /// <returns>A valid renderer or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateRendererWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateRendererWithProperties(uint props);

        /// <summary>Create a 2D GPU rendering context. If <paramref name="device"/> is NULL, a device will be created internally.</summary>
        /// <param name="device">The GPU device to use, or NULL to create one.</param>
        /// <param name="window">The window to render to, or NULL for an offscreen renderer.</param>
        /// <returns>A valid renderer or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPURenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateGPURenderer(nint device, nint window);

        /// <summary>Return the GPU device used by a renderer, or NULL if not a GPU renderer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGPURendererDevice")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetGPURendererDevice(nint renderer);

        /// <summary>Create a 2D software rendering context for a surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSoftwareRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateSoftwareRenderer(nint surface);

        /// <summary>Get the renderer associated with a window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetRenderer(nint window);

        /// <summary>Get the window associated with a renderer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetRenderWindow(nint renderer);

        /// <summary>Get the name of a renderer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRendererName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetRendererName(nint renderer);

        /// <summary>Get the properties associated with a renderer.</summary>
        /// <returns>A valid property ID on success or 0 on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRendererProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetRendererProperties(nint renderer);

        /// <summary>Get the output size in pixels of a rendering context.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderOutputSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetRenderOutputSize(nint renderer, out int w, out int h);

        /// <summary>Get the current output size in pixels of a rendering context.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentRenderOutputSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetCurrentRenderOutputSize(nint renderer, out int w, out int h);

        #endregion

        #region Texture Creation / Query

        /// <summary>Create a texture for a rendering context.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <param name="format">One of the enumerated values in PixelFormat.</param>
        /// <param name="access">One of the enumerated values in TextureAccess.</param>
        /// <param name="w">Width of the texture in pixels.</param>
        /// <param name="h">Height of the texture in pixels.</param>
        /// <returns>Pointer to the created texture or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateTexture(nint renderer, PixelFormat format, TextureAccess access, int w, int h);

        /// <summary>Create a texture from an existing surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateTextureFromSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateTextureFromSurface(nint renderer, nint surface);

        /// <summary>Create a texture with the specified properties.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateTextureWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateTextureWithProperties(nint renderer, uint props);

        /// <summary>Get the properties associated with a texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetTextureProperties(nint texture);

        /// <summary>Get the renderer that created a texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRendererFromTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetRendererFromTexture(nint texture);

        /// <summary>Get the renderer that created a texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureSize(nint texture, out float w, out float h);

        /// <summary>Set the palette used by a texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTexturePalette")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTexturePalette(nint texture,  nint palette);

        /// <summary>Get the palette used by a texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTexturePalette")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetTexturePalette(nint texture);

        #endregion

        //TODO SDL_SetTextureColorMod
        //TODO SDL_GetTextureColorMod

        //TODO SDL_SetTextureAlphaMod
        //TODO SDL_GetTextureAlphaMod

        //TODO SDL_SetTextureBlendMod
        //TODO SDL_GetTextureBlendMod

        //TODO SDL_SetTextureScaleMod
        //TODO SDL_GetTextureScaleMod

        //TODO SDL_SetTextureUserData
        //TODO SDL_GetTextureUserData

        #region Texture Pixel Update / Lock

        /// <summary>Update the given texture rectangle with new pixel data.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UpdateTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool UpdateTexture(nint texture, ref Rect rect, nint pixel, int pitch);

        /// <summary>Update a planar YV12/IYUV texture with new pixel data.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UpdateYUVTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool UpdateYUVTexture(nint texture, ref Rect rect, byte* Yplane, int Ypitch, byte* Uplane, int Upitch, byte* Vplane, int Vpitch);

        /// <summary>Update a planar NV12/NV21 texture with new pixels.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UpdateNVTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool UpdateNVTexture(nint texture, ref Rect rect, byte* Yplane, int Ypitch, byte* UVplane, int UVpitch);

        /// <summary>Lock a portion of the texture for write-only pixel access.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LockTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool LockTexture(nint texture, ref Rect rect, out nint pixel, out int pitch);

        /// <summary>Lock a portion of the texture for write-only access and expose it as an SDL surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LockTextureToSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool LockTextureToSurface(nint texture, ref Rect rect, out nint surface);

        /// <summary>Unlock a texture, uploading the changes to video memory.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UnlockTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UnlockTexture(nint texture);

        #endregion

        #region Render Target

        /// <summary>Set a texture as the current rendering target. Pass NULL to render to the window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderTarget")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderTarget(nint renderer, nint texture);

        /// <summary>Get the current render target. Returns NULL for the default (window) target.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderTarget")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetRenderTarget(nint renderer);

        #endregion

        //TODO SDL_SetRenderLogicalPresentation
        //TODO SDL_GetRenderLogicalPresentation
        //TODO SDL_RenderCoordinatesFromWindow
        //TODO SDL_RenderCoordinatesToWindow
        //TODO SDL_ConvertEventToRenderCoordinates

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderViewport", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderViewport(IntPtr renderer, ref Rect rect);

        //TODO SDL_SetRenderViewport  -> add option to send NULL to set the viewport to the entire target

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderViewport", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderViewport(IntPtr renderer,  out Rect rect);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderClipRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderClipRect(IntPtr renderer, ref Rect rect);

        //TODO SDL_SetRenderClipRect  -> add option to send NULL to disable clipping

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderClipRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderClipRect(IntPtr renderer, out Rect rect);

        //TODO SDL_RenderClipEnabled

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderScale", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderScale(IntPtr renderer, float scaleX, float scaleY);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderScale", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderScale(IntPtr renderer, out float scaleX, out float scaleY);

        #region SetRenderDrawColor

        /// <summary>Set the color used for drawing operations.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderDrawColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

        /// <inheritdoc cref="SetRenderDrawColor(nint, byte, byte, byte, byte)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawColor(IntPtr renderer, Color color) => SetRenderDrawColor(renderer, color.r, color.g, color.b, color.a);

        /// <inheritdoc cref="SetRenderDrawColor(nint, byte, byte, byte, byte)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawColor(IntPtr renderer, FColor color) => SetRenderDrawColor(renderer, (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), (byte)(color.a * 255));

        #endregion

        #region GetRenderDrawColor

        /// <summary>Get the color used for drawing operations.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDrawColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

        #endregion

        //TODO SDL_SetRenderDrawBlendMode
        //TODO SDL_GetRenderDrawBlendMode

        #region Render

        /// <summary>Clear the current redering target with the drawing color.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderClear")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return:  MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderClear(IntPtr renderer);

        #region Point

        /// <summary>Draw a point on a the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="x">The X Coordinate of the point.</param>
        /// <param name="y">The Y Coordinate of the point.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderPoint")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderPoint(IntPtr renderer, float x, float y);

        /// <inheritdoc cref="RenderPoint(nint, float, float)"/>
        /// <param name="point">The point.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderPoint(IntPtr renderer, FPoint point) => RenderPoint(renderer, point.x, point.y);

        #endregion

        #region Points

        /// <summary>Draw multiple points on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple points.</param>
        /// <param name="points">The points to draw.</param>
        /// <param name="count">The number of points to draw.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderPoints")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderPoints(IntPtr renderer, FPoint* points, int count);

        /// <inheritdoc cref="RenderPoints(nint, FPoint*, int)"/>
        public static unsafe bool RenderPoints(IntPtr renderer, ReadOnlySpan<FPoint> points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderPoints(renderer, ptr, points.Length);
            }
        }

        /// <inheritdoc cref="RenderPoints(nint, FPoint*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderPoints(IntPtr renderer, FPoint[] points) => RenderPoints(renderer, (ReadOnlySpan<FPoint>)points);

        #endregion

        #region Line

        /// <summary>Draw a line on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a line.</param>
        /// <param name="x1">The X Coordinate of the start point.</param>
        /// <param name="y1">The Y Coordinate of the start point</param>
        /// <param name="x2">The X Coordinate of the end point</param>
        /// <param name="y2">The Y Coordinate of the end point</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderLine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2);

        /// <inheritdoc cref="RenderLine(nint, float, float, float, float)"/>
        /// <param name="a">Point A.</param>
        /// <param name="b">Point B.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderLine(IntPtr renderer, FPoint a, FPoint b) => RenderLine(renderer, a.x, a.y, b.x, b.y);

        #endregion

        #region Lines

        /// <summary>Draw a series of connected lines on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple lines.</param>
        /// <param name="points">The points along the lines.</param>
        /// <param name="count">The number of points.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderLines")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderLines(IntPtr renderer, FPoint* points, int count);

        /// <inheritdoc cref="RenderLines(nint, FPoint*, int)"/>
        public static unsafe bool RenderLines(IntPtr renderer, ReadOnlySpan<FPoint> points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderLines(renderer, ptr, points.Length);
            }
        }

        /// <inheritdoc cref="RenderLines(nint, FPoint*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderLines(IntPtr renderer, FPoint[] points) => RenderLines(renderer, (ReadOnlySpan<FPoint>)points);

        #endregion

        #region Rect

        /// <summary>Draw a rectangle on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderRect(IntPtr renderer, ref FRect rect);

        #endregion

        #region Rects

        /// <summary>Draw multiple rectangles on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple rectangles.</param>
        /// <param name="rects">Pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderRects")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderRects(IntPtr renderer, FRect* rects, int count);

        /// <inheritdoc cref="RenderRects(nint, FRect*, int)"/>
        public static unsafe bool RenderRects(IntPtr renderer, ReadOnlySpan<FRect> rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <inheritdoc cref="RenderRects(nint, FRect*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderRects(IntPtr renderer, FRect[] rects) => RenderRects(renderer, (ReadOnlySpan<FRect>)rects);

        #endregion

        #region FillRect

        /// <summary>Fill a rectangle on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderFillRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderFillRect(IntPtr renderer, ref FRect rect);

        #endregion

        #region FillRects

        /// <summary>Fill multiple rectangles on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill multiple rectangles.</param>
        /// <param name="rects">Pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderFillRects")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderFillRects(IntPtr renderer, FRect* rects, int count);

        /// <inheritdoc cref="RenderFillRects(nint, FRect*, int)"/>
        public static unsafe bool RenderFillRects(IntPtr renderer, ReadOnlySpan<FRect> rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderFillRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <inheritdoc cref="RenderFillRects(nint, FRect*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderFillRects(IntPtr renderer, FRect[] rects) => RenderFillRects(renderer, (ReadOnlySpan<FRect>)rects);

        #endregion

        /// <summary>Copy a portion of the texture to the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcRect">Pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstRect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTexture(IntPtr renderer, IntPtr texture, ref FRect srcRect, ref FRect dstRect);

        // TODO SDL_RenderTexture9Grid
        //TODO SDL_RenderTextureRotated

        #region Geometry

        /// <summary>Render geometry using an optional texture and index buffer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderGeometry")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderGeometry(IntPtr renderer, IntPtr texture, Vertex* vertices, int numVertices, int* indices, int numIndices);

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(IntPtr renderer, ReadOnlySpan<Vertex> vertices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                return RenderGeometry(renderer, IntPtr.Zero, verticesPtr, vertices.Length, null, 0);
            }
        }

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(IntPtr renderer, ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                fixed(int* indicesPtr = indices)
                {
                    return RenderGeometry(renderer, IntPtr.Zero, verticesPtr, vertices.Length, indicesPtr, indices.Length);
                }
            }
        }

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(IntPtr renderer, IntPtr texture, ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices = default)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                if (indices.IsEmpty)
                    return RenderGeometry(renderer, texture, verticesPtr, vertices.Length, null, 0);
                
                fixed(int* indicesPtr = indices)
                {
                    return RenderGeometry(renderer, texture, verticesPtr, vertices.Length, indicesPtr, indices.Length);
                }
            }
        }


        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderGeometry(IntPtr renderer, Vertex[] vertices) => RenderGeometry(renderer, (ReadOnlySpan<Vertex>)vertices);

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderGeometry(IntPtr renderer, Vertex[] vertices, int[] indices) => RenderGeometry(renderer, (ReadOnlySpan<Vertex>)vertices, (ReadOnlySpan<int>)indices);

        #endregion

        /// <summary>Renders a filled circle using triangles. (Custom Method)</summary>
        /// <param name="renderer">The renderer which should draw a filled circle.</param>
        /// <param name="center">Center position</param>
        /// <param name="radius">Circle radius</param>
        /// <param name="color">Color of the circle</param>
        /// <param name="segments">Number of triangles (more = smoother)</param>
        /// <returns>True if succesful, false otherwise</returns>
        public static bool RenderCircle(IntPtr renderer, FPoint center, float radius, FColor color, int segments = 16)
        {
            if (radius <= 0 || segments < 3)
                return false;

            // 1 Segment = 1 Triangle = 3 Vertices
            Vertex[] vertices = new Vertex[segments * 3];

            float angleStep = 2f * MathF.PI / segments;

            for(int i = 0; i < segments; i++)
            {
                float angle1 = i * angleStep;
                float angle2 = (i + 1) * angleStep;

                float x1 = center.x + MathF.Cos(angle1) * radius;
                float y1 = center.y + MathF.Sin(angle1) * radius;
                float x2 = center.x + MathF.Cos(angle2) * radius;
                float y2 = center.y + MathF.Sin(angle2) * radius;

                int idx = i * 3;

                vertices[idx] = new Vertex
                {
                    position = new FPoint(center.x, center.y),
                    color = color,
                    text_coord = new FPoint()
                };

                vertices[idx + 1] = new Vertex
                {
                    position = new FPoint(x1, y1),
                    color = color,
                    text_coord = new FPoint()
                };

                vertices[idx + 2] = new Vertex
                {
                    position = new FPoint(x2, y2),
                    color = color,
                    text_coord = new FPoint()
                };
            }

            return RenderGeometry(renderer, vertices);
        }

        //TODO SDL_RenderGeometryRaw
        //TODO SDL_RenderGeometryRawFloat

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderReadPixels")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderReadPixels(IntPtr renderer, ref Rect rect);

        /// <summary>Update the screen with any rendering performed since the previous call.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderPresent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderPresent(IntPtr renderer);

        /// <summary>Destroy the specified texture.</summary>
        /// <param name="texture">The texture to destroy.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyTexture(IntPtr texture);

        /// <summary>Destroy the rendering context for a window and free all associated textures.</summary>
        /// <param name="renderer">The rendering context.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyRenderer(IntPtr renderer);

        /// <summary>Force the rendering context to flush any pending commands and state.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_FlushRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FlushRenderer(IntPtr renderer);

        // TODO SDL_GetRenderMetalLayer
        // TODO SDL_GetREnderMetalCommandEncoder

        // Vsync 1 for on, 0 for off. All other values are reserved
        /// <summary>Toggle VSync of the given renderer. <br></br>
        /// 0 = Disabled | -1 = Adaptive | 1 = Every | 2 = Every second | etc.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">Vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderVSync(IntPtr renderer, int vsync);

        /// <summary>Get VSync of the given renderer.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">An int filled with the current vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderVSync(IntPtr renderer, out int vsync);
    }
}
