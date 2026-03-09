using System;
using System.Runtime.CompilerServices;
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

        /// <summary>Initialization Flags for <see cref="Init"/> and <see cref="InitSubSystem"/>.</summary>
        [Flags]
        public enum InitFlags : uint
        {
            Audio = 0x00000010,
            Video = 0x00000020,
            Joystick = 0x00000200,
            Haptic = 0x00001000,
            Gamepad = 0x00002000,
            Events = 0x00004000,
            Sensor = 0x00008000,
            Camera = 0x00010000,
            Everything = (Audio | Video | Joystick | Haptic | Gamepad | Events | Sensor)
        }

        /// <summary>Return values for optional main callbacks.</summary>
        public enum AppResult
        {
            Continue,
            Success,
            Failure
        }

        // To use
        // [LibraryImport(nativeLibraryName, EntryPoint = "Entry")]
        // [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]

        #region Init

        /// <summary>Initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Init"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init(uint flags);

        /// <inheritdoc cref="Init(uint)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Init(InitFlags flags) => Init((uint)flags);

        #endregion

        #region InitSubSystem

        /// <summary>Compatibility function to initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_InitSubSystem"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool InitSubSystem(uint flags);

        /// <inheritdoc cref="InitSubSystem(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_InitSubSystem"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool InitSubSystem(InitFlags flags);

        #endregion

        #region QuitSubSystem

        /// <summary>Shut down specific SDL subsystems.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_QuitSubSystem"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void QuitSubSystem(uint flags);

        /// <inheritdoc cref="QuitSubSystem(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_QuitSubSystem"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void QuitSubSystem(InitFlags flags);

        #endregion

        #region WasInit

        /// <summary>Get a mask of the specified subsystems which are currently initialized.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>A mask of all initialized subsystems if flags is 0, otherwise the init status of the specified subsystems.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WasInit"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint WasInit(uint flags);

        /// <inheritdoc cref="WasInit(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WasInit"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial InitFlags WasInit(InitFlags flags);

        #endregion

        /// <summary>Clean up all initialized subsystems.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Quit"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        /// <summary>Return whether this is the main thread.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_IsMainThread"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsMainThread();

        // TODO RunOnMainThread

        // TODO SetAppMetadata
        // TODO SetAppMetadataProperty
        // TODO Prop_App_Metadata defines
    }
}
