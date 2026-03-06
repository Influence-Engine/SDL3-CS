using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
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

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetNumRenderDrivers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumRenderDrivers();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDriver", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetRenderDriver(int index);
        public static string GetRenderDriver(int index) => Marshal.PtrToStringUTF8(Internal_GetRenderDriver(index));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowAndRenderer", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool Internal_CreateWindowAndRenderer(byte* title, int width, int height, WindowFlags flags, IntPtr window, IntPtr renderer);
        /// <summary>Create a window and default renderer.</summary>
        /// <param name="title">Title of the window.</param>
        /// <param name="width">Width of the window.</param>
        /// <param name="height">Height of the window.</param>
        /// <param name="flags">Flags used to create the window.</param>
        /// <param name="window">Pointer filled with the window.</param>
        /// <param name="renderer">Pointer filled with the renderer.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool CreateWindowAndRenderer(string title, int width, int height, WindowFlags flags, IntPtr window, IntPtr renderer)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_CreateWindowAndRenderer(Utility.UTF8Encode(title, utf8Title, utf8TitleBufferSize), width, height, flags, window, renderer);
        }

        /// <summary>Create a 2D rendering context for a window.</summary>
        /// <param name="window">The window where rendering is displayed.</param>
        /// <param name="name">The name of the rendering driver to initialize, or NULL to let SDL choose one.</param>
        /// <returns>A valid rendering pointer or 0 on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateRenderer", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr CreateRenderer(IntPtr window, byte* name);

        /// <summary>Create a 2D rendering context for a window.</summary>
        /// <param name="window">The window where rendering is displayed.</param>
        /// <param name="name">The name of the rendering driver to initialize, or NULL to let SDL choose one.</param>
        /// <returns>A valid rendering pointer or 0 on failure.</returns>
        public static unsafe IntPtr CreateRenderer(IntPtr window, string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return CreateRenderer(window, Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));

        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateSoftwareRenderer", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateSoftwareRenderer(IntPtr surface);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderer", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRenderer(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRenderWindow(IntPtr renderer);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderOutputSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderOutputSize(IntPtr renderer, out int w, out int h);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentRenderOutputSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurrentRenderOutputSize(IntPtr renderer, out int w, out int h);

        /// <summary>Create a texture for a rendering context.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <param name="format">One of the enumerated values in PixelFormat.</param>
        /// <param name="access">One of the enumerated values in TextureAccess.</param>
        /// <param name="w">Width of the texture in pixels.</param>
        /// <param name="h">Height of the texture in pixels.</param>
        /// <returns>Pointer to the created texture or NULL on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateTexture(IntPtr renderer, PixelFormat format, TextureAccess access, int w, int h);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateTextureFromSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

        // TODO SDL_CreateTextureWithPropertiesß

        [DllImport(nativeLibraryName, EntryPoint = "SDL_QueryTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTexture(IntPtr renderer, out uint format, out int access, out int w, out int h);

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

        [DllImport(nativeLibraryName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTexture(IntPtr texture, ref Rect rect, IntPtr pixel, int pitch);

        //TODO SDL_UpdateYUVTexture
        //TODO SDL_UpdateNVTexture

        [DllImport(nativeLibraryName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockTexture(IntPtr texture, ref Rect rect, out IntPtr pixel, out int pitch);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_LockTextureToSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockTextureToSurface(IntPtr texture, ref Rect rect, out IntPtr surface);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_UnlockTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnlockTexture(IntPtr texture);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderTarget(IntPtr renderer, IntPtr texture);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRenderTarget(IntPtr renderer);

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

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

        //TODO SDL_SetRenderDrawBlendMode
        //TODO SDL_GetRenderDrawBlendMode

        /// <summary>Clear the current redering target with the drawing color.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderClear", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderClear(IntPtr renderer);

        /// <summary>Draw a point on a the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="x">The X Coordinate of the point.</param>
        /// <param name="y">The Y Coordinate of the point.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderPoint", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderPoint(IntPtr renderer, float x, float y);

        /// <summary>Draw a point on a the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="point">The point.</param>
        /// <returns>True on success or false on failure.</returns>
        public static bool RenderPoint(IntPtr renderer, FPoint point) => RenderPoint(renderer, point.x, point.y);

        /// <summary>Draw multiple points on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple points.</param>
        /// <param name="points">The points to draw.</param>
        /// <param name="count">The number of points to draw.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderPoints", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe bool RenderPoints(IntPtr renderer, FPoint* points, int count);

        /// <summary>Draw multiple points on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple points.</param>
        /// <param name="points">The points to draw.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool RenderPoints(IntPtr renderer, FPoint[] points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderPoints(renderer, ptr, points.Length);
            }
        }

        /// <summary>Draw a line on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a line.</param>
        /// <param name="x1">The X Coordinate of the start point.</param>
        /// <param name="y1">The Y Coordinate of the start point</param>
        /// <param name="x2">The X Coordinate of the end point</param>
        /// <param name="y2">The Y Coordinate of the end point</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderLine", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2);

        /// <summary>Draw a line on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a line.</param>
        /// <param name="a">Point A.</param>
        /// <param name="b">Point B.</param>
        /// <returns>True on success or false on failure.</returns>
        public static bool RenderLine(IntPtr renderer, FPoint a, FPoint b) => RenderLine(renderer, a.x, a.y, b.x, b.y);

        /// <summary>Draw a series of connected lines on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple lines.</param>
        /// <param name="points">The points along the lines.</param>
        /// <param name="count">The number of points.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderLines", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern bool RenderLines(IntPtr renderer, FPoint* points, int count);

        /// <summary>Draw a series of connected lines on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple lines.</param>
        /// <param name="points">The points along the lines.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool RenderLines(IntPtr renderer, FPoint[] points)
        {
            fixed (FPoint* ptr = points)
            {
                return RenderLines(renderer, ptr, points.Length);
            }
        }

        /// <summary>Draw a rectangle on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderRect(IntPtr renderer, ref FRect rect);

        /// <summary>Draw multiple rectangles on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple rectangles.</param>
        /// <param name="rects">Pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderRects", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern bool RenderRects(IntPtr renderer, FRect* rects, int count);

        /// <summary>Draw multiple rectangles on the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should draw multiple rectangles.</param>
        /// <param name="rects">Array of destination rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool RenderRects(IntPtr renderer, FRect[] rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <summary>Fill a rectangle on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderFillRect(IntPtr renderer, ref FRect rect);

        /// <summary>Fill multiple rectangles on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill multiple rectangles.</param>
        /// <param name="rects">Pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderFillRects", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe bool RenderFillRects(IntPtr renderer, FRect* rects, int count);

        /// <summary>Fill multiple rectangles on the current rendering target with the drawing color at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should fill multiple rectangles.</param>
        /// <param name="rects">Array of destination rectangles.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool RenderFillRects(IntPtr renderer, FRect[] rects)
        {
            fixed (FRect* rectsPtr = rects)
            {
                return RenderFillRects(renderer, rectsPtr, rects.Length);
            }
        }

        /// <summary>Copy a portion of the texture to the current rendering target at subpixel precision.</summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcRect">Pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstRect">Pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderTexture(IntPtr renderer, IntPtr texture, ref FRect srcRect, ref FRect dstRect);

        // TODO SDL_RenderTexture9Grid
        //TODO SDL_RenderTextureRotated

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderGeometry", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe bool RenderGeometry(IntPtr renderer, IntPtr texture, Vertex* vertices, int numVertices, int* indices, int numIndices);

        public static unsafe bool RenderGeometry(IntPtr renderer, Vertex[] vertices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                return RenderGeometry(renderer, IntPtr.Zero, verticesPtr, vertices.Length, null, 0);
            }
        }

        public static unsafe bool RenderGeometry(IntPtr renderer, Vertex[] vertices, int[] indices)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                fixed(int* indicesPtr = indices)
                {
                    return RenderGeometry(renderer, IntPtr.Zero, verticesPtr, vertices.Length, indicesPtr, indices.Length);
                }
            }
        }

        public static unsafe bool RenderGeometry(IntPtr renderer, IntPtr texture, Vertex[] vertices, int[]? indices = null)
        {
            fixed (Vertex* verticesPtr = vertices)
            {
                if(indices != null)
                {
                    fixed (int* indicesPtr = indices)
                    {
                        return RenderGeometry(renderer, texture, verticesPtr, vertices.Length, indicesPtr, indices.Length);
                    }
                }
                else
                {
                    return RenderGeometry(renderer, texture, verticesPtr, vertices.Length, null, 0);
                }

            }
        }

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

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderReadPixels", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RenderReadPixels(IntPtr renderer, ref Rect rect);

        /// <summary>Update the screen with any rendering performed since the previous call.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_RenderPresent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderPresent(IntPtr renderer);

        /// <summary>Destroy the specified texture.</summary>
        /// <param name="texture">The texture to destroy.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_DestroyTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyTexture(IntPtr texture);

        /// <summary>Destroy the specified texture.</summary>
        /// <param name="texture">The texture to destroy.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_DestroyTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyTexture(Texture texture);

        /// <summary>Destroy the rendering context for a window and free all associated textures.</summary>
        /// <param name="renderer">The rendering context.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_DestroyRenderer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyRenderer(IntPtr renderer);

        /// <summary>Force the rendering context to flush any pending commands and state.</summary>
        /// <param name="renderer">The rendering context.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_FlushRenderer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FlushRenderer(IntPtr renderer);

        // TODO SDL_GetRenderMetalLayer
        // TODO SDL_GetREnderMetalCommandEncoder

        // Vsync 1 for on, 0 for off. All other values are reserved
        /// <summary>Toggle VSync of the given renderer. <br></br>
        /// 0 = Disabled | -1 = Adaptive | 1 = Every | 2 = Every second | etc.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">Vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetRenderVSync", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetRenderVSync(IntPtr renderer, int vsync);

        /// <summary>Get VSync of the given renderer.</summary>
        /// <param name="renderer">The renderer to toggle.</param>
        /// <param name="vsync">An int filled with the current vertical refresh sync interval.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetRenderVSync", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetRenderVSync(IntPtr renderer, out int vsync);
    }
}
