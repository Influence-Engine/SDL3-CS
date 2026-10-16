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

        /// <summary>A filled rectangle draw operation.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FillOperation
        {
            /// <summary>TTF DrawCommand Fill.</summary>
            public DrawCommand cmd;
            /// <summary>The rectangle to fill, in pixels.</summary>
            public SDL.Rect rect;
        }

        /// <summary>A texture copy draw operation.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CopyOperation
        {
            /// <summary>TTF DrawCommand Copy.</summary>
            public DrawCommand cmd;
            /// <summary>The offset in text corresponding to this glyph.</summary>
            public int textOffset;
            /// <summary>The font containing the glyph to be draw, can be passed to <see cref="GetGlyphImageForIndex"/>.</summary>
            public IntPtr glyphFont;
            /// <summary>The glyph index of the glyph to be drawn, can be passed to <see cref="GetGlyphImageForIndex"/>.</summary>
            public uint glyphIndex;
            /// <summary>The area within the glyph to be drawn.</summary>
            public SDL.Rect src;
            /// <summary>The drawing coordinates of the glyph, in pixels.</summary>
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

        /// <summary>Private data associated with a TTF_Text object.</summary>
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

        /// <summary>A text engine interface.</summary>
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
