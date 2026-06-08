using System.Runtime.CompilerServices;
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
            public static string AndroidLowLatencyAudio = "SDL_ANDROID_LOW_LATENCY_AUDIO";
            public const string AndroidTrapBackButton = "SDL_ANDROID_TRAP_BACK_BUTTON";
            public const string AndroidAllowPersistentFolderAccess = "SDL_ANDROID_ALLOW_PERSISTENT_FOLDER_ACCESS";

            public const string AppID = "SDL_APP_ID";
            public const string AppName = "SDL_APP_NAME";

            public const string AppleTVControllerUIEvents = "SDL_APPLE_TV_CONTROLLER_UI_EVENTS";
            public const string AppleTVRemoteAllowRotation = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

            public const string AudioAlsaDefaultDevice = "SDL_AUDIO_ALSA_DEFAULT_DEVICE";
            public const string AudioAlsaDefaultPlaybackDevice = "SDL_AUDIO_ALSA_DEFAULT_PLAYBACK_DEVICE";
            public const string AudioAlsaDefaultRecordingDevice = "SDL_AUDIO_ALSA_DEFAULT_RECORDING_DEVICE";
            public const string AudioCategory = "SDL_AUDIO_CATEGORY";
            public const string AudioChannels = "SDL_AUDIO_CHANNELS";
            public const string AudioDeviceAppIconName = "SDL_AUDIO_DEVICE_APP_ICON_NAME";
            public const string AudioDeviceSampleFrames = "SDL_AUDIO_DEVICE_SAMPLE_FRAMES";
            public const string AudioDeviceStreamName = "SDL_AUDIO_DEVICE_STREAM_NAME";
            public const string AudioDeviceStreamRole = "SDL_AUDIO_DEVICE_STREAM_ROLE";
            public const string AudioDeviceRawStream = "SDL_AUDIO_DEVICE_RAW_STREAM";
            public const string AudioDiskInputFile = "SDL_AUDIO_DISK_INPUT_FILE";
            public const string AudioDiskOutputFile = "SDL_AUDIO_DISK_OUTPUT_FILE";
            public const string AudioDiskTimescale = "SDL_AUDIO_DISK_TIMESCALE";
            public const string AudioDriver = "SDL_AUDIO_DRIVER";
            public const string AudioDuckOthers = "SDL_AUDIO_DUCK_OTHERS";
            public const string AudioDummyTimescale = "SDL_AUDIO_DUMMY_TIMESCALE";
            public const string AudioFormat = "SDL_AUDIO_FORMAT";
            public const string AudioFrequency = "SDL_AUDIO_FREQUENCY";
            public const string AudioIncludeMonitors = "SDL_AUDIO_INCLUDE_MONITORS";

            public const string AutoUpdateJoysticks = "SDL_AUTO_UPDATE_JOYSTICKS";
            public const string AutoUpdateSensors = "SDL_AUTO_UPDATE_SENSORS";

            public const string BMPSaveLegacyFormat = "SDL_BMP_SAVE_LEGACY_FORMAT";

            public const string CameraDriver = "SDL_CAMERA_DRIVER";

            public const string CPUFeatureMask = "SDL_CPU_FEATURE_MASK";

            public const string JoystickDirectinput = "SDL_JOYSTICK_DIRECTINPUT";

            public const string FileDialogDriver = "SDL_FILE_DIALOG_DRIVER";

            public const string DisplayUsableBounds = "SDL_DISPLAY_USABLE_BOUNDS";

            public const string DOSAllowDirectFramebuffer = "SDL_DOS_ALLOW_DIRECT_FRAMEBUFFER";

            public const string InvalidParamChecks = "SDL_INVALID_PARAM_CHECKS";

            public const string EmscriptenAsyncify = "SDL_EMSCRIPTEN_ASYNCIFY";
            public const string EmscriptenCanvasSelector = "SDL_EMSCRIPTEN_CANVAS_SELECTOR";
            public const string EmscriptenKeyboardElement = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

            public const string EnableScreenKeybaord = "SDL_ENABLE_SCREEN_KEYBOARD";

            public const string EvdevDevices = "SDL_EVDEV_DEVICES";

            public const string EventLogging = "SDL_EVENT_LOGGING";

            public const string ForceRaiseWindow = "SDL_FORCE_RAISEWINDOW";
            public const string FrameBufferAcceleration = "SDL_FRAMEBUFFER_ACCELERATION";

            public const string GameControllerConfig = "SDL_GAMECONTROLLERCONFIG";
            public const string GameControllerConfigFile = "SDL_GAMECONTROLLERCONFIG_File";
            public const string GameControllerType= "SDL_GAMECONTROLLERTYPE";
            public const string GameControllerIgnoreDevices = "SDL_GAMECONTROLLER_IGNORE_DEVICES";
            public const string GameControllerIgnoreDevicesExcept = "SDL_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT";
            public const string GameControllerSensorFusion = "SDL_GAMECONTROLLER_SENSOR_FUSION";

            public const string GDKTextInputDefaultText = "SDL_GDK_TEXTINPUT_DEFAULT_TEXT";
            public const string GDKTextInputDescription = "SDL_GDK_TEXTINPUT_DESCRIPTION";
            public const string GDKTextInputMaxLength = "SDL_GDK_TEXTINPUT_DEFAULT_MAX_LENGTH";

            public const string GDKTextInputScope = "SDL_GDK_TEXTINPUT_SCOPE";
            public const string GDKTextInputTitle = "SDL_GDK_TEXTINPUT_TITLE";

            public const string HIDAPILibUsb= "SDL_HIDAPI_LIBUSB";
            public const string HIDAPILibUsbGameCube = "SDL_HIDAPI_LIBUSB_GAMECUBE";
            public const string HIDAPILibUsbWhitelist = "SDL_HIDAPI_LIBUSB_WHITELIST";
            public const string HIDAPIUDev = "SDL_HIDAPI_UDEV";

            public const string GPUDriver = "SDL_GPU_DRIVER";

            public const string OpenXR_Library = "SDL_OPENXR_LIBRARY";

            public const string HIDAPIEnumerateOnlyControllers = "SDL_HIDAPI_ENUMERATE_ONLY_CONTROLLERS";
            public const string HIDAPIIgnoreDevices = "SDL_HIDAPI_IGNORE_DEVICES";

            public const string IMEImplementedUI = "SDL_IME_IMPLEMENTED_UI";
            public const string IOSHideHomeIndicator = "SDL_IOS_HIDE_HOME_INDICATOR";

            public const string JoystickAllowBackgroundEvents = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
            public const string JoystickArcadestickDevices = "SDL_JOYSTICK_ARCADESTICK_DEVICES";
            public const string JoystickArcadestickDevicesExcluded= "SDL_JOYSTICK_ARCADESTICK_DEVICES_EXCLUDED";
            public const string JoystickBlacklistDevices = "SDL_JOYSTICK_BLACKLIST_DEVICES";
            public const string JoystickBlacklistDevicesExcluded = "SDL_JOYSTICK_BLACKLIST_DEVICES_EXCLUDED";
            public const string JoystickDevice = "SDL_JOYSTICK_DEVICE";
            public const string JoystickDrumDevices = "SDL_JOYSTICK_DRUM_DEVICES";
            public const string JoystickEnhancedReports = "SDL_JOYSTICK_ENHANCED_REPORTS";
            public const string JoystickFlightstickDevices = "SDL_JOYSTICK_FLIGHTSTICK_DEVICES";
            public const string JoystickFlightstickDevicesExcluded= "SDL_JOYSTICK_FLIGHTSTICK_DEVICES_EXCLUDED";
            public const string JoystickGameinput= "SDL_JOYSTICK_GAMEINPUT";
            public const string JoystickGameinputRaw = "SDL_JOYSTICK_GAMEINPUT_RAW";

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

        /// <summary>Set a hint with a specific priority.</summary>
        /// <param name="name">The hint to set.</param>
        /// <param name="value">The value of the hint variable.</param>
        /// <param name="priority">The priority level for the hint.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetHintWithPriority", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetHintWithPriority(string name, string value, HintPriority priority);

        /// <summary>Set a hint with normal priority.</summary>
        /// <param name="name">The hint to set.</param>
        /// <param name="value">The valur of the hint variable.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetHint", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetHint(string name, string value);

        /// <summary>Reset a hint to the default value.</summary>
        /// <param name="name">The hint to reset.</param>
        /// <returns>True on sucess or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ResetHint", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ResetHint(string name);

        /// <summary>Reset all hints to the default values.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ResetHints")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void  ResetHints();

        /// <summary>Get the value of a hint.</summary>
        /// <param name="name">The hint to query.</param>
        /// <returns>The string value of a hint or NULL if the hint isn't set.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetHint", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetHint(string name);

        /// <summary>Get the boolean value of a hint variable.</summary>
        /// <param name="name">The name of the hint tog et the boolean value from.</param>
        /// <param name="defaultValue">The value to return if the hint does not exist.</param>
        /// <returns>The boolean value of a hint or the given default value if the hint does not exist.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetHintBoolean", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetHintBoolean(string name, [MarshalAs(UnmanagedType.I1)] bool defaultValue);

        /// <summary>Function pointer used for hint change callbacks.</summary>
        /// <param name="userData">What was passed as userData.</param>
        /// <param name="name">The hint name that changed.</param>
        /// <param name="oldValue">The previous value of the hint.</param>
        /// <param name="newValue">The new value of the hint.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void HintCallback(nint userData, string name, string oldValue, string newValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_AddHintCallback", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool AddHintCallback(string name, HintCallback callback, nint userData);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RemoveHintCallback", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void RemoveHintCallback(string name, HintCallback callback, nint userData);
    }
}
