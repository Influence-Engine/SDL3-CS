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
    }
}
