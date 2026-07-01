using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class TTF
    {
        const string nativeLibraryName = "SDL3_ttf";

        public const int MajorVersion = 3;
        public const int MinorVersion = 3;
        public const int MicroVersion = 0;

        public static class FontCreateProps
        {
            public const string FilenameString = "SDL_ttf.font.create.filename";
            public const string IOStreamPointer = "SDL_ttf.font.create.iostream";
            public const string IOStreamOffsetNumber = "SDL_ttf.font.create.iostream.offset";
            public const string IOStreamAutocloseBoolean = "SDL_ttf.font.create.iostream.autoclose";
            public const string SizeFloat = "SDL_ttf.font.create.size";
            public const string FaceNumber = "SDL_ttf.font.create.face";
            public const string HoriontalDPINumber = "SDL_ttf.font.create.hdpi";
            public const string VerticalDPINumber = "SDL_ttf.font.create.vdpi";
            public const string ExistingFontPointer = "SDL_ttf.font.create.existing_font";
        }

        public enum HintingFlags
        {
            Invalid = -1,
            Normal,
            Light,
            Mono,
            None, 
            LightSubpixel
        }

        public enum FontWeight
        {
            Thin = 100,
            ExtraLight = 200,
            Light = 300,
            Normal = 400,
            Medium = 500,
            SemiBold = 600,
            Bold = 700,
            ExtraBold = 800,
            Black = 900,
            ExtraBlack = 950
        }

        public enum HorizontalAlignment
        {
            Invalid = -1,
            Left,
            Center,
            Right
        }

        /// <summary>Gets the version of the dynamically linked SDL_ttf library.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_Version")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int Version();

        /// <summary>Query the version of the FreeType library in use.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFreeTypeVersion")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetFreeTypeVersion(out int major, out int minor, out int patch);

        /// <summary>Query the version of the HarfBuzz library in use.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetHarfBuzzVersion")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void GetHarfBuzzVersion(out int major, out int minor, out int patch);

        /// <summary>Initialize SDL_ttf.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_Init")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init();

        /// <summary>Create a font from a file, using a specified point size.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_OpenFont", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint OpenFont(string file, float ptSize);

        /// <summary>Create a font from an SDL_IOStream, using a specified point size.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_OpenFontIO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint OpenFont(nint src, [MarshalAs(UnmanagedType.I1)] bool closeio, float ptSize);

        /// <summary>Create a font with the specified properties.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_OpenFontWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint OpenFontWithProperties(uint props);

        /// <summary>Create a copy of an existing font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CopyFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CopyFont(nint existingFont);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetFontProperties(nint font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontGeneration")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetFontGeneration(nint font);

        /// <summary>Add a fallback font for glyphs not present in the primary font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_AddFallbackFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AddFallbackFont(nint font, nint fallback);

        /// <summary>Remove a fallback font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RemoveFallbackFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RemoveFallbackFont(nint font, nint fallback);

        /// <summary>Remove all fallback fonts.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_ClearFallbackFonts")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void ClearFallbackFonts(nint font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_Quit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_WasInit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int WasInit();
    }
}
