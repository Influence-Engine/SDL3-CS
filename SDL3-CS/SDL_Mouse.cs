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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMouseButtonPressed(uint state, MouseButton button) => (state & (1u << ((int)button - 1))) != 0;
    }
}
