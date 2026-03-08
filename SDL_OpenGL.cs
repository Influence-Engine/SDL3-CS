using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public static partial class OpenGL
        {
            [Flags]
            public enum Profile : int
            {
                Core = 0x0001,
                Compatibility = 0x0002,
                ES = 0x0004,
            }

            [Flags]
            public enum ContextFlag : int
            {
                Debug = 0x0001,
                ForwardCompatible = 0x0002,
                RobustAccess = 0x0004,
                ResetIsolation = 0x0008,
            }

            [Flags]
            public enum ContextReleaseFlag : int
            {
                None = 0x0000,
                Flush = 0x0001,
            }

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
            /// <param name="attribute"></param>
            /// <param name="value"></param>
            /// <returns>True on success or false on failure.</returns>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetAttribute"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetAttribute(Attribute attribute, int value);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetAttribute"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetAttribute(Attribute attribute, out int value);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_ResetAttributes")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ResetAttributes();

            #endregion

            #region Context

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_CreateContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateContext(IntPtr window);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_DestroyContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool DestroyContext(IntPtr context);

            #endregion

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_MakeCurrent"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool MakeCurrent(IntPtr window, IntPtr context);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetCurrentContext"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr GetCurrentContext();

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

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SwapWindow")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SwapWindow(IntPtr window);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_SetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool SetSwapInterval(int interval);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GL_GetSwapInterval")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GetSwapInterval(out int interval);

            #endregion
        }
    }
}
