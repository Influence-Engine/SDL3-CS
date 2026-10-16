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
        [StructLayout(LayoutKind.Explicit)]
        public struct DrawOperation
        {
            [FieldOffset(0)]
            public DrawCommand cmd;

            [FieldOffset(0)]
            public FillOperation fill;

            [FieldOffset(0)]
            public CopyOperation copy;
        }

        /// <summary>Private data associated with a TTF_Text object.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TextData
        {
            /// <summary>The font used by this text, read-only.</summary>
            public IntPtr font;
            /// <summary>The color of the text, read-only.</summary>
            public SDL.FColor color;

            /// <summary>True if the layout needs to be updated.</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool needsLayoutUpdate;

            /// <summary>Cached layout information, read-only.</summary>
            public IntPtr layout;

            /// <summary>The x offset of the upper left corner of this text, in pixels, read-only.</summary>
            public int x;
            /// <summary>The y offset of the upper left corner of this text, in pixels, read-only.</summary>
            public int y;
            /// <summary>The width of this text, in pixels, read-only.</summary>
            public int w;
            /// <summary>The height of this text, in pixels, read-only.</summary>
            public int h;
            /// <summary>The number of drawing operations to render this text, read-only.</summary>
            public int numOps;
            /// <summary>The drawing operations used to render this text, read-only.</summary>
            public IntPtr ops;
            /// <summary>The numbers of substrings representing clusters of glyphs in the string, read-only.</summary>
            public int numClusters;
            /// <summary>Substrings representing clustures of glyphs in the string, read only.</summary>
            public IntPtr clusters;

            /// <summary>Custom properties associated with the text, read-only.</summary>
            public uint props;

            /// <summary>True if the engine text needs to be updated.</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool needsEngineUpdate;
            /// <summary>The engine used to render this text, read-only.</summary>
            public IntPtr engine;
            /// <summary>The implementation-specific representation of this text.</summary>
            public IntPtr engineText;
        }

        /// <summary>A text engine interface.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TextEngine
        {
            /// <summary>The version of this interface.</summary>
            public uint version;

            /// <summary>User data pointer passed to callbacks.</summary>
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
