using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    // TODO fix this entire class
    public static partial class SDL
    {
        /// <summary>Pixel Type</summary>
        public enum PixelType
        {
            Unknown,
            Index1,
            Index4,
            Index8,
            Packed8,
            Packed16,
            Packed32,
            ArrayU8,
            ArrayU16,
            ArrayU32,
            ArrayF16,
            ArrayF32,

            Index2
        }

        /// <summary>Bitmap pixel order, high bit -> low bit.</summary>
        public enum BitmapOrder
        {
            OrderNone,
            Order4321,
            Order1234,
        }

        /// <summary>Packed component order, high bit -> low bit.</summary>
        public enum PackedOrder
        {
            OrderNone,
            OrderXRGB,
            OrderRGBX,
            OrderARGB,
            OrderRGBA,
            OrderXBGR,
            OrderBGRX,
            OrderABGR,
            OrderBGRA
        }

        /// <summary>Array component order, low byte -> high byte.</summary>
        public enum ArrayOrder
        {
            OrderNone,
            OrderRGB,
            OrderRGBA,
            OrderARGB,
            OrderBGR,
            OrderBGRA,
            OrderABGR
        }

        /// <summary>Packed component layout.</summary>
        public enum PackedLayout
        {
            LayoutNone,
            Layout332,
            Layout4444,
            Layout1555,
            Layout5551,
            Layout565,
            Layout8888,
            Layout2101010,
            Layout1010102
        }

        /// <summary>Pixel Format</summary>
        public enum PixelFormat : uint
        {
            Unknown = 0,

            Index1LSB = 0x11100100u,
            Index1MSB = 0x11200100u,
            Index2LSB = 0x1c100200u,
            Index2MSB = 0x1c200200u,
            Index4LSB = 0x12100400u,
            Index4MSB = 0x12200400u,
            Index8 = 0x13000801u,

            RGB332 = 0x14110801u,
            XRGB4444 = 0x15120c02u,
            XBGR4444 = 0x15520c02u,
            XRGB1555 = 0x15130f02u,
            XBGR1555 = 0x15530f02u,
            ARGB4444 = 0x15321002u,
            RGBA4444 = 0x15421002u,
            ABGR4444 = 0x15721002u,
            BGRA4444 = 0x15821002u,
            ARGB1555 = 0x15331002u,
            RGBA5551 = 0x15441002u,
            ABGR1555 = 0x15731002u,
            BGRA5551 = 0x15841002u,
            RGB565 = 0x15151002u,
            BGR565 = 0x15551002u,
            RGB24 = 0x17101803u,
            BGR24 = 0x17401803u,
            XRGB8888 = 0x16161804u,
            RGBX8888 = 0x16261804u,
            XBGR8888 = 0x16561804u,
            BGRX8888 = 0x16661804u,
            ARGB8888 = 0x16362004u,
            RGBA8888 = 0x16462004u,
            ABGR8888 = 0x16762004u,
            BGRA8888 = 0x16862004u,
            XRGB2101010 = 0x16172004u,
            XBGR2101010 = 0x16572004u,
            ARGB2101010 = 0x16372004u,
            ABGR2101010 = 0x16772004u,
            RGB48 = 0x18103006u,
            BGR48 = 0x18403006u,
            RGBA64 = 0x18204008u,
            ARGB64 = 0x18304008u,
            BGRA64 = 0x18504008u,
            ABGR64 = 0x18604008u,
            RGB48Float = 0x1a103006u,
            BGR48Float = 0x1a403006u,
            RGBA64Float = 0x1a204008u,
            ARGB64Float = 0x1a304008u,
            BGRA64Float = 0x1a504008u,
            ABGR64Float = 0x1a604008u,
            RGB96Float = 0x1b10600cu,
            BGR96Float = 0x1b40600cu,
            RGBA128Float= 0x1b208010u,
            ARGB128Float = 0x1b308010u,
            BGRA128Float = 0x1b508010u,
            ABGR128Float = 0x1b608010u,

            YV12 = 0x32315659u,
            IYUV = 0x56555949u,
            YUY2 = 0x32595559u,
            UYVY = 0x59565955u,
            YVYU = 0x55595659u,
            NV12 = 0x3231564eu,
            NV21 = 0x3132564eu,
            P010 = 0x30313050u,

            ExternalOES= 0x2053454fu
        }

        /// <summary>Colorspace Color Type</summary>
        public enum ColorType
        {
            Unknown = 0,
            RGB = 1,
            YCBCR = 2
        }

        /// <summary>Colorspace Color Range</summary>
        public enum ColorRange
        {
            Unknown = 0,
            Limited = 1,
            Full = 2
        }

        /// <summary>Colorspace Color Primaries</summary>
        public enum ColorPrimaries
        {
            Unknown = 0,
            BT709 = 1,
            Unspecified = 2,
            BT470M = 4,
            BT470BG = 5,
            BT601 = 6,
            SMPTE240 = 7,
            GenericFilm = 8,
            BT2020 = 9,
            XYZ = 10, 
            SMPTE431 = 11,
            SMPTE432 = 12,
            EBU3213 = 22,
            Custom = 31
        }

        // TODO SDL_TransferCharacteristics
        // TODO SDL_MatrixCoefficients
        // TODO SDL_ChromeLocation

        // TODO SDL_Colorspace

        [StructLayout(LayoutKind.Sequential)]
        public struct Color
        {
            public byte r;
            public byte g; 
            public byte b;
            public byte a;

            public Color(byte r, byte g, byte b, byte a = 255)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            public static readonly Color White = new Color(255, 255, 255, 255);
            public static readonly Color Black = new Color(0, 0, 0, 255);
            public static readonly Color Clear = new Color(0, 0, 0, 0);

            public static readonly Color Red = new Color(255, 0, 0, 255);
            public static readonly Color Green = new Color(0, 255, 0, 255);
            public static readonly Color Blue = new Color(0, 0, 255, 255);
            public static readonly Color Yellow = new Color(255, 255, 0, 255);
            public static readonly Color Magenta = new Color(255, 0, 255, 255);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FColor
        {
            public float r;
            public float g;
            public float b;
            public float a;

            public FColor(float r, float g, float b, float a = 1f)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            public static readonly FColor White = new FColor(1f, 1f, 1f, 1f);
            public static readonly FColor Black = new FColor(0f, 0f, 0f, 1f);
            public static readonly FColor Clear = new FColor(0f, 0f, 0f, 0f);

            public static readonly FColor Red = new FColor(1f, 0f, 0f, 1f);
            public static readonly FColor Green = new FColor(0f, 1f, 0f, 1f);
            public static readonly FColor Blue = new FColor(0f, 0f, 1f, 1f);
            public static readonly FColor Yellow = new FColor(1f, 1f, 0f, 1f);
            public static readonly FColor Magenta = new FColor(1f, 0f, 1f, 1f);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Palette
        {
            public int ncolors;
            IntPtr colors;
            public uint version;
            public int refcount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct PixelFormatDetails
        {
            public uint format;
            public byte bitPerPixel;
            public byte bytesPerPixel;
            public fixed byte padding[2];
            public uint Rmask;
            public uint Gmask;
            public uint Bmask;
            public uint Amask;
            public byte Rbits;
            public byte Gbits;
            public byte Bbits;
            public byte Abits;
            public byte Rshift;
            public byte Gshift;
            public byte Bshift;
            public byte Ashift;
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetPixelFormatName(uint format);
        public static string GetPixelFormatName(uint format) => Marshal.PtrToStringUTF8(Internal_GetPixelFormatName(format));

        // TODO SDL_GetPixelFormatMasks
        // TODO SDL_GetPixelFormatDetails

        // TODO SDL_CreatePalette
        // TODO SDL_SetPaletteColors
        // TODO SDL_DestroyPalette

        // TODO SDL_MapRGB
        // TODO SDL_MapRGBA
        // TODO SDL_GetRGB
        // TODO SDL_GetRGBA
    }
}
