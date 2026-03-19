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

        #region Texture Color / Alpha / Blend / Scale

        #region SetTextureColorMod byte/float

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureColorMod")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureColorMod(nint texture, byte r, byte g, byte b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetTextureColorMod(nint texture, Color color) => SetTextureColorMod(texture, color.r, color.g, color.b);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureColorModFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureColorMod(nint texture, float r, float g, float b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetTextureColorMod(nint texture, FColor color) => SetTextureColorMod(texture, color.r, color.g, color.b);

        #endregion

        #region GetTexturColorMod byte/float

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureColorMod")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureColorMod(nint texture, out byte r, out byte g, out byte b);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureColorModFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureColorMod(nint texture, out float r, out float g, out float b);

        #endregion

        #region TextureAlphaMod set/get

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureAlphaMod")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureAlphaMod(nint texture, byte a);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureAlphaModFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureAlphaMod(nint texture, float a);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureAlphaMod")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureAlphaMod(nint texture, out byte a);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureAlphaModFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureAlphaMod(nint texture, out float a);

        #endregion

        #region TextureBlendMode set/get

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureBlendMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureBlendMode(nint texture, int blendMode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureBlendMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureBlendMode(nint texture, out int blendMode);

        #endregion

        #region TextureBlendMode set/get

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextureScaleMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextureScaleMode(nint texture, int scaleMode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextureScaleMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextureScaleMode(nint texture, out int scaleMode);

        #endregion

        #endregion

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

        #region Logical Presentation

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderLogicalPresentation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderLogicalPresentation(nint renderer, int w, int h, RendererLogicalPresentation mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderLogicalPresentation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderLogicalPresentation(nint renderer, out int w, out int h, out RendererLogicalPresentation mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderLogicalPresentationRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderLogicalPresentationRect(nint renderer, out FRect rect);

        #endregion

        #region Coordinate conversion

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderCoordinatesFromWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderCoordinatesFromWindow(nint renderer, float windowX, float windowY, out float x, out float y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderCoordinatesToWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderCoordinatesToWindow(nint renderer, float x, float y, out float windowX, out float windowY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ConvertEventToRenderCoordinates")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ConvertEventToRenderCoordinates(nint renderer, ref Event sdlEvent);

        #endregion

        #region Viewport / Clip / Scale

        /// <summary>
        /// Set the drawing area for rendering on the current target. <br></br>
        /// Pass NULL for the entire target.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderViewport")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderViewport(nint renderer, ref Rect rect);

        /// <summary>Set the viewport to the entire target.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderViewport")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderViewport(nint renderer, nint rect);

        /// <summary>Get the drawing area for the current target.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderViewport")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderViewport(nint renderer,  out Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderViewportSet")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderViewportSet(nint renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderSafeArea")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderSafeArea(nint renderer, out Rect rect);

        /// <summary>
        /// Set the clip rectangle for rendering on the current target.<br></br>
        /// Pass NULL to disabled clipping.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderClipRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderClipRect(nint renderer, ref Rect rect);

        /// <summary>Disable clipping on the current render target.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderClipRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderClipRect(nint renderer, nint rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderClipRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderClipRect(nint renderer, out Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderClipEnabled")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderClipEnabled(nint renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderScale")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderScale(nint renderer, float scaleX, float scaleY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderScale")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderScale(nint renderer, out float scaleX, out float scaleY);

        #endregion

        #region Draw Color / Blend Mode

        #region SetRenderDrawColor

        /// <summary>Set the color used for drawing operations (byte).</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderDrawColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderDrawColor(nint renderer, byte r, byte g, byte b, byte a);

        /// <inheritdoc cref="SetRenderDrawColor(nint, byte, byte, byte, byte)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetRenderDrawColor(nint renderer, Color color) => SetRenderDrawColor(renderer, color.r, color.g, color.b, color.a);

        #endregion

        #region SetRenderDrawColorFloat

        /// <summary>Set the color used for drawing operations (float).</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderDrawColorFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderDrawColor(nint renderer, float r, float g, float b, float a);

        /// <inheritdoc cref="SetRenderDrawColor(nint, float, float, float, float)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetRenderDrawColor(nint renderer, FColor color) => SetRenderDrawColor(renderer, color.r, color.g, color.b, color.a);

        #endregion

        #region GetRenderDrawColor byte/float

        /// <summary>Get the color used for drawing operations (byte).</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDrawColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderDrawColor(nint renderer, out byte r, out byte g, out byte b, out byte a);

        /// <summary>Get the color used for drawing operations (float).</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDrawColorFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderDrawColor(nint renderer, out float r, out float g, out float b, out float a);

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderDrawBlendMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderDrawBlendMode(nint renderer, int blendMode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDrawBlendMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderDrawBlendMode(nint renderer, out int blendMode);

        #endregion

        #region Render Primitives

        /// <summary>Clear the current redering target with the drawing color.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderClear")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return:  MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderClear(nint renderer);

        #region Point

        /// <summary>Draw a point on a the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="x">The X Coordinate of the point.</param>
        /// <param name="y">The Y Coordinate of the point.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderPoint")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderPoint(nint renderer, float x, float y);

        /// <inheritdoc cref="RenderPoint(nint, float, float)"/>
        /// <param name="point">The point.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderPoint(nint renderer, FPoint point) => RenderPoint(renderer, point.x, point.y);

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
        public static unsafe partial bool RenderPoints(nint renderer, FPoint* points, int count);

        /// <inheritdoc cref="RenderPoints(nint, FPoint*, int)"/>
        public static unsafe bool RenderPoints(nint renderer, ReadOnlySpan<FPoint> points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderPoints(renderer, ptr, points.Length);
            }
        }

        /// <inheritdoc cref="RenderPoints(nint, FPoint*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderPoints(nint renderer, FPoint[] points) => RenderPoints(renderer, (ReadOnlySpan<FPoint>)points);

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
        public static partial bool RenderLine(nint renderer, float x1, float y1, float x2, float y2);

        /// <inheritdoc cref="RenderLine(nint, float, float, float, float)"/>
        /// <param name="a">Point A.</param>
        /// <param name="b">Point B.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderLine(nint renderer, FPoint a, FPoint b) => RenderLine(renderer, a.x, a.y, b.x, b.y);

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
        public static unsafe partial bool RenderLines(nint renderer, FPoint* points, int count);

        /// <inheritdoc cref="RenderLines(nint, FPoint*, int)"/>
        public static unsafe bool RenderLines(nint renderer, ReadOnlySpan<FPoint> points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderLines(renderer, ptr, points.Length);
            }
        }

        /// <inheritdoc cref="RenderLines(nint, FPoint*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderLines(nint renderer, FPoint[] points) => RenderLines(renderer, (ReadOnlySpan<FPoint>)points);

        #endregion

        #region Rect

        /// <summary>Draw a rectangle on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderRect(nint renderer, ref FRect rect);

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
        public static unsafe partial bool RenderRects(nint renderer, FRect* rects, int count);

        /// <inheritdoc cref="RenderRects(nint, FRect*, int)"/>
        public static unsafe bool RenderRects(nint renderer, ReadOnlySpan<FRect> rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <inheritdoc cref="RenderRects(nint, FRect*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderRects(nint renderer, FRect[] rects) => RenderRects(renderer, (ReadOnlySpan<FRect>)rects);

        #endregion

        #region FillRect

        /// <summary>Fill a rectangle on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderFillRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderFillRect(nint renderer, ref FRect rect);

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
        public static unsafe partial bool RenderFillRects(nint renderer, FRect* rects, int count);

        /// <inheritdoc cref="RenderFillRects(nint, FRect*, int)"/>
        public static unsafe bool RenderFillRects(nint renderer, ReadOnlySpan<FRect> rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderFillRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <inheritdoc cref="RenderFillRects(nint, FRect*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderFillRects(nint renderer, FRect[] rects) => RenderFillRects(renderer, (ReadOnlySpan<FRect>)rects);

        #endregion

        #endregion

        #region Texture Rendering

        /// <summary>Copy a portion of the texture to the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcRect">Pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstRect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTexture(nint renderer, nint texture, ref FRect srcRect, ref FRect dstRect);

        /// <inheritdoc cref="RenderTexture"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTexture(nint renderer, nint texture, nint srcRect, ref FRect dstRect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTextureRotated")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTextureRotated(nint renderer, nint texture, ref FRect srcRect, ref FRect dstRect, double angle, ref FPoint center, int flip);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTextureRotated")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTextureRotated(nint renderer, nint texture, nint srcRect, ref FRect dstRect, double angle, ref FPoint center, int flip);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTextureAffine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTextureAffine(nint renderer, nint texture, ref FRect srcRect, ref FPoint origin, ref FPoint right, ref FPoint down);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTextureTiled")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTextureTiled(nint renderer, nint texture, ref FRect srcRect, float scale, ref FRect dstRect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture9Grid")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTexture9Grid(nint renderer, nint texture, ref FRect srcRect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, ref FRect dstRect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture9GridTiled")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderTexture9GridTiled(nint renderer, nint texture, ref FRect srcRect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, ref FRect dstRect, float tileScale);

        #endregion

        #region Geometry

        /// <summary>Render geometry using an optional texture and index buffer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderGeometry")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderGeometry(nint renderer, nint texture, Vertex* vertices, int numVertices, int* indices, int numIndices);

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(nint renderer, ReadOnlySpan<Vertex> vertices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                return RenderGeometry(renderer, nint.Zero, verticesPtr, vertices.Length, null, 0);
            }
        }

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(nint renderer, ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                fixed(int* indicesPtr = indices)
                {
                    return RenderGeometry(renderer, nint.Zero, verticesPtr, vertices.Length, indicesPtr, indices.Length);
                }
            }
        }

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        public static unsafe bool RenderGeometry(nint renderer, nint texture, ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices = default)
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
        public static bool RenderGeometry(nint renderer, Vertex[] vertices) => RenderGeometry(renderer, (ReadOnlySpan<Vertex>)vertices);

        /// <inheritdoc cref="RenderGeometry(nint, nint, Vertex*, int, int*, int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderGeometry(nint renderer, Vertex[] vertices, int[] indices) => RenderGeometry(renderer, (ReadOnlySpan<Vertex>)vertices, (ReadOnlySpan<int>)indices);

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderGeometryRaw")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool RenderGeometryRaw(nint renderer, nint texture, float* xy, int xyStride, FColor* color, int colorStride, float* uv, int uvStride, int numVertices, void* indices, int numIndices, int sizeIndices);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderTextureAddressMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderTextureAddressMode(nint renderer, TextureAddressMode uMode, TextureAddressMode vMode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderTextureAddressMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderTextureAddressMode(nint renderer, out TextureAddressMode uMode, out TextureAddressMode vMode);

        #region RenderCircle (Custom function)

        /// <summary>Renders a filled circle using triangles. (Custom Method)</summary>
        /// <param name="renderer">The renderer which should draw a filled circle.</param>
        /// <param name="center">Center position</param>
        /// <param name="radius">Circle radius</param>
        /// <param name="color">Color of the circle</param>
        /// <param name="segments">Number of triangles (more = smoother)</param>
        /// <returns>True if succesful, false otherwise</returns>
        public static bool RenderCircle(nint renderer, FPoint center, float radius, FColor color, int segments = 16)
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
                    position = center,
                    color = color
                };

                vertices[idx + 1] = new Vertex
                {
                    position = new FPoint(x1, y1),
                    color = color
                };

                vertices[idx + 2] = new Vertex
                {
                    position = new FPoint(x2, y2),
                    color = color
                };
            }

            return RenderGeometry(renderer, vertices);
        }

        #endregion

        #region Read Pixels / Present / Destroy / Flush

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderReadPixels")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint RenderReadPixels(nint renderer, ref Rect rect);

        /// <summary>Update the screen with any rendering performed since the previous call.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderPresent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderPresent(nint renderer);

        /// <summary>Destroy the specified texture.</summary>
        /// <param name="texture">The texture to destroy.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyTexture")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyTexture(nint texture);

        /// <summary>Destroy the rendering context for a window and free all associated textures.</summary>
        /// <param name="renderer">The rendering context.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyRenderer(nint renderer);

        /// <summary>Force the rendering context to flush any pending commands and state.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_FlushRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FlushRenderer(nint renderer);

        #endregion

        #region Metal / Vulkan / GDK

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderMetalLayer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetRenderMetalLayer(nint renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderMetalCommandEncoder")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetRenderMetalCommandEncoder(nint renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_AddVulkanRenderSemaphores")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AddVulkanRenderSemaphores(nint renderer, uint waitStageMask, long waitSemaphore, long signalSemaphore);

        #endregion

        #region VSync

        /// <summary>Toggle VSync of the given renderer. <br></br>
        /// 0 = Disabled | -1 = Adaptive | 1 = Every | 2 = Every second | etc.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">Vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRenderVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRenderVSync(nint renderer, int vsync);

        /// <summary>Get VSync of the given renderer.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">An int filled with the current vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRenderVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetRenderVSync(nint renderer, out int vsync);

        #endregion

        #region Debug Text

        /// <summary>
        /// Draw debug text to a renderer. For debugging only. (severe limitations apply). <br></br>
        /// Uses the current draw color. 8x8 pixel monospaced font, ASCII only.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RenderDebugText", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RenderDebugText(nint renderer, float x, float y, string str);

        #endregion

        #region Default Texture Scale Mode

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetDefaultTextureScaleMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetDefaultTextureScaleMode(nint renderer, int scaleMode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDefaultTextureScaleMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetDefaultTextureScaleMode(nint renderer, out int scaleMode);

        #endregion

        #region GPU Render State

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPURenderState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateGPURenderState(nint renderer, nint createInfo);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPURenderStateFragmentUniforms")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetGPURenderStateFragmentUniforms(nint state, uint slotIndex, void* date, uint length);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPURenderState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetGPURenderState(nint renderer, nint state);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyGPURenderState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyGPURenderState(nint state);

        #endregion

        #region GDK Suspend/Resume (Xbox Only)

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GDKSuspendRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GDKSuspendRenderer(nint renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GDKResumeRenderer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GDKResumeRenderer(nint renderer);

        #endregion
    }
}
