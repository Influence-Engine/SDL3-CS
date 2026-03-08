using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public static partial class OpenGL
        {

            /// <summary>OpenGL profile flags for <see cref="Attribute.ContextProfileMask"/>.</summary>
            [Flags]
            public enum Profile : int
            {
                Core = 0x0001,
                Compatibility = 0x0002,
                ES = 0x0004,
            }

            /// <summary>OpenGL context flags for <see cref="Attribute.ContextFlags"/>.</summary>
            [Flags]
            public enum ContextFlag : int
            {
                Debug = 0x0001,
                ForwardCompatible = 0x0002,
                RobustAccess = 0x0004,
                ResetIsolation = 0x0008,
            }

            /// <summary>OpenGL context release behaviour for <see cref="Attribute.ContextReleaseBehaviour"/>.</summary>
            [Flags]
            public enum ContextReleaseFlag : int
            {
                None = 0x0000,
                Flush = 0x0001,
            }

            /// <summary>OpenGL configuration attributes.</summary>
            public enum Attribute : int
            {
                RedSize = 0,
                GreenSize = 1,
                BlueSize = 2,
                AlphaSize = 3,

                BufferSize = 4,
                DoubleBuffer = 5,

                DepthSize = 6,
                StencilSize = 7,

                AccumRedSize = 8,
                AccumGreenSize = 9,
                AccumBlueSize = 10,
                AccumAlphaSize = 11,

                Stereo = 12,

                MultisampleBuffers = 13,
                MultisampleSamples = 14,

                AcceleratedVisual = 15,

                RetainedBacking = 16,

                ContextMajorVersion = 17,
                ContextMinorVersion = 18,
                ContextFlags = 19,
                ContextProfileMask = 20,

                ShareWithCurrentContext = 21,

                FramebufferSRGBCapable = 22,
                ContextReleaseBehaviour = 23,
                ContextResetNotification = 24,
                ContextNoError = 25,
                Floatbuffers = 26,

                EGLPlatform = 27
            }

            #region Attribute

            /// <summary>Set an OpenGL window attribute before window creation.</summary>
            /// <param name="attribute">An <see cref="Attribute"/> enum value.</param>
            /// <param name="value">The desired value for the attribute.</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetAttribute"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetAttribute(Attribute attribute, int value);

            /// <summary>Get the value for an attribute from the current context.</summary>
            /// <param name="attribute">An <see cref="Attribute"/> enum value.</param>
            /// <param name="value">Filled in with the current value of attribute</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetAttribute"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetAttribute(Attribute attribute, out int value);

            /// <summary>Reset all previously set OpenGL context attributes to their default values.</summary>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_ResetAttributes")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ResetAttributes();

            #endregion

            #region Context

            /// <summary>Create an OpenGL context for an OpenGL window, and make it current.</summary>
            /// <param name="window">The window to associate with the context.</param>
            /// <returns>The OpenGL context associated with window, or NULL on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_CreateContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateContext(IntPtr window);

            /// <summary>Delete an OpenGL context.</summary>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_DestroyContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool DestroyContext(IntPtr context);

            #endregion

            /// <summary>Set up an OpenGL context for rendering into an OpenGL window.</summary>
            /// <param name="window">The window to associate with the context.</param>
            /// <param name="context">The OpenGL cotnext to associate with the window.</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_MakeCurrent"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool MakeCurrent(IntPtr window, IntPtr context);

            /// <summary>Get the currently active OpenGL context.</summary>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetCurrentContext();

            /// <summary>Get the currently active OpenGL window.</summary>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentWindow"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetCurrentWindow();

            /// <summary>Get an OpenGL function by name.</summary>
            /// <param name="proc">The name of an OpenGL function.</param>
            /// <returns>A pointer to the named OpenGL function. Returns NULL if not found.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetProcAddress", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetProcAddress(string proc);

            /// <summary>Check if an OpenGL extension is supported for the current context.</summary>
            /// <param name="extension">The name of the extension to check.</param>
            /// <returns>Tur if the extension is supported, false otherwise.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_ExtensionSupported", StringMarshalling = StringMarshalling.Utf8)]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool ExtensionSupported(string extension);

            #region Swap

            /// <summary>Update a window with OpenGL rendering.</summary>
            /// <param name="window">The window to change.</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SwapWindow")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SwapWindow(IntPtr window);

            /// <summary>Set the swap interval for the current OpenGL context.</summary>
            /// <param name="interval">0 for immediate, 1 for vsync, -1 for adaptive vsync.</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetSwapInterval(int interval);

            /// <summary>Get the swap interval for the current OpenGL context.</summary>
            /// <param name="interval">Output: 0 if immediate, 1 if vsync, -1 if adaptive vsync.</param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetSwapInterval(out int interval);

            #endregion
        }
    }
}
