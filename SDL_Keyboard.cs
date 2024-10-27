using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Keysym
        {
            public ScanCode scanCode;
            public KeyCode keyCode;
            public KeyMod mod;
            public uint unused;
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetKeyboardFocus();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardState", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetKeyboardState(out int numKeys);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetModState", CallingConvention = CallingConvention.Cdecl)]
        public static extern KeyMod GetModState();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetModState", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModState(KeyMod modState);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = CallingConvention.Cdecl)]
        public static extern KeyCode GetKeyFromScanCode(ScanCode scanCode);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = CallingConvention.Cdecl)]
        public static extern ScanCode GetScanCodeFromKey(KeyCode keyCode);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetScanCodeName(ScanCode scanCode);
        public static string GetScanCodeName(ScanCode scanCode) => Marshal.PtrToStringUTF8(Internal_GetScanCodeName(scanCode));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe ScanCode Internal_GetScanCodeFromName(byte* name);
        public static unsafe ScanCode GetScanCodeFromName(string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_GetScanCodeFromName(Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetKeyName(KeyCode keyCode);
        public static string GetKeyName(KeyCode keyCode) => Marshal.PtrToStringUTF8(Internal_GetKeyName(keyCode));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe KeyCode Internal_GetKeyFromName(byte* name);
        public static unsafe KeyCode GetKeyFromName(string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_GetKeyFromName(Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));
        }

        [DllImport(nativeLibraryName, EntryPoint = "SDL_StartTextInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartTextInput();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_IsTextInputActive", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsTextInputActive();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_StopTextInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopTextInput();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_ClearComposition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearComposition();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_IsTextInputShown", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsTextInputShown();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetTextInputRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextInputRect(ref Rect rect);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasScreenKeyboardSupport();

        [DllImport(nativeLibraryName, EntryPoint = "SDL_IsScreenKeyboardShown", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsScreenKeyboardShown();
    }
}
