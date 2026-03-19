using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Return whether a keyboard is currently connected.</summary>
        /// <returns>True if a keyboard is connected, false otherwise.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HasKeyboard")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HasKeyboard();

        /// <summary>Gets a list of currently connected keyboards.</summary>
        /// <param name="count">A pointer filled in with the number of keyboards returned</param>
        /// <returns>A 0 terminated array of keyboard instance IDs or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboards")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial uint* GetKeyboards(out int count);

        /// <summary>Get the name of a keyboard.</summary>
        /// <param name="instanceID">The keyboard instance ID.</param>
        /// <returns>The name of the selected keyboard or NULL on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardNameForID")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string? GetKeyboardNameFromID(uint instanceID);


        /// <summary>Query the window which currently has keyboard focus.</summary>
        /// <returns>The window with keyboard focus.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardFocus")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial nint GetKeyboardFocus();

        /// <summary>Get a snapshot of the current state of the keyboard</summary>
        /// <param name="numKeys">if non-NULL, receives the length of the returned array.</param>
        /// <returns>A pointer to an array of key states.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyboardState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial bool* GetKeyboardState(out int numKeys);

        /// <summary>Clear the state of the keyboard.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ResetKeyboard")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void ResetKeyboard();

        /// <summary>Get the current key modifier state for the keyboard.</summary>
        /// <returns>an OR'd combination of the modifier keys for the keyboard.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetModState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial KeyMod GetModState();

        /// <summary>Set the current key modifier state for the keyboard.</summary>
        /// <param name="modState">The desired KeyMod for the keyboard.</param>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetModState")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void SetModState(KeyMod modState);

        /// <summary>Get the key code correspoding to the given scancode according to the current keyboard layout.</summary>
        /// <param name="scanCode">The desired ScanCode to query</param>
        /// <param name="modstate">The modifier state to use when translating the scancode to a keycode.</param>
        /// <param name="keyEvent">True if the keycode will be used in key events.</param>
        /// <returns>The KeyCode that corresponds to the given ScanCode.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromScancode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial KeyCode GetKeyFromScanCode(ScanCode scanCode, KeyMod modstate, [MarshalAs(UnmanagedType.I1)] bool keyEvent);

        /// <summary>Get the scancode corresponding to the given key copde according to the current keyboard layout.</summary>
        /// <param name="keyCode">Key the desired KeyCode to query.</param>
        /// <param name="modstate">A pointer to the modifier state that would be used when the scancode generates this key, may be NULL.</param>
        /// <returns>The ScanCode that corresponds to the given KeyCode.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromKey")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial ScanCode GetScanCodeFromKey(KeyCode keyCode, ref KeyMod modstate);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetScancodeName", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetScanCodeName(ScanCode scanCode, string name);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string GetScanCodeName(ScanCode scanCode);

        /// <summary>Get a scancode from a human-readable name.</summary>
        /// <param name="name">The human-readable scancode name.</param>
        /// <returns>The ScanCode, or ScanCode.Unknoqn if the name wasn't recognized.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetScancodeFromName", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial ScanCode GetScanCodeFromName(string name);

        /// <summary>Get a human-readable name for key.</summary>
        /// <param name="keyCode">The desired KeyCode to query.</param>
        /// <returns>The key name.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyName")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string GetKeyName(KeyCode keyCode);

        /// <summary>Get a key code from a human-readable name.</summary>
        /// <param name="name">The human-readable name.</param>
        /// <returns>The KeyCode, or KeyCode.Unknown if the name wasn't recognized.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetKeyFromName", StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial KeyCode GetKeyFromName(string name);

        /// <summary>Start accepting Unicode text input events in a window.</summary>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_StartTextInput")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StartTextInput(nint window);

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
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_StartTextInputWithProperties")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StartTextInputWithProperties(nint window, uint props);

        /// <summary>Checks whether or not Unicode text input events are enabled for a window.</summary>
        /// <param name="window">The window to check.</param>
        /// <returns>True if the text input events are enabled else false.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_TextInputActive")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool TextInputActive(nint window);

        /// <summary>Stop receiving any text input events in a window.</summary>
        /// <param name="window">The window to disable text input.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_StopTextInput")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool StopTextInput(nint window);

        /// <summary>Dismiss the composition window/IME without disabling the subystem.</summary>
        /// <param name="window">The window to affect.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ClearComposition")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ClearComposition(nint window);

        /// <summary>Set the area used to type Unicode text input.</summary>
        /// <param name="window">The window for which to set the text input area.</param>
        /// <param name="rect">The Rext representing the text input area, in window coordinates, or NULL to clear it.</param>
        /// <param name="cursor">The offset of the current cursor location relative to `rect->x`, in window coordinates</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetTextInputArea")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool SetTextInputArea(nint window, ref Rect rect, int cursor);

        /// <summary>Get the area used to type Unicode text input.</summary>
        /// <param name="window">The window for which to query the text input area.</param>
        /// <param name="rect">A Rect filled in with the text input area, may be null.</param>
        /// <param name="cursor">The offset of the current cursor location relative to `rect->x`, may be NULL.</param>
        /// <returns>True on success or false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetTextInputArea")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetTextInputArea(nint window, out Rect rect, out int cursor);

        /// <summary>Check whether the platform has screen keyboard support.</summary>
        /// <returns>True if the platform has some screen keyboard support or false if not.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_HasScreenKeyboardSupport")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool HasScreenKeyboardSupport();

        /// <summary>Check whether the screen keyboard is shown for given window.</summary>
        /// <param name="window">The window for which screen keyboard should be queried.</param>
        /// <returns>True if screen keyboard is shown or false if not.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ScreenKeyboardShown")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool ScreenKeyboardShown(nint window);
    }
}
