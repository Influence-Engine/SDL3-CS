using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Gets whether a keyboard is currently connected.</summary>
        /// <returns>True if a keyboard is connected, false otherwise.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasKeyboard", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasKeyboard();

        /// <summary>Gets a list of currently connected keyboards.</summary>
        /// <param name="count">A pointer filled in with the number of keyboards returned</param>
        /// <returns>A 0 terminated array of keyboard instance IDs or NULL on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboards", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr[] GetKeyboards(out int count);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardNameForID", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetKeyboardNameFromID(IntPtr instanceID);
        /// <summary>Get the name of a keyboard.</summary>
        /// <param name="instanceID">The keyboard instance ID.</param>
        /// <returns>The name of the selected keyboard or NULL on failure.</returns>
        public static string GetKeyboardNameFromID(IntPtr instanceID) => Marshal.PtrToStringUTF8(Internal_GetKeyboardNameFromID(instanceID));

        /// <summary>Query the window which currently has keyboard focus.</summary>
        /// <returns>The window with keyboard focus.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetKeyboardFocus();

        /// <summary>Get a snapshot of the current state of the keyboard</summary>
        /// <param name="numKeys">if non-NULL, receives the length of the returned array.</param>
        /// <returns>A pointer to an array of key states.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardState", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetKeyboardState(out int numKeys);

        /// <summary>Clear the state of the keyboard.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_ResetKeyboard", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResetKeyboard();

        /// <summary>Get the current key modifier state for the keyboard.</summary>
        /// <returns>an OR'd combination of the modifier keys for the keyboard.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetModState", CallingConvention = CallingConvention.Cdecl)]
        public static extern KeyMod GetModState();

        /// <summary>Set the current key modifier state for the keyboard.</summary>
        /// <param name="modState">The desired KeyMod for the keyboard.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetModState", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModState(KeyMod modState);

        /// <summary>Get the key code correspoding to the given scancode according to the current keyboard layout.</summary>
        /// <param name="scanCode">The desired ScanCode to query</param>
        /// <param name="modstate">The modifier state to use when translating the scancode to a keycode.</param>
        /// <param name="keyEvent">True if the keycode will be used in key events.</param>
        /// <returns>The KeyCode that corresponds to the given ScanCode.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = CallingConvention.Cdecl)]
        public static extern KeyCode GetKeyFromScanCode(ScanCode scanCode, KeyMod modstate, bool keyEvent);

        /// <summary>Get the scancode corresponding to the given key copde according to the current keyboard layout.</summary>
        /// <param name="keyCode">Key the desired KeyCode to query.</param>
        /// <param name="modstate">A pointer to the modifier state that would be used when the scancode generates this key, may be NULL.</param>
        /// <returns>The ScanCode that corresponds to the given KeyCode.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = CallingConvention.Cdecl)]
        public static extern ScanCode GetScanCodeFromKey(KeyCode keyCode, ref KeyMod modstate);

        // TODO other SDL_SetScancodeName

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetScanCodeName(ScanCode scanCode);
        public static string GetScanCodeName(ScanCode scanCode) => Marshal.PtrToStringUTF8(Internal_GetScanCodeName(scanCode));


        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe ScanCode Internal_GetScanCodeFromName(byte* name);
        /// <summary>Get a scancode from a human-readable name.</summary>
        /// <param name="name">The human-readable scancode name.</param>
        /// <returns>The ScanCode, or ScanCode.Unknoqn if the name wasn't recognized.</returns>
        public static unsafe ScanCode GetScanCodeFromName(string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_GetScanCodeFromName(Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));
        }


        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Internal_GetKeyName(KeyCode keyCode);
        /// <summary>Get a human-readable name for key.</summary>
        /// <param name="keyCode">The desired KeyCode to query.</param>
        /// <returns>The key name.</returns>
        public static string GetKeyName(KeyCode keyCode) => Marshal.PtrToStringUTF8(Internal_GetKeyName(keyCode));

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe KeyCode Internal_GetKeyFromName(byte* name);
        /// <summary>Get a key code from a human-readable name.</summary>
        /// <param name="name">The human-readable name.</param>
        /// <returns>The KeyCode, or KeyCode.Unknown if the name wasn't recognized.</returns>
        public static unsafe KeyCode GetKeyFromName(string name)
        {
            int utf8TitleBufferSize = Utility.UTF8Size(name);
            byte* utf8Title = stackalloc byte[utf8TitleBufferSize];
            return Internal_GetKeyFromName(Utility.UTF8Encode(name, utf8Title, utf8TitleBufferSize));
        }

        /// <summary>Start accepting Unicode text input events in a window.</summary>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_StartTextInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StartTextInput();

        /// <summary>Text Input type.</summary>
        public enum TextInputType
        {
            Text,
            TextName,
            TextEmail,
            TextUsername,
            TextPasswordHidden,
            TextPasswordVisible,
            Number,
            NumberPasswordHidden,
            NumberPasswordVisible
        }

        /// <summary>Auto capitilization type.</summary>
        public enum Capitalization
        {
            None,
            Sentences,
            Words,
            Letters
        }

        /// <summary>Start accepting Unicode text input events in a window, with properties describing the input.</summary>
        /// <param name="window">The window to enable text input</param>
        /// <param name="props">	The properties to use.</param>
        /// <returns>Returns true on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_StartTextInputWithProperties", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StartTextInputWithProperties(IntPtr window, uint props);

        /// <summary>Checks whether or not Unicode text input events are enabled for a window.</summary>
        /// <param name="window">The window to check.</param>
        /// <returns>True if the text input events are enabled else false.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_TextInputActive", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TextInputActive(IntPtr window);

        /// <summary>Stop receiving any text input events in a window.</summary>
        /// <param name="window">The window to disable text input.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_StopTextInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StopTextInput(IntPtr window);

        /// <summary>Dismiss the composition window/IME without disabling the subystem.</summary>
        /// <param name="window">The window to affect.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_ClearComposition", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ClearComposition(IntPtr window);

        /// <summary>Set the area used to type Unicode text input.</summary>
        /// <param name="window">The window for which to set the text input area.</param>
        /// <param name="rect">The Rext representing the text input area, in window coordinates, or NULL to clear it.</param>
        /// <param name="cursor">The offset of the current cursor location relative to `rect->x`, in window coordinates</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetTextInputArea", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetTextInputArea(IntPtr window, ref Rect rect, int cursor);

        /// <summary>Get the area used to type Unicode text input.</summary>
        /// <param name="window">The window for which to query the text input area.</param>
        /// <param name="rect">A Rect filled in with the text input area, may be null.</param>
        /// <param name="cursor">The offset of the current cursor location relative to `rect->x`, may be NULL.</param>
        /// <returns>True on success or false on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetTextInputArea", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetTextInputArea(IntPtr window, out Rect rect, out int cursor);

        /// <summary>Check whether the platform has screen keyboard support.</summary>
        /// <returns>True if the platform has some screen keyboard support or false if not.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasScreenKeyboardSupport();

        /// <summary>Check whether the screen keyboard is shown for given window.</summary>
        /// <param name="window">The window for which screen keyboard should be queried.</param>
        /// <returns>True if screen keyboard is shown or false if not.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_ScreenKeyboardShown", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ScreenKeyboardShown(IntPtr window);
    }
}
