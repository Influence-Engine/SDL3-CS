using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class TTF
    {

        #region Enums

        /// <summary>A font atlas draw command.</summary>
        public enum DrawCommand
        {
            NoOp,
            Fill,
            Copy
        }

        #endregion

        #region Structs

        /// <summary>A filled rectangle draw operation</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FillOperation
        {
            public DrawCommand cmd;
            public SDL.Rect rect;
        }

        /// <summary>A texture copy draw operation.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CopyOperation
        {
            public DrawCommand cmd;
            public int textOffset;
            public IntPtr glyphFont;
            public uint glyphIndex;
            public SDL.Rect src;
            public SDL.Rect dst;

            public IntPtr reserved;
        }

        /// <summary>A text engine draw operation.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DrawOperation
        {
            public DrawCommand cmd;
            public FillOperation fill;
            public CopyOperation copy;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TextData
        {
            public IntPtr font;
            public SDL.FColor color;

            [MarshalAs(UnmanagedType.I1)]
            public bool needsLayoutUpdate;
            public IntPtr layout;
            public int x;
            public int y;
            public int w;
            public int h;
            public int numOps;
            public IntPtr ops;
            public int numClusters;
            public IntPtr clusters;

            public uint props;

            [MarshalAs(UnmanagedType.I1)]
            public bool needsEngineUpdate;
            public IntPtr engine;
            public IntPtr engineText;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TextEngine
        {
            public uint version;

            public IntPtr userdata;

            /// <summary><see cref="CreateTextDelegate"/>.</summary>
            public IntPtr createText; // CreateTextDelegate

            /// <summary><see cref="DestroyTextDelegate"/>.</summary>
            public IntPtr destroyText; // DestroyTextDelegate
        }

        #endregion

        #region Callbacks

        /// <summary>Create a text representation from draw instructions.</summary>
        /// <returns>True on success, false on failure.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public delegate bool CreateTextDelegate(IntPtr userdata, IntPtr text);

        /// <summary>Destroy a text representation.</summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DestroyTextDelegate(IntPtr userdata, IntPtr text);

        #endregion
    }
}
