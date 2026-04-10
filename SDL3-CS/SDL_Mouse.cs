using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        #region Enums

        /// <summary>Cursor types for system cursors.</summary>
        public enum SystemCursor
        {
            Default,
            Text,
            Wait,
            Crosshair,
            Progress,
            NWSE_Resize,
            NESW_Resize,
            EW_Resize,
            NS_Resize,
            Move,
            NotAllowed,
            Pointer,
            NW_Resize,
            N_Resize,
            NE_Resize,
            E_Resize,
            SE_Resize,
            S_Resize,
            SW_Resize,
            W_Resize,

            Count = 20
        }

        /// <summary>Scroll direction types for the Scroll event.</summary>
        public enum MouseWheelDirection
        {
            Normal,
            Flipped
        }

        /// <summary>Mouse button IDs. </summary>
        public enum MouseButton
        {
            Left = 1,
            Middle = 2,
            Right = 3,
            X1 = 4,
            X2 = 5
        }

        #endregion

        #region Structs

        /// <summary>Animated cursor frame info.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CursorFrameInfo
        {
            public nint surface;
            public uint duration;
        }

        #endregion

        #region Constants

        public const uint ButtonLeftMask = 1u << ((int)MouseButton.Left - 1);
        public const uint ButtonMiddleMask = 1u << ((int)MouseButton.Middle - 1);
        public const uint ButtonRightMask = 1u << ((int)MouseButton.Right - 1);
        public const uint ButtonX1Mask = 1u << ((int)MouseButton.X1 - 1);
        public const uint ButtonX2Mask = 1u << ((int)MouseButton.X2 - 1);

        #endregion

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MouseMotionTransformCallback(nint userdata, ulong timestamp, nint window, uint mouseID, ref float x, ref float y);

        #endregion
        
        /// <summary>Returns whether a mouse is currently connected.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HasMouse")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HasMouse();

        /// <summary>Get a kist of currently connected mice.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetMice")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetMice(out int count);

        /// <summary>Get a kist of currently connected mice as a span.</summary>
        public static unsafe Span<uint> GetMice()
        {
            nint ptr = GetMice(out int count);
            if (ptr == nint.Zero || count == 0)
                return Span<uint>.Empty;

            return new Span<uint>(ptr.ToPointer(), count);
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetMouseNameForID", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial string? GetMouseNameForID(uint instanceID);

        /// <summary>Get the window which currently has mouse focus.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetMouseFocus")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetMouseFocus();

        #region Mouse State

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetMouseState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetMouseState(out float x, out float y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseState(out FPoint position)
        {
            uint state = GetMouseState(out float x, out float y);
            position = new FPoint(x, y);

            return state;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseState() => GetMouseState(out float _, out float _);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGlobalMouseState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetGlobalMouseState(out float x, out float y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseState(out FPoint position)
        {
            uint state = GetGlobalMouseState(out float x, out float y);
            position = new FPoint(x, y);

            return state;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseState() => GetGlobalMouseState(out float _, out float _);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetRelativeMouseState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetRelativeMouseState(out float x, out float y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetRelativeMouseState(out FPoint position)
        {
            uint state = GetRelativeMouseState(out float x, out float y);
            position = new FPoint(x, y);

            return state;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetRelativeMouseState() => GetRelativeMouseState(out float _, out float _);

        #endregion

        #region Mouse Movement

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WarpMouseInWindow")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial void WarpMouseInWindow(nint window, float x, float y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WarpMouseInWindow(nint window, FPoint position) => WarpMouseInWindow(window, position.x, position.y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WarpMouseGlobal")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool WarpMouseGlobal(float x, float y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WarpMouseGlobal(FPoint position) => WarpMouseGlobal(position.x, position.y);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetRelativeMouseTransform")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetRelativeMouseTransform(MouseMotionTransformCallback? callback, nint userdata);

        #endregion

        #region Relative Mouse Mode

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetWindowRelativeMouseMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetWindowRelativeMouseMode(nint window, [MarshalAs(UnmanagedType.I1)] bool enabled);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetWindowRelativeMouseMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetWindowRelativeMouseMode(nint window);

        #endregion

        #region Mouse Capture

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CaptureMouse")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool CaptureMouse([MarshalAs(UnmanagedType.I1)] bool enabled);

        #endregion

        #region Cursor Creation

        /// <summary>Create a cursor using bitmap data and mask (in MSB format).</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CreateCursor(byte* data, byte* mask, int w, int h, int hotX, int hotY);

        /// <summary>Create a color cursor from a surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateColorCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateColorCursor(nint surface, int hotX, int hotY);

        /// <summary>Create an animated color cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateAnimatedCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CreateAnimatedCursor(CursorFrameInfo* frames, int frameCount, int hotX, int hotY);

        /// <summary>Create an animated color cursor from a span.</summary>
        public static unsafe nint CreateAnimatedCursor(ReadOnlySpan<CursorFrameInfo> frames, int hotX, int hotY)
        {
            fixed (CursorFrameInfo* ptr = frames)
            {
                return CreateAnimatedCursor(ptr, frames.Length, hotX, hotY);
            }
        }

        /// <summary>Create a system cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateSystemCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint CreateSystemCursor(SystemCursor id);

        #endregion

        #region Cursor Management

        /// <summary>Set the active cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetCursor(nint cursor);

        /// <summary>Get the active cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetCursor();

        /// <summary>Set the default cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetDefaultCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetDefaultCursor();

        /// <summary>Free a previously-created cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial void DestroyCursor(nint cursor);

        #endregion

        #region Cursor Visibilty

        /// <summary>Show the cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShowCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ShowCursor();

        /// <summary>Hide the cursor.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HideCursor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HideCursor();

        /// <summary>Return whether the cursor is currently being shown.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CursorVisible")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool CursorVisible();

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMouseButtonPressed(uint state, MouseButton button) => (state & (1u << ((int)button - 1))) != 0;
    }
}
