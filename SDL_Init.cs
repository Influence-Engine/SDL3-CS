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
            Audio = 0x00000010, // implies Events
            Video = 0x00000020, // implies Events; should be initialized on the main thread
            Joystick = 0x00000200, // implies Events
            Haptic = 0x00001000,
            Gamepad = 0x00002000, // implies Joystick
            Events = 0x00004000,
            Sensor = 0x00008000, // implies Events
            Camera = 0x00010000, // implies Events
            Everything = (Audio | Video | Joystick | Haptic | Gamepad | Events | Sensor)
        }

        /// <summary>Return values for optional main callbacks.</summary>
        public enum AppResult
        {
            /// <summary>Request that the app continues running.</summary>
            Continue,

            /// <summary>Request termination with success.</summary>
            Success,

            /// <summary>Request termination with failure.</summary>
            Failure
        }

        public static class AppMetadata
        {
            /// <summary>
            /// The human-readable name of the application, e.g. "My Game 2: Quartzi's Universe" <br></br>
            /// This will show up anywhere the OS shows the name of the application separately from window titles.
            /// </summary>
            public const string Name = "SDL.app.metadata.name";

            /// <summary>The version of the app, e.g "1.0.0beta5" or a git hash.</summary>
            public const string Version = "SDL.app.metadata.version";

            /// <summary>A unique reverse-domain identifier, e.g. "com.example.mygame2".</summary>
            public const string Identifier = "SDL.app.metadata.identifier";

            /// <summary>The human-readable name of the creator/developer, e.g. "Quartzi".</summary>
            public const string Creator = "SDL.app.metadata.creator";

            /// <summary>The human-readable copyright notice, kept to one line.</summary>
            public const string Copyright = "SDL.app.metadata.copyright";

            /// <summary>A URL to the app on the web (product page, storefront, GitHub, etc.).</summary>
            public const string Url = "SDL.app.metadata.url";

            /// <summary>The type of application: "game", "mediaplayer", or "application" (default).</summary>
            public const string Type = "SDL.app.metadata.type";
        }

        #region Init

        /// <summary>Initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Init")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init(uint flags);

        /// <inheritdoc cref="Init(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Init")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init(InitFlags flags);

        #endregion

        #region InitSubSystem

        /// <summary>Compatibility function to initialize the SDL library.</summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_InitSubSystem")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool InitSubSystem(uint flags);

        /// <inheritdoc cref="InitSubSystem(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_InitSubSystem")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool InitSubSystem(InitFlags flags);

        #endregion

        #region QuitSubSystem

        /// <summary>
        /// Shut down specific SDL subsystems. <br></br>
        /// You still need to call <see cref="Quit"/> even if you close all open subsystems.
        /// </summary>
        /// <param name="flags">Subsystem initialization flags.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_QuitSubSystem")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void QuitSubSystem(uint flags);

        /// <inheritdoc cref="QuitSubSystem(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_QuitSubSystem")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void QuitSubSystem(InitFlags flags);

        #endregion

        #region WasInit

        /// <summary>Get a mask of the specified subsystems which are currently initialized.</summary>
        /// <param name="flags">Subsystem flags to query, or 0 to return all intialized subsystems.</param>
        /// <returns>A mask of all initialized subsystems if <paramref name="flags"/> is 0, otherwise the init status of the specified subsystems.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WasInit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint WasInit(uint flags);

        /// <inheritdoc cref="WasInit(uint)"/>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_WasInit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial InitFlags WasInit(InitFlags flags);

        #endregion

        /// <summary>
        /// Clean up all initialized subsystems. <br></br>
        /// Should be called even if individual subsystems were already shut down via <see cref="QuitSubSystem"/>.
        /// </summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_Quit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        /// <summary>Return whether the calling thread is the main thread.</summary>
        /// <returns>True if this is the main thread, false otherwise.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_IsMainThread")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool IsMainThread();

        /// <summary>Callback run on the main thread via <see cref="RunOnMainThread"/>.</summary>
        /// <param name="userdata">An app-controlled pointer passed to the callback.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MainThreadCallback(nint userdata);

        /// <summary>
        /// Call a function on the main thread during event processing. <br></br>
        /// If called on the main thread, the callback executes immediately. <br></br>
        /// If called from another thread, it is queued for execution on the main thread.
        /// </summary>
        /// <param name="callback">The callback to call on the main thread.</param>
        /// <param name="userdata">A pointer passed to <paramref name="callback"/>.</param>
        /// <param name="waitComplete">True to block untill the callback completes, false to return immediately.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_RunOnMainThread")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool RunOnMainThread(MainThreadCallback callback, nint userdata, [MarshalAs(UnmanagedType.I1)] bool waitComplete);

        /// <summary>
        /// Specify basic metadata about your app. Call this before <see cref="Init"/> <br></br>
        /// Any parameter may be null to leave that field unset (or to clear a previously set value).
        /// </summary>
        /// <param name="appname">The human-readable name of the application.</param>
        /// <param name="appversion">The version string of the application.</param>
        /// <param name="appidentifier">A unique reverse-domain identifier.</param>
        /// <returns>True on success or false on failure</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetAppMetadata", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetAppMetadata(string? appname, string? appversion, string? appidentifier);

        /// <summary>
        /// Specify metadata about your app through a named property. <br></br>
        /// See <see cref="AppMetadata"/> for available property name constants.
        /// </summary>
        /// <param name="name">The metadata property name (see <see cref="AppMetadata"/>).</param>
        /// <param name="value">The value to set, or null to remove the property.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetAppMetadataProperty", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetAppMetadataProperty(string name, string? value);

        /// <summary>
        /// Get metadata about your app previously set via <see cref="SetAppMetadata"/> or <see cref="SetAppMetadataProperty"/>. <br></br>
        /// See <see cref="AppMetadata"/> for available property name constants.
        /// </summary>
        /// <param name="name">The metadata property name (see <see cref="AppMetadata"/>).</param>
        /// <returns>The current value of the property, the default if not set, or null for properties with no default.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetAppMetadataProperty", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetAppMetadataProperty(string name);
    }
}
