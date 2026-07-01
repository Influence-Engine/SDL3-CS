using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        #region Constants

        public const int WindowPos_Undefined_Mask = 0x1FFF0000;
        public static int WindowPos_Undefined = WindowPos_Undefined_Mask | 0;
        public const int WindowPos_Centered_Mask = 0x2FFF0000;
        public const int WindowPos_Centered = WindowPos_Centered_Mask | 0;

        public const int WindowSurfaceVSyncDisabled = 0;
        public const int WindowSurfaceVSyncAdaptive = -1;

        #endregion

        #region Enums

        public enum SystemTheme
        {
            Unknown,
            Light,
            Dark
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
            FillDocument = 0x00200000,
            Vulkan = 0x10000000,
            Metal = 0x20000000,
            Transparent = 0x40000000,
            NotFocusable = 0x80000000
        }

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

        #endregion

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct DisplayMode
        {
            public uint displayID;
            public uint format; // SDL_PixelFormat
            public int w;
            public int h;
            public float pixel_density;
            public float refresh_rate;
            public int refresh_rate_numerator;
            public int refresh_rate_denominator;

            public IntPtr internal_ptr; // SDL_DIsplayModeData* (opaque)
        }

        #endregion

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate HitTestResult HitTestCallback(IntPtr window, IntPtr area, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr EGLAttribArrayCallback(IntPtr userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr EGLIntArrayCallback(IntPtr userdata, IntPtr display, IntPtr config);

        #endregion

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

        #region Display Functions

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplays")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial uint* GetDisplays(out int count);

        public static unsafe Span<uint> GetDisplays()
        {
            uint* ptr = GetDisplays(out int count);
            return (ptr == null || count == 0) ? Span<uint>.Empty : new Span<uint>(ptr, count);
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPrimaryDisplay")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetPrimaryDisplay();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetDisplayProperties(uint displayID);

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

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNaturalDisplayOrientation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial DisplayOrientation GetNaturalDisplayOrientation(uint displayID);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentDisplayOrientation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial DisplayOrientation GetCurrentDisplayOrientation(uint displayID);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayContentScale")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetDisplayContentScale(uint displayID);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetFullscreenDisplayModes")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial DisplayMode** GetFullscreenDisplayModes(uint displayID, out int count);

        public static unsafe DisplayMode[] GetFullscreenDisplayModes(uint displayID)
        {
            DisplayMode** ptr = GetFullscreenDisplayModes(displayID, out int count);
            if (ptr == null || count == 0)
                return [];

            DisplayMode[] result = new DisplayMode[count];
            for (int i = 0; i < count; i++)
                result[i] = *ptr[i];

            return result;
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetClosestFullscreenDisplayMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetClosestFullscreenDisplayMode(uint displayID, int w, int h, float refreshRate, [MarshalAs(UnmanagedType.I1)] bool includeHighDesnsityModes, out DisplayMode closest);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDesktopDisplayMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetDesktopDisplayMode(uint displayID, out DisplayMode mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCurrentDisplayMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetCurrentDisplayMode(uint displayID, out DisplayMode mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayForPoint")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetDisplayForPoint(ref Point point);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayForRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetDisplayForRect(ref Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDisplayForWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetDisplayForWindow(IntPtr window);

        #endregion

        #region Window Functions

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPixelDensity")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetWindowPixelDensity(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowDisplayScale")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetWindowDisplayScale(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreenMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowFullscreenMode(IntPtr window, ref DisplayMode mode);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFullscreenMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowFullscreenMode(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowICCProfile")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowICCProfile(IntPtr window, out nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPixelFormat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial uint GetWindowPixelFormat(IntPtr window);

        /// <summary>Gets a list of valid windows.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindows")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial IntPtr* GetWindows(out int count);

        /// <inheritdoc cref="GetWindows"/>
        public static unsafe Span<IntPtr> GetWindows()
        {
            IntPtr* ptr = GetWindows(out int count);
            return (ptr == null || count == 0) ? Span<IntPtr>.Empty : new Span<IntPtr>(ptr, count);
        }

        /// <summary>Create a window with the specified dimensions and flags.</summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="w">The width of the window.</param>
        /// <param name="h">The height of the window.</param>
        /// <param name="flags">WindowFlags OR'd together.</param>
        /// <returns>The window pointer that was created or 0 on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindow", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateWindow(string title, int w, int h, WindowFlags flags);

        /// <summary>Create a child popup window of the specified parent window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreatePopupWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreatePopupWindow(IntPtr parent, int offsetX, int offsetY, int w, int h, WindowFlags flags);

        /// <summary>Create a window with the specified properties.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateWindowWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateWindowWithProperties(uint properties);

        /// <summary>Get the numeric ID of a window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowID")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial uint GetWindowID(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFromID")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial IntPtr GetWindowFromID(uint id);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowParent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowParent(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetWindowProperties(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFlags")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        public static partial WindowFlags GetWindowFlags(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowTitle", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowTitle(IntPtr window, string title);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowTitle")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetWindowTitle(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowIcon")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowIcon(IntPtr window, IntPtr icon); // SDL_Surface*

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowPosition(IntPtr window, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowPosition(IntPtr window, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowSize(IntPtr window, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowSize(IntPtr window, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSafeArea")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowSafeArea(IntPtr window, out Rect rect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowAspectRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowAspectRatio(IntPtr window, float minAspect, float maxAspect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowAspectRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowAspectRatio(IntPtr window, out float minAspect, out float maxAspect);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowBordersSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSizeInPixels")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowSizeInPixels(IntPtr window, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMinimumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowMinimumSize(IntPtr window, int minX, int minY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMinimumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowMinimumSize(IntPtr window, out int minX, out int minY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMaximumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowMaximumSize(IntPtr window, int maxX, int maxY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMaximumSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowMaximumSize(IntPtr window, out int maxX, out int maxY);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowBordered")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowBordered(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool bordered);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowResizable")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowResizable(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool resizable);

        /// <summary>Set the window to always be above the others.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowAlwaysOnTop")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowAlwaysOnTop(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool onTop);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFillDocument")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowFillDocument(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool onTop);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShowWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ShowWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HideWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HideWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RaiseWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RaiseWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_MaximizeWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool MaximizeWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_MinimizeWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool MinimizeWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RestoreWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RestoreWindow(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFullscreen")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowFullscreen(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool fullscreen);

        /// <summary>Block until any pending window state is finalized.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SyncWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SyncWindow(IntPtr window);

        /// <summary>Return whether the window has a surface associated with it..</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WindowHasSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool WindowHasSurface(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowSurface(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowSurfaceVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowSurfaceVSync(IntPtr window, int vsync);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowSurfaceVSync")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowSurfaceVSync(IntPtr window, out int vsync);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UpdateWindowSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool UpdateWindowSurface(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UpdateWindowSurfaceRects")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool UpdateWindowSurfaceRects(IntPtr window, Rect* rects, int numrects);

        public static unsafe bool UpdateWindowSurfaceRects(IntPtr window, ReadOnlySpan<Rect> rects)
        {
            fixed (Rect* ptr = rects)
                return UpdateWindowSurfaceRects(window, ptr, rects.Length);
        }

        public static unsafe bool UpdateWindowSurfaceRects(IntPtr window, Rect[] rects)
        {
            fixed (Rect* ptr = rects)
                return UpdateWindowSurfaceRects(window, ptr, rects.Length);
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyWindowSurface")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool DestroyWindowSurface(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowKeyboardGrab")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowKeyboardGrab(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool grabbed);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMouseGrab")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowMouseGrab(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool grabbed);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowKeyboardGrab")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowKeyboardGrab(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMouseGrab")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(SuppressGCTransitionAttribute)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowMouseGrab(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGrabbedWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetGrabbedWindow();

        /// <summary>Confines the cursor to the specified area of a window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowMouseRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetWindowMouseRect(IntPtr window, Rect* rect);

        /// <inheritdoc cref="SetWindowMouseRect"/>
        public static unsafe bool SetWindowMouseRect(IntPtr window, ref Rect rect)
        {
            fixed (Rect* ptr = &rect)
                return SetWindowMouseRect(window, ptr);
        }

        /// <inheritdoc cref="SetWindowMouseRect"/>
        public static bool SetWindowMouseRect(IntPtr window, IntPtr rectPtr)
        {
            unsafe { return SetWindowMouseRect(window, (Rect*)rectPtr); }
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowMouseRect")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetWindowMouseRect(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowOpacity")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowOpacity(IntPtr window, float opacity);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowOpacity")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetWindowOpacity(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowParent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowParent(IntPtr window, IntPtr parent);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowModal")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowModal(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool modal);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowFocusable")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowFocusable(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool focusable);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShowWindowSystemMenu")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ShowWindowSystemMenu(IntPtr window, int x, int y);

        #region Hit Testing

        /// <summary>Provide a callbkac that decides if a window region has special properties.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowHitTest")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowHitTest(IntPtr window, HitTestCallback callback, IntPtr callbackData);

        #endregion

        /// <summary>Set the shape of a transparent window.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowShape")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowShape(IntPtr window,IntPtr shape); // SDL_Surface*

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_FlashWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FlashWindow(IntPtr window, FlashOperation operation);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowProgressState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowProgressState(IntPtr window, ProgressState state);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowProgressState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial ProgressState GetWindowProgressState(IntPtr window);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowProgressValue")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowProgressValue(IntPtr window, float value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowProgressValue")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetWindowProgressValue(IntPtr window);

        /// <summary>
        /// Destroy a window.<br></br>
        /// Any child windows owned by the window will be recursively destroyed as well.
        /// </summary>
        /// <param name="window"></param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyWindow(IntPtr window);

        #endregion

        #region Screensaver 

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ScreenSaverEnabled")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ScreenSaverEnabled();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EnableScreenSaver")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool EnableScreenSaver();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DisableScreenSaver")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool DisableScreenSaver();

        #endregion

        #region OpenGL

        public static partial class GL
        {
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_LoadLibrary", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool LoadLibrary(string? path);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetProcAddress", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetProcAddress(string proc);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_UnloadLibrary")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void UnloadLibrary();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_ExtensionSupported", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool ExtensionSupported(string extension);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_ResetAttributes")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ResetAttributes();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetAttribute")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetAttribute(GLAttributes attr, int value);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetAttribute")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetAttribute(GLAttributes attr, out int value);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_CreateContext")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial GLContext CreateContext(IntPtr window);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_MakeCurrent")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool MakeCurrent(IntPtr window, GLContext context);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentWindow")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
            public static partial IntPtr GetCurrentWindow();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentContext")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
            public static partial GLContext GetCurrentContext();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetSwapInterval(int interval);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetSwapInterval(out int interval);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SwapWindow")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SwapWindow(IntPtr window);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_DestroyContext")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool DestroyContext(GLContext context);
        }

        public static partial class EGL
        {
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EGL_GetProcAddress", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetProcAddress(string proc);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EGL_GetCurrentDisplay")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetCurrentDisplay();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EGL_GetCurrentConfig")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetCurrentConfig();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EGL_GetWindowSurface")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetWindowSurface(IntPtr window);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EGL_GetWindowSurface")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr SetAttributeCallback(EGLAttribArrayCallback? platformAttribCallback, EGLIntArrayCallback? surfaceAttribCallback, EGLIntArrayCallback? contextAttribCallback);
        }

        #endregion
    }
}
