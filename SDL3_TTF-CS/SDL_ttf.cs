using System;
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

        #region Properties

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

        public static class FontProps
        {
            public const string OutlineLineCap = "SDL_ttf.font.outline.line_cap";
            public const string OutlineLineJoin = "SDL_ttf.font.outline.line_join";
            public const string OutlineMiterLimit = "SDL_ttf.font.outline.miter_limit";
        }

        public static class RendererTextEngineProps
        {
            public const string RendererPointer = "SDL_ttf.renderer_text_engine.create.renderer";
            public const string AtlasTextureSize = "SDL_ttf.renderer_text_engine.create.atlas_texture_size";
        }

        public static class GPUTextEngineProps
        {
            public const string DevicePointer = "SDL_ttf.gpu_text_engine.create.device";
            public const string AtlasTextureSize = "SDL_ttf.gpu_text_engine.create.atlas_texture_size";
        }

        public static class GLTextEngienProps
        {
            public const string AtlasTextureSize = "SDL_ttf.gl_text_engine.create.atlas_texture_size";
        }

        #endregion

        [Flags]
        public enum FontStyleFlags : uint
        {
            Normal = 0x00,
            Bold = 0x01,
            Italic = 0x02,
            Underline = 0x04,
            Strikethrough = 0x08
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

        public enum Direction
        {
            Invalid = 0,
            LTR = 4,
            RTL,
            TTB,
            BTT
        }

        public enum ImageType
        {
            Invalid,
            Alpha,
            Color,
            SDF
        }

        public enum GPUTextEngineWinding
        {
            Invalid = -1,
            Clockwise,
            CounterClockwise
        }

        [Flags]
        public enum SubStringFlags : uint
        {
            DirectionMask = 0x000000FF,
            TextStart = 0x00000100,
            LineStart = 0x00000200,
            LineEnd = 0x00000400,
            TextEnd = 0x00000800,
        }

        public enum GLTextEngineWinding
        {
            Invalid = -1,
            Clockwise,
            CounterClockwise
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SubString
        {
            public SubStringFlags flags;
            public int offset;
            public int length;
            public int lineIndex;
            public int clusterIndex;
            public SDL.Rect rect;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Text
        {
            public IntPtr text; // char*
            public int numLines;
            public int refCount;

            public IntPtr _internal; // TTF_TextData*
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GPUAtlasDrawSequence
        {
            public IntPtr atlasTexture; // SDL_GPUTexture*
            public IntPtr xy; // SDL_FPoint*
            public IntPtr uv; // SDL_FPoint*

            public int numVertices;
            public IntPtr indices; // int*
            public int numIndices;

            public ImageType imageType;
            public IntPtr next; // TTF_GPUAtlasDrawSequence*
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GLAtlasDrawVertex
        {
            public SDL.FPoint position;
            public SDL.FPoint texcoord;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GLAtlasDrawSequence
        {
            public uint atlasTexture; // OpenGL texture name (GLuint)
            public IntPtr vertices; // TTF_GLAtlasDrawVertex*
            public int numVertices;
            public IntPtr indices; // UInt16*
            public int numIndices;
            public ImageType imageType;
            public IntPtr next; // TTF_GLAtlasDrawSequence*
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
        public static partial IntPtr OpenFont(string file, float ptSize);

        /// <summary>Create a font from an SDL_IOStream, using a specified point size.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_OpenFontIO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr OpenFont(IntPtr src, [MarshalAs(UnmanagedType.I1)] bool closeio, float ptSize);

        /// <summary>Create a font with the specified properties.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_OpenFontWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr OpenFontWithProperties(uint props);

        /// <summary>Create a copy of an existing font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CopyFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CopyFont(IntPtr existingFont);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetFontProperties(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontGeneration")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetFontGeneration(IntPtr font);

        /// <summary>Add a fallback font for glyphs not present in the primary font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_AddFallbackFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AddFallbackFont(IntPtr font, IntPtr fallback);

        /// <summary>Remove a fallback font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RemoveFallbackFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RemoveFallbackFont(IntPtr font, IntPtr fallback);

        /// <summary>Remove all fallback fonts.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_ClearFallbackFonts")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void ClearFallbackFonts(IntPtr font);

        /// <summary>Set a font's size dynamically.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontSize(IntPtr font, float ptSize);

        /// <summary>Set a font's size dynamically with target DPI.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontSizeDPI")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontSizeDPI(IntPtr font, float ptSize, int hdpi, int vdpi);

        /// <summary>Get the size of a font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontSize")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetFontSize(IntPtr font);

        /// <summary>Get font target DPI.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontDPI")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetFontDPI(IntPtr font, out int hdpi, out int vdpi);

        /// <summary>Set a font's current style.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontStyle")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetFontStyle(IntPtr font, FontStyleFlags style);

        /// <summary>Query a font's current style.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontStyle")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial FontStyleFlags GetFontStyle(IntPtr font);

        /// <summary>Set a font's current outline.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontOutline")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontOutline(IntPtr font, int outline);

        /// <summary>Query a font's current outline.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontOutline")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontOutline(IntPtr font);

        /// <summary>Set a font's current hinter setting.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontHinting")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetFontHinting(IntPtr font, HintingFlags hinting);

        /// <summary>Query the number of faces of a font.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetNumFontFaces")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetNumFontFaces(IntPtr font);

        /// <summary>Query a font's current FreeType hinter setting.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontHinting")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial HintingFlags GetFontHinting(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontSDF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontSDF(IntPtr font, [MarshalAs(UnmanagedType.I1)] bool enabled);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontSDF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetFontSDF(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontWeight")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontWeight(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontWrapAlignment")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetFontWrapAlignment(IntPtr font, HorizontalAlignment align);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontWrapAlignment")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial HorizontalAlignment GetFontWrapAlignment(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontHeight")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontHeight(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontAscent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontAscent(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontDescent")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontDescent(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontLineSkip")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontLineSkip(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontKerning")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int SetFontKerning(IntPtr font, [MarshalAs(UnmanagedType.I1)] bool enabled);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontKerning")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetFontKerning(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_FontIsFixedWidth")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FontIsFixedWidth(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_FontIsScalable")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FontIsScalable(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontFamilyName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial IntPtr GetFontFamilyNamePTR(IntPtr font);

        public static string? GetFontFamilyName(IntPtr font)
        {
            IntPtr ptr = GetFontFamilyNamePTR(font);
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontStyleName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial IntPtr GetFontStyleNamePTR(IntPtr font);

        public static string? GetFontStyleName(IntPtr font)
        {
            IntPtr ptr = GetFontStyleNamePTR(font);
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontDirection")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontDirection(IntPtr font, Direction direction);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontDirection")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial Direction GetFontDirection(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontCharSpacing")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontCharSpacing(IntPtr font, int spacing);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontCharSpacing")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetFontCharSpacing(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_StringToTag", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint StringToTag(string str);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_TagToString")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void TagToString(uint tag, IntPtr str, UIntPtr size);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontScript")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontScript(IntPtr font, uint script);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetFontScript")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetFontScript(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGlyphScript")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetGlyphScript(uint ch);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetFontLanguage", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFontLanguage(IntPtr font, string language);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_FontHasGlyph")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool FontHasGlyph(IntPtr font, uint ch);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGlyphImage")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetGlyphImage(IntPtr font, uint ch, out ImageType imageType);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGlyphImageForIndex")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetGlyphImageForIndex(IntPtr font, uint glyphIndex, out ImageType imageType);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGlyphMetrics")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetGlyphMetrics(IntPtr font, uint ch, out int minX, out int maxX, out int minY, out int maxY, out int advance);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGlyphKerning")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetGlyphKerning(IntPtr font, uint previousCh, uint ch, out int kerning);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetStringSizeWrapped", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetStringSizeWrapped(IntPtr font, string text, UIntPtr length, int wrapWidth, out int w, out int h);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_MeasureString", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool MeasureString(IntPtr font, string text, UIntPtr length, int maxWidth, out int measuredWidth, out UIntPtr measuredLength);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Solid", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextSolid(IntPtr font, string text, UIntPtr length, SDL.Color foreground);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Solid_Wrapped", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextSolidWrapped(IntPtr font, string text, UIntPtr length, SDL.Color foreground, int wrapLength);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderGlyph_Solid")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderGlyphSolid(IntPtr font, uint ch, SDL.Color foreground);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Shaded", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextShaded(IntPtr font, string text, UIntPtr length, SDL.Color foreground, SDL.Color background);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Shaded", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextShadedWrapped(IntPtr font, string text, UIntPtr length, SDL.Color foreground, SDL.Color background, int wrapWidth);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderGlyph_Shaded")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderGlyphShaded(IntPtr font, uint ch, SDL.Color foreground, SDL.Color background);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Blended", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextBlended(IntPtr font, string text, UIntPtr length, SDL.Color foreground);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_Blended_Wrapped", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextBlendedWrapped(IntPtr font, string text, UIntPtr length, SDL.Color foreground, int wrapWidth);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderGlyph_Blended", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderGlyphBlended(IntPtr font, uint ch, SDL.Color foreground);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_LCD", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextLCD(IntPtr font, string text, UIntPtr length, SDL.Color foreground, SDL.Color background);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderText_LCD_Wrapped", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderTextLCDWrapped(IntPtr font, string text, UIntPtr length, SDL.Color foreground, SDL.Color background, int wrapWidth);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_RenderGlyph_LCD", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr RenderGlyphLCD(IntPtr font, uint ch, SDL.Color foreground, SDL.Color background);

        #region Text Engine Functions

        #region Surface

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateSurfaceTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateSurfaceTextEngine();

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DrawSurfaceText")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool DrawSurfaceText(IntPtr text, int x, int y, IntPtr surface);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DestroySurfaceTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroySurfaceTextEngine(IntPtr engine);

        #endregion

        #region Renderer

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateRendererTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateRendererTextEngine(IntPtr renderer);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateRendererTextEngineWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateRendererTextEngineWithProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DrawRendererText")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool DrawRendererText(IntPtr text, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DestroyRendererTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyRendererTextEngine(IntPtr engine);

        #endregion

        #region GPU

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGPUTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateGPUTextEngine(IntPtr device);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGPUTextEngineWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateGPUTextEngineWithProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGPUTextDrawData")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetGPUTextDrawData(IntPtr text); // returns TTF_GPUAtlasDrawSequence*

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DestroyGPUTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyGPUTextEngine(IntPtr engine);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetGPUTextEngineWinding")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetGPUTextEngineWinding(IntPtr engine, GPUTextEngineWinding winding);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetGPUTextEngineWinding")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial GPUTextEngineWinding GetGPUTextEngineWinding(IntPtr engine);

        #endregion

        #region OpenGL

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGLTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateGLTextEngine();

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGLTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateGLTextEngineWithProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGLTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetGLTextDrawData(IntPtr text); // returns TTF_GLAtlasDrawSequence*

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DestroyGLTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyGLTextEngine(IntPtr engine);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateGLTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr SetGLTextEngineWinding(IntPtr engine, GLTextEngineWinding winding);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetGLTextEngineWinding")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial GLTextEngineWinding GetGLTextEngineWinding(IntPtr engine);

        #endregion

        #endregion

        #region Text Object Functions

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CreateText", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr CreateText(IntPtr engine, IntPtr font, string text, UIntPtr length);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetTextProperties(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextEngine(IntPtr text, IntPtr engine);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextEngine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial IntPtr GetTextEngine(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextFont(IntPtr text, IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial IntPtr GetTextFont(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextDirection")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextDirection(IntPtr text, Direction direction);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextDirection")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial Direction GetTextDirection(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextScript")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextScript(IntPtr text, uint script);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextScript")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetTextScript(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextColor(IntPtr text, byte r, byte g, byte b, byte a);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextColorFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextColorFloat(IntPtr text, float r, float g, float b, float a);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextColor")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextColor(IntPtr text, out byte r, out byte g, out byte b, out byte a);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextColorFloat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextColorFloat(IntPtr text, out float r, out float g, out float b, out float a);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextPosition(IntPtr text, int x, int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextPosition(IntPtr text, out int x, out int y);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextWrapWidth")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextWrapWidth(IntPtr text, int wrapWidth);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextWrapWidth")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextWrapWidth(IntPtr text, out int wrapWidth);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextWrapWhitespaceVisible")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextWrapWhitespaceVisible(IntPtr text, [MarshalAs(UnmanagedType.I1)] bool visible);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_TextWrapWhitespaceVisible")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool TextWrapWhitespaceVisible(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_SetTextString", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextString(IntPtr text, string str, UIntPtr length);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_InsertTextString", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool InsertTextString(IntPtr text, int offset, string str, UIntPtr length);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_AppendTextString", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AppendTextString(IntPtr text, string str, UIntPtr length);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DeleteTextString", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool DeleteTextString(IntPtr text, int offset, int length);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextSize", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextSize(IntPtr text, out int w, out int h);

        #endregion

        #region Substring Functions

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextSubString")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextSubString(IntPtr text, int offset, out SubString substring);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextSubStringForLine")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextSubStringForLine(IntPtr text, int line, out SubString substring);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextSubStringsForRange")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetTextSubStringsForRangePtr(IntPtr text, int offset, int length, out int count); // returns TTF_SubString**

        public static SubString[] GetTextSubStringForRange(IntPtr text, int offset, int length)
        {
            IntPtr ptr = GetTextSubStringsForRangePtr(text, offset, length, out int count);
            if (ptr == IntPtr.Zero || count == 0)
                return[];

            SubString[] result = new SubString[count];
            for(int i = 0; i < count; i++)
            {
                IntPtr elementPtr = Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
                result[i] = Marshal.PtrToStructure<SubString>(elementPtr);
            }

            SDL.Free(ptr);
            return result;
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetTextSubStringForPoint")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextSubStringForPoint(IntPtr text, int x, int y, out SubString substring);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetPreviousTextSubString")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetPreviousTextSubString(IntPtr text, ref SubString substring, out SubString previous);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_GetNextTextSubString")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetNextTextSubstring(IntPtr text, ref SubString substring, out SubString next);

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_UpdateText")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool UpdateText(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_DestroyText")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyText(IntPtr text);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_CloseFont")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void CloseFont(IntPtr font);

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_Quit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        [LibraryImport(nativeLibraryName, EntryPoint = "TTF_WasInit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int WasInit();
    }
}
