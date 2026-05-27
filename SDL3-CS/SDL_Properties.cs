using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public const string PropNameString = "SDL.name";

        public enum PropertyType
        {
            Invalid = 0,
            Pointer = 1,
            String = 2,
            Number = 3,
            Float = 4,
            Boolean = 5
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CleanupPropertyCallback(IntPtr userdata, IntPtr value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EnumeratePropertiesCallback(IntPtr userdata, uint props, IntPtr name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGlobalProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint GetGlobalProperties();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial uint CreateProperties();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CopyProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool CopyProperties(uint src, uint dst);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_LockProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool LockProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_UnlockProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void UnlockProperties(uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetPointerPropertyWithCleanup")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetPointerPropertyWithCleanup(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value, CleanupPropertyCallback? cleanup, IntPtr userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetPointerProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetPointerProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetStringProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetStringProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string? value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetNumberProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetNumberProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, long value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetFloatProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetFloatProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, float value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetBooleanProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetBooleanProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.I1)] bool value);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HasProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HasProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPropertyType")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial PropertyType GetPropertyType(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetPointerProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr GetPointerProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr defaultValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetStringProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] 
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetStringProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string? defaultValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNumberProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial long GetNumberProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, long defaultValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetFloatProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial float GetFloatProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, float defaultValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetBooleanProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetBooleanProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.I1)] bool defaultValue);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ClearProperty")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ClearProperty(uint props, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EnumerateProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool EnumerateProperties(uint props, EnumeratePropertiesCallback callback, IntPtr userdata);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void DestroyProperties(uint props);
    }
}
