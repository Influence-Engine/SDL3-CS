using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public enum HintPriority
        {
            Default,
            Normal,
            Override
        }

        public static class Hints
        {
            public const string AllowAltTabWhileGrabbed = "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

            public const string AndroidAllowRecreateActivity = "SDL_ANDROID_ALLOW_RECREATE_ACTIVITY";
            public const string AndroidBlockOnPause = "SDL_ANDROID_BLOCK_ON_PAUSE";
            public const string AndroidTrapBackButton = "SDL_ANDROID_TRAP_BACK_BUTTON";

            public const string AppID = "SDL_APP_ID";
            public const string AppName = "SDL_APP_NAME";

            public const string AppleTVControllerUIEvents = "SDL_APPLE_TV_CONTROLLER_UI_EVENTS";
            public const string AppleTVRemoteAllowRotation = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

            public const string AudioAlsaDefaultDevice = "SDL_AUDIO_ALSA_DEFAULT_DEVICE";
            public const string AudioCategory = "SDL_AUDIO_CATEGORY";
            public const string AudioChannels = "SDL_AUDIO_CHANNELS";
            public const string AudioDeviceIconName = "SDL_AUDIO_DEVICE_APP_ICON_NAME";
            public const string AudioDeviceSampleFrames = "SDL_AUDIO_DEVICE_SAMPLE_FRAMES";
            public const string AudioDeviceStreamName = "SDL_AUDIO_DEVICE_STREAM_NAME";
            public const string AudioDeviceStreamRole = "SDL_AUDIO_DEVICE_STREAM_ROLE";
            public const string AudioDiskInputFile = "SDL_AUDIO_DISK_INPUT_FILE";
            public const string AudioDiskOutputFile = "SDL_AUDIO_DISK_OUTPUT_FILE";
            public const string AudioDiskTimescale = "SDL_AUDIO_DISK_TIMESCALE";
            public const string AudioDriver = "SDL_AUDIO_DRIVER";
            public const string AudioDummyTimescale = "SDL_AUDIO_DISK_TIMESCALE";
            public const string AudioFormat = "SDL_AUDIO_FORMAT";
            public const string AudioFrequency = "SDL_AUDIO_FREQUENCY";
            public const string AudioIncludeMonitors = "SDL_AUDIO_INCLUDE_MONITORS";

            public const string AutoUpdateJoysticks = "SDL_AUTO_UPDATE_JOYSTICKS";
            public const string AutoUpdateSensors = "SDL_AUTO_UPDATE_SENSORS";

            public const string BMPSaveLegacyFormat = "SDL_BMP_SAVE_LEGACY_FORMAT";

            public const string CameraDriver = "SDL_CAMERA_DRIVER";

            public const string CPUFeatureMask = "SDL_CPU_FEATURE_MASK";

            public const string JoystickDirectinput = "SDL_JOYSTICK_DIRECTINPUT";

            // TODO so many missing

            public const string EventLogging = "SDL_EVENT_LOGGING";

            public const string ForceRaiseWindow = "SDL_HINT_FORCE_RAISEWINDOW";
            public const string FrameBufferAcceleration = "SDL_FRAMEBUFFER_ACCELERATION";

            // TODO even more

            public const string OpenGLESDriver = "SDL_OPENGL_ES_DRIVER";

            public const string OpenVRLibrary = "SDL_OPENVR_LIBRARY";

            public const string Orientations = "SDL_ORIENTATIONS";

            public const string PollSentinel = "SDL_POLL_SENTINEL";

            public const string PreferredLocales = "SDL_PREFERRED_LOCALES";

            public const string QuitOnLastWindowClose = "SDL_QUIT_ON_LAST_WINDOW_CLOSE";

            public const string RenderDirect3DThreadsafe = "SDL_RENDER_DIRECT3D_THREADSAFE";
            public const string RenderDirect3D11Debug = "SDL_RENDER_DIRECT3D11_DEBUG";
            public const string RenderVulkanDebug = "SDL_RENDER_VULKAN_DEBUG";
            public const string RenderGPUDebug = "SDL_RENDER_GPU_DEBUG";
            public const string RenderGPULowPower = "SDL_RENDER_GPU_LOW_POWER";
            public const string RenderDriver = "SDL_RENDER_DRIVER";
            public const string RenderLineMethod = "SDL_RENDER_LINE_METHOD";
            public const string RenderMetalPreferLowPowerDevice = "SDL_RENDER_METAL_PREFER_LOW_POWER_DEVICE";
            public const string RenderVSync = "SDL_RENDER_VSYNC";

            public const string VideoDoubleBuffer = "SDL_VIDEO_DOUBLE_BUFFER";
            public const string VideoDriver = "SDL_VIDEO_DRIVER";

            public const string WindowActivateWhenRaised = "SDL_WINDOW_ACTIVATE_WHEN_RAISED";
            public const string WindowActivateWhenShown = "SDL_WINDOW_ACTIVATE_WHEN_SHOWN";
            public const string WindowAllowTopmost = "SDL_WINDOW_ALLOW_TOPMOST";
            public const string WindowFrameUsableWhileCursorHidden = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

            public const string WindowsCloseOnAltF4 = "SDL_WINDOWS_CLOSE_ON_ALT_F4";
            public const string WindowsEnableMenuMnemonic = "SDL_WINDOWS_ENABLE_MENU_MNEMONICS";
            public const string WindowsEnableMessageloop = "SDL_WINDOWS_ENABLE_MESSAGELOOP";
            public const string WindowsGameinput = "SDL_WINDOWS_GAMEINPUT";
            public const string WindowsRawKeyboard = "SDL_WINDOWS_RAW_KEYBOARD";

            public const string Assert = "SDL_ASSERT";
            // TODO A lot of these lol

        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool Internal_SetHintWithPriority(byte* name, byte* value, HintPriority priority);
        public static unsafe bool SetHintWithPriority(string name, string value, HintPriority priority)
        {
            int utf8NameBufferSize = Utility.UTF8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufferSize];

            int utf8ValueBufferSize = Utility.UTF8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufferSize];

            return Internal_SetHintWithPriority(
                Utility.UTF8Encode(name, utf8Name, utf8NameBufferSize),
                Utility.UTF8Encode(value, utf8Value, utf8ValueBufferSize),
                priority);
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool Internal_SetHint(byte* name, byte* value);

        /// <summary>Set a hint with normal priority.</summary>
        /// <param name="name">The hint to set.</param>
        /// <param name="value">The valur of the hint variable.</param>
        /// <returns>True on success or false on failure.</returns>
        public static unsafe bool SetHint(string name, string value)
        {
            int utf8NameBufferSize = Utility.UTF8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufferSize];

            int utf8ValueBufferSize = Utility.UTF8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufferSize];

            return Internal_SetHint(
                Utility.UTF8Encode(name, utf8Name, utf8NameBufferSize),
                Utility.UTF8Encode(value, utf8Value, utf8ValueBufferSize));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_ResetHint", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool Internal_ResetHint(byte* name);

        /// <summary>Reset a hint to the default value.</summary>
        /// <param name="name">The hint to reset.</param>
        /// <returns>True on sucess or false on failure.</returns>
        public static unsafe bool ResetHint(string name)
        {
            int utf8NameBufferSize = Utility.UTF8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufferSize];

            return Internal_ResetHint(Utility.UTF8Encode(name, utf8Name, utf8NameBufferSize));
        }

        /// <summary>Reset all hints to the default values.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_ResetHints", CallingConvention = CallingConvention.Cdecl)]
        public static extern void  ResetHints();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr Internal_GetHint(byte* name);

        /// <summary>Get the value of a hint.</summary>
        /// <param name="name">The hint to query.</param>
        /// <returns>The string value of a hint or NULL if the hint isn't set.</returns>
        public static unsafe string GetHint(string name)
        {
            int utf8NameBufferSize = Utility.UTF8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufferSize];

            return Marshal.PtrToStringUTF8(Internal_GetHint(Utility.UTF8Encode(name, utf8Name, utf8NameBufferSize)));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool Internal_GetHintBoolean(byte* name, bool defaultValue);

        /// <summary>Get the boolean value of a hint variable.</summary>
        /// <param name="name">The name of the hint tog et the boolean value from.</param>
        /// <param name="defaultValue">The value to return if the hint does not exist.</param>
        /// <returns>The boolean value of a hint or the given default value if the hint does not exist.</returns>
        public static unsafe bool GetHintBoolean(string name, bool defaultValue)
        {
            int utf8NameBufferSize = Utility.UTF8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufferSize];

            return Internal_GetHintBoolean(Utility.UTF8Encode(name, utf8Name, utf8NameBufferSize), defaultValue);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void HintCallback(IntPtr userData, string name, string oldValue, string newValue);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AddHintCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AddHintCallback(string name, HintCallback callback, IntPtr userData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RemoveHintCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveHintCallback(string name, HintCallback callback, IntPtr userData);
    }
}
