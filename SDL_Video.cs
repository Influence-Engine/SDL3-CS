using System;
using System.Runtime.CompilerServices;
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
            public float refresh_rate;
            public int refresh_rate_numerator;
            public int refresh_rate_denominator;

            public IntPtr internal_ptr; // SDL_DIsplayModeData* (opaque)
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
        public enum WindowFlags : ulong
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
            Modal = 0x00001000,
            HighPixelDensity = 0x00002000,
            MouseCapture = 0x00004000,
            MouseRelativeMode = 0x00008000,
            AlwaysOnTop = 0x00010000,
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

        public enum ProgressState
        {
            Invalid = -1,
            None,
            Indeterminate,
            Normal,
            Paused,
            Error
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

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNumVideoDrivers")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetNumVideoDrivers();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetVideoDriver")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetVideoDriver(int index);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentVideoDriver")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetCurrentVideoDriver();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetSystemTheme")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial SystemTheme GetSystemTheme();

        // TODO SDL_GetDisplays
        // TODO SDL_GetPrimaryDisplay
        // TODO SDL_GetDisplayProperties

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetDisplayName(uint displayID);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayBounds")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetDisplayBounds(uint displayID, out Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayUsableBounds")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetDisplayUsableBounds(uint displayID, out Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDesktopDisplayMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetDesktopDisplayMode(uint displayID, out DisplayMode mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentDisplayMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetCurrentDisplayMode(uint displayID, out DisplayMode mode);

         // TODO so much new stuff

        // TODO SDL_GetDisplayForPoint
        // TODO SDL_GetDisplayForRect
        // TODO SDL_GetDisplayForWindow
        // TODO SDL_GetWindowPixelDensity
        // TODO SDL_GetWindowDisplayScale

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreenMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowFullscreenMode(IntPtr window, ref DisplayMode mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFullscreenMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int GetWindowFullscreenMode(IntPtr window, out DisplayMode mode);

        // TODO SDL_GetWindowICCProfile

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPixelFormat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial uint GetWindowPixelFormat(IntPtr window);

        // TODO SDL_GetWindows

        /// <summary>Create a window with the specified dimensions and flags.</summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="flags">WindowFlags OR'd together.</param>
        /// <returns>The window pointer that was created or 0 on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindow", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateWindow(string title, int w, int h, WindowFlags flags);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowWithPosition", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateWindowWithPosition(string title, int x, int y, int w, int h, WindowFlags flags);

        //TODO SDL_CreatePopupWindow

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowFrom")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateWindowFrom(IntPtr data);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowID")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial uint GetWindowID(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFromID")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial IntPtr GetWindowFromID(uint id);

        //TODO SDL_GetWindowParent
        // TODO SDL_GetWindowProperties

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFlags")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial uint GetWindowFlags(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowTitle", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowTitle(IntPtr window, string title);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowTitle")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetWindowTitle(IntPtr window);

        // TODO SDL_SetWindowIcon

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowData", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowData(IntPtr window, string name, IntPtr userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowData", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowData(IntPtr window, string name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowPosition(IntPtr window, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowPosition(IntPtr window, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowSize(IntPtr window, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowSize(IntPtr window, out int x, out int y);

        // TODO SDL_GetWindowSafeArea

        // TODO SDL_SetWindowAspectRatio
        // TODO SDL_GetWindowAspectRatio

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowBordersSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSizeInPixels")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowSizeInPixels(IntPtr window, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMinimumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowMinimumSize(IntPtr window, int minX, int minY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMinimumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowMinimumSize(IntPtr window, out int minX, out int minY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMaximumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowMaximumSize(IntPtr window, int maxX, int maxY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMaximumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetWindowMaximumSize(IntPtr window, out int maxX, out int maxY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowBordered")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowBordered(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool bordered);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowResizable")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowResizable(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool resizable);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowAlwaysOnTop")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowAlwaysOnTop(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool onTop);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShowWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void ShowWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HideWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void HideWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RaiseWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RaiseWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_MaximizeWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void MaximizeWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_MinimizeWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void MinimizeWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RestoreWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RestoreWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreen")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetWindowFullscreen(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool fullscreen);

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
