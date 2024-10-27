using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
#if DEBUG
        private const string nativeLibraryName = "SDL3-Debug.dll";
#else
        private const string nativeLibraryName = "SDL3.dll";
#endif

        /// <summary>Initialization Flags for "SDL.Init"</summary>
        [Flags]
        public  enum InitFlags : uint
        {
            Timer = 0x00000001,
            Audio = 0x00000010,
            Video = 0x00000020,
            Joystick = 0x00000200,
            Haptic = 0x00001000,
            Gamepad = 0x00002000,
            Events = 0x00004000,
            Sensor = 0x00008000,
            Everything = (Timer | Audio | Video | Joystick | Haptic | Gamepad | Events | Sensor)
        }

        /// <summary>Initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Init(uint flags);

        /// <summary>Initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        public static bool Init(InitFlags flags) => Init((uint)flags);

        /// <summary>Compatibility function to initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_InitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitSubSystem(uint flags);

        /// <summary>Compatibility function to initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        public static bool InitSubSystem(InitFlags flags) => InitSubSystem((uint)flags);

        /// <summary>Shit down specific SDL subsystems.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_QuitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QuitSubSystem();

        /// <summary>Get a mask of the specified subsystems which are currently initialized.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>A mask of all initialized subsystems if flags is 0, otherwise the init status of the specified subsystems.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_WasInit", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint WasInit(uint flags);

        /// <summary>Clean up all initialized subsystems.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_Quit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Quit();


    }
}
