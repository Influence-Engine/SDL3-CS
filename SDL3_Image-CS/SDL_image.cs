using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class IMG
    {
#if DEBUG
        private const string nativeLibraryName = "SDL3_image-Debug.dll";
#else
        private const string nativeLibraryName = "SDL3_image.dll";
#endif

        public const int MajorVersion = 3;
        public const int MinorVersion = 5;
        public const int MicroVersion = 0;

        #region Struct / Enums

        [StructLayout(LayoutKind.Sequential)]
        public struct Animation
        {
            public int w;
            public int h;
            public int count;
            public nint frames;
            public nint delays;
        }

        public enum AnimationDecoderStatus
        {
            /// <summary>The decoder is invalid.</summary>
            Invalid = -1,
            /// <summary>The decoder is ready to decode the next frame.</summary>
            Ok,
            /// <summary>The decoder failed to decode a frame.</summary>
            Failed,
            /// <summary>No more frames are available.</summary>
            Complete
        }

        #endregion

        public static class AnimationDecoderProps
        {
            public const string CreateFilename = "SDL_image.animation_decoder.create.filename";
            public const string CreateIOStream = "SDL_image.animation_decoder.create.iostream";
            public const string CreateIOStreamAutoclose = "SDL_image.animation_decoder.create.iostream.autoclose";
            public const string CreateType = "SDL_image.animation_decoder.create.type";
            public const string CreateTimebaseNumerator = "SDL_image.animation_decoder.create.timebase.numerator";
            public const string CreateTimebaseDenominator = "SDL_image.animation_decoder.create.timebase.denominator";
            public const string CreateAvifMaxThreads = "SDL_image.animation_decoder.create.avif.max_threads";
            public const string CreateAvifAllowIncremental = "SDL_image.animation_decoder.create.avif.allow_incremental";
            public const string CreateAvifAllowProgressive = "SDL_image.animation_decoder.create.avif.allow_progressive";
            public const string CreateGifTransparentColorIndex = "SDL_image.animation_encoder.create.gif.transparent_color_index";
            public const string CreateGifNumColors = "SDL_image.animation_encoder.create.gif.num_colors";
        }

        public static class AnimationEncoderProps
        {
            public const string CreateFilename = "SDL_image.animation_encoder.create.filename";
            public const string CreateIOStream = "SDL_image.animation_encoder.create.iostream";
            public const string CreateIOStreamAutoclose = "SDL_image.animation_encoder.create.iostream.autoclose";
            public const string CreateType = "SDL_image.animation_encoder.create.type";
            public const string CreateQuality = "SDL_image.animation_encoder.create.quality";
            public const string CreateTimebaseNumerator = "SDL_image.animation_encoder.create.timebase.numerator";
            public const string CreateTimebaseDenominator = "SDL_image.animation_encoder.create.timebase.denominator";
            public const string CreateAvifMaxThreads = "SDL_image.animation_encoder.create.avif.max_threads";
            public const string CreateAvifKeyframeInterval = "SDL_image.animation_encoder.create.avif.keyframe_interval";
            public const string CreateGifUseLut = "SDL_image.animation_encoder.create.gif.use_lut";
        }

        public static class MetadataProps
        {
            public const string IgnoreProps = "SDL_image.metadata.ignore_props";
            public const string Description = "SDL_image.metadata.description";
            public const string Copyright = "SDL_image.metadata.copyright";
            public const string Title = "SDL_image.metadata.title";
            public const string Author = "SDL_image.metadata.author";
            public const string CreationTime = "SDL_image.metadata.creation_time";
            public const string FrameCount = "SDL_image.metadata.frame_count";
            public const string LoopCount = "SDL_image.metadata.loop_count";
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_Version")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int Version();

        #region Load Surface

        /// <summary>Load an image from a filesystem path into a software surface.</summary>
        /// <param name="file">Path on the filesystem to load an image from.</param>
        /// <returns>A new SDL_Surface, or NULL on error.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_Load", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint Load(string file);

        /// <summary>Load an image from a SDL_IOStream into a software surface.</summary>
        /// <param name="src">An SDL_IOStream to read from.</param>
        /// <param name="closeio">True to close the stream before returning.</param>
        /// <returns>A new SDL_Surface, or NULL on error.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_Load_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint Load(nint src, [MarshalAs(UnmanagedType.I1)] bool closeio);

        /// <summary>Load an image from a SDL_IOStream, with explicit type hint.</summary>
        /// <param name="src">An SDL_IOStream to read from.</param>
        /// <param name="closeio">True to close the stream before returning.</param>
        /// <param name="type">File extension hint, e.g. "PNG", "JPG". Null to auto-detect.</param>
        /// <returns>A new SDL_Surface, or NULL on error.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTyped_IO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTyped(nint src, [MarshalAs(UnmanagedType.I1)] bool closeio, string? type);

        #endregion

        #region Load Texture

        /// <summary>Load an image from a filesystem path into a SDL_Texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTexture", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTexture(nint renderer, string file);

        /// <summary>Load an image from a SDL_IOStream into a SDL_Texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTexture_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTexture(nint renderer, nint src, [MarshalAs(UnmanagedType.I1)] bool closeio);

        /// <summary>Load an image from a SDL_IOStream into a SDL_Texture, with explicit type hint.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTextureTyped_IO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTextureTyped(nint renderer, nint src, [MarshalAs(UnmanagedType.I1)] bool closeio, string? type);

        #endregion

        #region Load GPUTexture

        /// <summary>Load an image from a filesystem path into a GPU texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadGPUTexture", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadGPUTexture(nint device, nint copyPass, string file, out int width, out int height);

        /// <summary>Load an image from a SDL_IOStream into a GPU texture.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadGPUTexture_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadGPUTexture(nint device, nint copyPass, nint src, [MarshalAs(UnmanagedType.I1)] bool closeio, out int width, out int height);

        /// <summary>Load an image from a SDL_IOStream into a GPU texture, with explicit type hint.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadGPUTextureTyped_IO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadGPUTextureTyped(nint device, nint copyPass, nint src, [MarshalAs(UnmanagedType.I1)] bool closeio, string? type, out int width, out int height);

        #endregion

        /// <summary>Get the image currently in the clipboard as a SDL_Surface.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_GetClipboardImage")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetClipboardImage();

        #region Format Detection

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isANI")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsANI(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isAVIF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsAVIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isBMP")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsBMP(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isCUR")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsCUR(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isGIF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsGIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isICO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsICO(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isJPG")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsJPG(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isJXL")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsJXL(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isLBM")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsLBM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isPCX")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsPCX(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isPNG")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsPNG(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isPNM")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsPNM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isQOI")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsQOI(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isSVG")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsSVG(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isTIF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsTIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isWEBP")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsWEBP(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isXCF")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsXCF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isXPM")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsXPM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_isXV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsXV(nint src);

        #endregion

        #region Load specific format (IOStream)

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadAVIF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadAVIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadBMP_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadBMP(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadCUR_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadCUR(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadGIF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadGIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadICO_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadICO(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadJPG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadJPG(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadJXL_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadJXL(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadLBM_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadLBM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadPCX_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadPCX(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadPNG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadPNG(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadPNM_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadPNM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadQOI_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadQOI(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadSVG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadSVG(nint src);

        /// <summary>
        /// Load an SVG image scaled to a specific size. <br></br>
        /// Either dimension may be 0 to auto-size preserving aspect ration. 
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadSizedSVG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadSizedSVG(nint src, int width, int height);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTGA_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTGA(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadTIF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadTIF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadWEBP_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadWEBP(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadXCF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadXCF(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadXPM_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadXPM(nint src);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_LoadXV_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadXV(nint src);

        #endregion

        #region XPM from Memory Array

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_ReadXPMFromArray")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint ReadXPMFromArray(byte** xpm);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_ReadXPMFromArrayToRGB888")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint ReadXPMFromArrayToRGB888(byte** xpm);

        #endregion

        #region Save Generic

        /// <summary>
        /// Save an SDL_Surface into an image file. <br></br>
        /// Format determined by extension. Default quality: 90.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_Save", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Save(nint surface, string file);

        /// <summary>Save an SDL_Surface to an SDL_IOStream using an explicit type hint.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveTyped_IO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveTyped(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio, string type);

        #endregion

        #region Save Specific Format

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveAVIF", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveAVIF(nint surface, string file, int quality);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveAVIF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveAVIF(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio, int quality);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveBMP", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveBMP(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveBMP_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveBMP(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveCUR", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveCUR(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveCUR_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveCUR(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveGIF", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveGIF(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveGIF_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveGIF(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveICO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveICO(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveICO_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveICO(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        /// <summary>
        /// Save an SDL_Surface as JPEG. <br></br>
        /// Quality: [0-33] = low, [34-66] = medium, [67-100] = high.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveJPG", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveJPG(nint surface, string file, int quality);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveJPG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveJPG(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio, int quality);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SavePNG", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SavePNG(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SavePNG_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SavePNG(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveTGA", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveTGA(nint surface, string file);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveTGA_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveTGA(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

        /// <summary>
        /// Save an SDL_Surface as WEBP. <br></br>
        /// Quality 0 - 100; For lossy, 0 = smallest; For lossless, 0 = fastest.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveWEBP", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveWEBP(nint surface, string file, float quality);

        [LibraryImport(nativeLibraryName, EntryPoint = "IMG_SaveWEBP_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SaveWEBP(nint surface, nint dst, [MarshalAs(UnmanagedType.I1)] bool closeio, float quality);

        #endregion

        // TODO Animation
    }
}
