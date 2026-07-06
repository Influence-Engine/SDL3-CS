using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class MIX
    {
        const string nativeLibraryName = "SDL3_mixer";

        public const int MajorVersion = 3;
        public const int MinorVersion = 3;
        public const int MicroVersion = 0;

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct StereoGains
        {
            public float left;
            public float right;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point3D
        {
            public float x;
            public float y;
            public float z;
        }

        #endregion

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void TrackStoppedCallback(nint userdata, nint track);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void TrackMixCallback(nint userdata, nint track, nint spec, float* pcm, int samples);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void GroupMixCallback(nint userdata, nint group, nint spec, float* pcm, int samples);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void PostMixCallback(nint userdata, nint mixer, nint spec, float* pcm, int samples);

        #endregion

        #region Property Names

        public static class AudioLoadProps
        {
            public const string IOStream = "SDL_mixer.audio.load.iostream";
            public const string CloseIO = "SDL_mixer.audio.load.closeio";
            public const string Predecode = "SDL_mixer.audio.load.predecode";
            public const string PreferredMixer = "SDL_mixer.audio.load.preferred_mixer";
            public const string SkipMetadataTags = "SDL_mixer.audio.load.skip_metadata_tags";
            public const string IgnoreLoops = "SDL_mixer.audio.load.ignore_loops";
            public const string Decoder = "SDL_mixer.audio.decoder";
        }

        public static class PlayProps
        {
            public const string Loops = "SDL_mixer.play.loops";
            public const string MaxFrame = "SDL_mixer.play.max_frame";
            public const string MaxMilliseconds = "SDL_mixer.play.max_milliseconds";
            public const string StartFrame = "SDL_mixer.play.start_frame";
            public const string StartMillisecond = "SDL_mixer.play.start_millisecond";
            public const string StartOrder = "SDL_mixer.play.start_order";
            public const string LoopStartFrame = "SDL_mixer.play.loop_start_frame";
            public const string LoopStartMillisecond = "SDL_mixer.play.loop_start_millisecond";
            public const string FadeInFrames = "SDL_mixer.play.frade_in_frames";
            public const string FadeInMilliseconds = "SDL_mixer.play.fade_in_milliseconds";
            public const string FadeInStartGain = "SDL_mixer.play.fade_in_start_gain";
            public const string AppendSilenceFrames = "SDL_mixer.play.append_silence_frames";
            public const string AppendSilenceMilliseconds = "SDL_mixer.play.append_silence_milliseconds";
            public const string HaltWhenExhausted = "SDL_mixer.play.halt_when_exhausted";
        }

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_Version")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int Version();

        /// <summary>Initialize Mixer.</summary>
        /// <returns>True on success, false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_Init")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init();

        /// <summary>De-initialize Mixer.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_Quit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetNumAudioDecoders")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetNumAudioDecoders();

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioDecoder")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetAudioDecoderPtr(int index);

        /// <inheritdoc cref="GetAudioDecoderPtr"/>
        public static string? GetAudioDecoder(int index)
        {
            IntPtr ptr = GetAudioDecoderPtr(index);
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
        }

        #region Mixer Create / Destroy

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateMixerDevice")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateMixerDevice(uint deviceID, nint spec);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateMixer(nint spec);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DestroyMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyMixer(nint mixer);

        #endregion

        #region Mixer Properties

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetMixerProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetMixerProperties(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetMixerFormat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetMixerFormat(nint mixer, nint spec);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LockMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void LockMixer(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_UnlockMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UnlockMixer(nint mixer);

        #endregion

        #region Audio Load

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadAudio_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadAudio(nint mixer, nint io, [MarshalAs(UnmanagedType.I1)] bool predecode, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadAudio", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadAudio(nint mixer, string path, [MarshalAs(UnmanagedType.I1)] bool predecode);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadAudioNoCopy")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadAudioNoCopy(nint mixer, nint data, nuint datalen, [MarshalAs(UnmanagedType.I1)] bool freeWhenDone);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadAudioWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadAudioWithProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadRawAudio_IO")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadRawAudio(nint mixer, nint io, nint spec, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadRawAudio", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadRawAudio(nint mixer, nint data, nuint datalen, nint spec);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_LoadRawAudioNoCopy")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint LoadRawAudioNoCopy(nint mixer, nint data, nuint datalen, nint spec, [MarshalAs(UnmanagedType.I1)] bool freeWhenDone);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateSineWaveAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateSineWaveAudio(nint mixer, int hz, float amplitude, long ms);

        #endregion

        #region Audio Properties

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetAudioProperties(nint audio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioDuration")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial long GetAudioDuration(nint audio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioFormat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetAudioFormat(nint audio, nint spec);

        #endregion

        /// <summary>Destroy a MIX_Audio and free its resources.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DestroyAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyAudio(nint audio);

        #region Track Create / Destroy

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateTrack(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DestroyTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyTrack(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetTrackProperties(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetTrackMixer(nint track);

        #endregion

        #region Track Input Assignment

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackAudio(nint track, nint audio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackAudioStream")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackAudioStream(nint track, nint stream);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackIOStream")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackIOStream(nint track, nint io, [MarshalAs(UnmanagedType.I1)] bool closeio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackRawIOStream")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackRawIOStream(nint track, nint io, nint spec, [MarshalAs(UnmanagedType.I1)] bool closeio);

        #endregion

        #region Track Tagging

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_TagTrack", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool TagTrack(nint track, string tag);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_UntagTrack", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UntagTrack(nint track, string tag);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackTags")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetTrackTags(nint track, out int count);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTraggedTracks", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint GetTraggedTracks(nint mixer, string tag, out int count);

        #endregion

        #region Track Position / Loops / Query

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackPlaybackPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackPlaybackPosition(nint track, long frames);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackPlaybackPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial long GetTrackPlaybackPosition(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackFadeFrames")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long GetTrackFadeFrames(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackLoops")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial int GetTrackLoops(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackLoops")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackLoops(nint track, int numLoops);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetTrackAudio(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackAudioStream")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetTrackAudioStream(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackRemaining")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial long GetTrackRemaining(nint track);

        #endregion

        #region TIme Conversion

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_TrackMSToFrames")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long TrackMSToFrames(nint track, long ms);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_TrackFramesToMS")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long TrackFramesToMS(nint track, long frames);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_AudioMSToFrames")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long AudioMSToFrames(nint track, long ms);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_MSToFrames")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long MSToFrames(int sampleRate, long ms);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_FramesToMS")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial long FramesToMS(int sampleRate, long frames);

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PlayTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PlayTrack(nint track, uint options);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PlayTag", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PlayTag(nint mixer, string tag, uint options);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PlayAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PlayAudio(nint mixer, nint audio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_StopTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StopTrack(nint track, long fadeOutFrames);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_StopAllTracks")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StopAllTracks(nint mixer, long fadeOutMs);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_StopTag", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StopTag(nint mixer, string tag, long fadeOutMs);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PauseTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PauseTrack(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PauseAllTracks")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PauseAllTracks(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_PauseTag", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool PauseTag(nint mixer, string tag);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_ResumeTrack")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ResumeTrack(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_ResumeAllTracks")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ResumeAllTracks(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_ResumeTag", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ResumeTag(nint mixer, string tag, uint options);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_TrackPlaying")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool TrackPlaying(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_TrackPaused")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool TrackPaused(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetMixerGain")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetMixerGain(nint mixer, float gain);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetMixerGain")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial float GetMixerGain(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackGain")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackGain(nint track, float gain);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackGain")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial float GetTrackGain(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTagGain", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTagGain(nint mixer, string tag, float gain);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetMixerFrequencyRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetMixerFrequencyRatio(nint mixer, float ratio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetMixerFrequencyRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial float GetMixerFrequencyRatio(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackFrequencyRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackFrequencyRatio(nint track, float ratio);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrackFrequencyRatio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial float GetTrackFrequencyRatio(nint track);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackOutputChannelMap")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetTrackOutputChannelMap(nint track, int* chmap, int count);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackStereo")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetTrackStereo(nint track, StereoGains* gains);

        #region Get/Set Track3DPosition

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrack3DPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetTrack3DPosition(nint track, Point3D* position);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrack3DPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe partial bool SetTrack3DPosition(nint track, Vector3* position);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrack3DPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTrack3DPosition(nint track, out Point3D position);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetTrack3DPosition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTrack3DPosition(nint track, out Vector3 position);

        #endregion

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateGroup")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateGroup(nint mixer);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DestroyGroup")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyGroup(nint group);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetGroupProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetGroupProperties(nint group);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetGroupMixer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetGroupMixer(nint group);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackGroup")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackGroup(nint group);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackStoppedCallback")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackStoppedCallback(nint track, TrackStoppedCallback? callback, nint userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackRawCallback")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackRawCallback(nint track, TrackMixCallback? callback, nint userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetTrackCookedCallback")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTrackCookedCallback(nint track, TrackMixCallback? callback, nint userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetGroupPostMixCallback")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetGroupPostMixCallback(nint group, GroupMixCallback? callback, nint userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_SetPostMixCallback")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetPostMixCallback(nint mixer, PostMixCallback? callback, nint userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_Generate")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int Generate(nint mixer, nint buffer, nint buflen);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateAudioDecoder_IO", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateAudioDecoder(nint io, [MarshalAs(UnmanagedType.I1)] bool closeio, uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_CreateAudioDecoder", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial nint CreateAudioDecoder(string path, uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DestroyAudioDecoder")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyAudioDecoder(nint decoder);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioDecoderProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetAudioDecoderProperties(nint decoder);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_GetAudioDecoderFormat")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetAudioDecoderFormat(nint decoder, nint spec);

        [LibraryImport(nativeLibraryName, EntryPoint = "MIX_DecodeAudio")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int DecodeAudio(nint decoder, nint buffer, int buflen, nint spec);
    }
}
