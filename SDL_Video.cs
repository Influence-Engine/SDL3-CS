using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public enum SystemTheme
        {
            Unknown,
            Light,
            Dark
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DisplayMode
        {
            public uint displayID;
            public uint format;
            public int w;
            public int h;
            public float pixel_density;
            float refresh_rate;
            public IntPtr driverdata;
        }

        public enum DisplayOrientation
        {
            Unknown,
            Landscape,
            LandscapeFlipped,
            Portrait,
            PortraitFlipped
        }

        [Flags]
        public enum WindowFlags : uint
        {
            Fullscreen = 0x00000001,
            OpenGL = 0x00000002,
            Occluded = 0x00000004,
            Hidden = 0x00000008,
            Borderless = 0x00000010,
            Resizable = 0x00000020,
            Minimized = 0x00000040,
            Maximized = 0x00000080,
            MouseGrabbed = 0x00000100,
            InputFocus = 0x00000200,
            MouseFocus = 0x00000400,
            External = 0x00000800,
            HighPixelDensity = 0x00002000,
            MouseCapture = 0x00004000,
            AlwaysOnTop = 0x00008000,
            Utility = 0x00020000,
            Tooltip = 0x00040000,
            PopupMenu = 0x00080000,
            KeyboardGrabbed = 0x00100000,
            Vulkan = 0x10000000,
            Metal = 0x20000000,
            Transparent = 0x40000000,
            NotFocusable = 0x80000000
        }

        public const int WindowPos_Undefined_Mask = 0x1FFF0000;
        public const int WindowPos_Undefined = 0x1FFF0000;
        public const int WindowPos_Centered_Mask = 0x2FFF0000;
        public const int WindowPos_Centered = 0x2FFF0000;

        public enum FlashOperation
        {
            Cancel,
            Briefly,
            UntilFocused
        }

        public enum GLAttributes
        {
            RedSize,
            GreenSize,
            BlueSize,
            AlphaSize,
            BufferSize,
            DoubleBuffer,
            DepthSize,
            StencilSize,
            AccumRedSize,
            AccumGreenSize,
            AccumBlueSize,
            AccumAlphaSize,
            Stereo,
            MultiSampleBuffers,
            MultiSampleSamples,
            AcceleratedVisual,
            RetainedBacking,
            ContextMajorVersion,
            ContextMinorVersion,
            ContextFlags,
            ContextProfileMask,
            ShareWithCurrentContext,
            FramebufferSRGBCapable,
            ContextReleaseBehavior,
            ContextResetNotification,
            ContextNoError,
            FloatBuffers,
            EGLPlatform
        }

        [Flags]
        public enum GLProfile
        {
            Core = 0x0001,
            Compatibility = 0x0002,
            ES = 0x0004
        }

        [Flags]
        public enum GLContext
        {
            DebugFlag = 0x0001,
            ForwardCompatibleFlag = 0x0002,
            RobustAccessFlag = 0x0004,
            ResetIsolationFlag = 0x0008
        }

        [Flags]
        public enum GLContextRelease
        {
            BehaviorNone = 0x0000,
            BehaviorFlush = 0x0001
        }

        [Flags]
        public enum GLContextResetNotification
        {
            NoNotification = 0x0000,
            LoseContext = 0x0001
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetNumVideoDrivers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumVideoDrivers();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetVideoDriver(int index);
        public static string GetVideoDriver(int index) => Marshal.PtrToStringUTF8(Internal_GetVideoDriver(index));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetCurrentVideoDriver();
        public static string GetCurrentVideoDriver() => Marshal.PtrToStringUTF8(Internal_GetCurrentVideoDriver());

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetSystemTheme", CallingConvention = CallingConvention.Cdecl)]
        public static extern SystemTheme GetSystemTheme();

        //TODO SDL_GetDisplays
        //TODO SDL_GetPrimaryDisplay

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetDisplayName(int index);
        public static string GetDisplayName(int index) => Marshal.PtrToStringUTF8(Internal_GetDisplayName(index));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayBounds", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayBounds(int displayIndex, out Rect rect);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayUsableBounds", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayUsableBounds(int displayIndex, out Rect rect);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetDesktopDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDesktopDisplayMode(int displayIndex, out DisplayMode mode);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

        // TODO SDL_GetDisplayForPoint
        // TODO SDL_GetDisplayForRect
        // TODO SDL_GetDisplayForWindow
        // TODO SDL_GetWindowPixelDensity
        // TODO SDL_GetWindowDisplayScale

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreenMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowFullscreenMode(IntPtr window, ref DisplayMode mode);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFullscreenMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowFullscreenMode(IntPtr window, out DisplayMode mode);

        // TODO SDL_GetWindowICCProfile

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPixelFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetWindowPixelFormat(IntPtr window);

        // TODO SDL_GetWindows

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr Internal_CreateWindow(byte* title, int w, int h, WindowFlags flags);
        /// <summary>Create a window with the specified dimensions and flags.</summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="flags">WindowFlags OR'd together.</param>
        /// <returns>The window pointer that was created or 0 on failure.</returns>
        public static unsafe IntPtr CreateWindow(string title, int width, int height, WindowFlags flags)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_CreateWindow(Utility.UTF8Encode(title, utf8Title, utf8TitleBufferSize), width, height, flags);
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowWithPosition", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr Internal_CreateWindowWithPosition(byte* title, int x, int y, int w, int h, WindowFlags flags);
        public static unsafe IntPtr CreateWindowWithPosition(string title, int x, int y, int w, int h, WindowFlags flags)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_CreateWindowWithPosition(Utility.UTF8Encode(title, utf8Title, utf8TitleBufferSize), x, y, w, h, flags);
        }

        //TODO SDL_CreatePopupWindow

        [DllImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowFrom", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateWindowFrom(IntPtr data);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetWindowID(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFromID", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowFromID(uint id);

        //TODO SDL_GetWindowParent
        // TODO SDL_GetWindowProperties

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFlags", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetWindowFlags(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe void Internal_SetWindowTitle(IntPtr window, byte* title);
        public static unsafe void SetWindowTitle(IntPtr window, string title)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            Internal_SetWindowTitle(window, Utility.UTF8Encode(title, utf8Title, utf8TitleBufferSize));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetWindowTitle(IntPtr window);
        public static string GetWindowTitle(IntPtr window)
        {
            return Marshal.PtrToStringUTF8(Internal_GetWindowTitle(window));
        }

        // TODO SDL_SetWindowIcon

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe void Internal_SetWindowData(IntPtr window, byte* name, IntPtr userdata);
        public static unsafe void SetWindowData(IntPtr window, string name, IntPtr userdata)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            Internal_SetWindowData(window, Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize), userdata);
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr Internal_GetWindowData(IntPtr window, byte* name);
        public static unsafe IntPtr GetWindowData(IntPtr window, string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_GetWindowData(window, Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowPosition(IntPtr window, int x, int y);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowPosition(IntPtr window, out int x, out int y);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowSize(IntPtr window, int x, int y);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowSize(IntPtr window, out int x, out int y);

        // TODO SDL_GetWindowSafeArea

        // TODO SDL_SetWindowAspectRatio
        // TODO SDL_GetWindowAspectRatio

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowBordersSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSizeInPixels", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowSizeInPixels(IntPtr window, out int x, out int y);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMinimumSize(IntPtr window, int minX, int minY);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowMinimumSize(IntPtr window, out int minX, out int minY);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMaximumSize(IntPtr window, int maxX, int maxY);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowMaximumSize(IntPtr window, out int maxX, out int maxY);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowBordered(IntPtr window, bool bordered);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowResizable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowResizable(IntPtr window, bool resizable);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowAlwaysOnTop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowAlwaysOnTop(IntPtr window, bool onTop);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_ShowWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HideWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RaiseWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RaiseWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MaximizeWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_MinimizeWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MinimizeWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RestoreWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RestoreWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreen", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowFullscreen(IntPtr window, bool fullscreen);

        // TODO SDL_SyncWindow
        //TODO SDL_WindowHasSurface

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowSurface(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_UpdateWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWindowSurface(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_UpdateWindowSurfaceRects", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWindowSurfaceRects(IntPtr window, [In] Rect[] rects, int numrects);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_DestroyWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DestroyWindowSurface(IntPtr window);

        //TODO SDL_SetWindowGrab
        //TODO SDL_SetWindowKeyboardGrab
        //TODO SDL_SetWindowMouseGrab

        //TODO SDL_GetWindowGrab
        //TODO SDL_GetWindowKeyboardGrab
        //TODO SDL_GetWindowMouseGrab

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetGrabbedWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetGrabbedWindow();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowMouseRect(IntPtr window, ref Rect rect);

        // Additional function allows for IntPtr.Zero to be passed for rect
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowMouseRect(IntPtr window, IntPtr rect);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowMouseRect(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowOpacity(IntPtr window, float opacity);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowOpacity(IntPtr window, out float opacity);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowModalFor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowModalFor(IntPtr modalWindow, IntPtr parentWIndow);

        //TODO SDL_SetWindowFocusable

        [DllImport(nativeLibraryName, EntryPoint = "SDL_ShowWindowSystemMenu", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ShowWindowSystemMenu(IntPtr window, int x, int y);

        public enum HitTestResult
        {
            Normal,
            Draggable,
            ResizeTopLeft,
            ResizeTop,
            ResizeTopRight,
            ResizeRight,
            ResizeBottomRight,
            ResizeBottom,
            ResizeBottomLeft,
            ResizeLeft
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate HitTestResult hitTest(IntPtr window, IntPtr area, IntPtr data);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetWindowHitTest", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowHitTest(IntPtr window, hitTest callback, IntPtr callbackData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_FlashWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FlashWindow(IntPtr window, FlashOperation operation);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_DestroyWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_ScreenSaverEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ScreenSaverEnabled();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_EnableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EnableScreenSaver();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_DisableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DisableScreenSaver();

        /**
         * All other missing bindings are related to OpenGL or other
         * these bindings will eventually be added!
         */

        // TODO SDL_GL_LoadLibrary
        // TODO SDL_GL_GetProcAddress
        // TODO SDL_EGL_GetProcAddress
        // TODO SDL_GL_UnloadLibrary
        // TODO SDL_GL_ExtensionSupported


        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_ResetAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GLResetAttributes();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_SetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLSetAttribute(GLAttributes attr, int value);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_GetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLGetAttribute(GLAttributes attr, ref int value);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_CreateContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLContext GLCreateContext(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_MakeCurrent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLMakeCurrent(IntPtr window, GLContext context);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GLGetCurrentWindow();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLContext GLGetCurrentContext();

        // TODO SDL_EGL_GetCurrentEGLDisplay
        // TODO SDL_EGL_GetCurrentEGLConfig
        // TODO SDL_EGL_GetWindowEGLSurface

        // TODO SDL_EGL_SetEGLAttributeCallbacks

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_SetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLSetSwapInterval(int interval);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_GetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLGetSwapInterval(ref int interval);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_SwapWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLSwapWindow(IntPtr window);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GL_DeleteContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLDeleteContext(GLContext context);
    }
}
