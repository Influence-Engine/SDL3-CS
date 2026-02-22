using System;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>The types of events that can be delivered.</summary>
        public enum EventType : uint
        {
            First = 0,

            // Application Events
            Quit = 0x100,

            // Android/IOS/WinRT App Events
            Terminating,
            LowMemory,
            WillEnterBackground,
            DidEnterBackground,
            WillEnterForeground,
            DidEnterForeground,

            LocaleChanged,

            SystemThemeChanged,

            // Display Events
            DisplayOrientation = 0x151, // Display orientation has changed to data1
            DisplayAdded, // Display has been added to the System
            DisplayRemoved, // Display has been removed from the System
            DisplayMoved, // Display has changed position
            DisplayDesktopModeChanged,
            DisplayCurrentModeChanged,
            DisplayContentScaleChanged, // Display has changed content scale
            DisplayFirst = DisplayOrientation,
            DisplayLast = DisplayContentScaleChanged,

            // Window Events
            WindowShown = 0x202,
            WindowHidden,
            WindowExposed,
            WindowMoved,
            WindowResized,
            WindowPixelSizeChanged,
            WindowMetalViewResized,
            WindowMinimized,
            WindowMaximized,
            WindowRestored,
            WindowMouseEnter,
            WindowMouseLeave,
            WindowFocusGained,
            WindowFocusLost,
            WindowCloseRequested,
            WindowHitTest,
            WindowICCProfileChanged,
            WindowDisplayChanged,
            WindowDisplayScaleChanged,
            WindowSafeAreaChanged,
            WindowOccluded,
            WindowEnterFullscreen,
            WindowLeaveFullscreen,
            WindowDestroyed,

            WindowHDRStateChanged,
            WindowFirst = WindowShown,
            WindowLast = WindowHDRStateChanged,

            // Keyboard Events
            KeyDown = 0x300,
            KeyUp,
            TextEditing,
            TextInput,
            KeymapChanged,

            KeyboardAdded,
            KeyboardRemoved,
            TextEditingCandidates,

            // Mouse Events
            MouseMotion = 0x400,
            MouseButtonDown,
            MouseButtonUp,
            MouseWheel,
            MouseAdded,
            MouseRemoved,

            // Joystick Events
            JoystickAxisMotion = 0x600,
            JoystickBallMotion,
            JoystickHatMotion,
            JoystickButtonDown,
            JoystickButtonUp,
            JoystickAdded,
            JoystickRemoved,
            JoystickBatteryUpdated,
            JoystickUpdateComplete,

            // Gamepad Events
            GamepadAxisMotion = 0x650,
            GamepadButtonDown,
            GamepadButtonUp,
            GamepadAdded,
            GamepadRemoved,
            GamepadRemapped,
            GamepadTouchpadDown,
            GamepadTouchpadMotion,
            GamepadTouchpadUp,  
            GamepadSensorUpdate,
            GamepadUpdateComplete,
            GamepadSteamHandleUpdated,

            // Touch Events
            FingerDown = 0x700,
            FingerUp,
            FingerMotion,
            FingerCanceled,

            // Clipboard Events
            ClipboardUpdate = 0x900,

            // Drag and Drop Events
            DropFile = 0x1000,
            DropText,
            DropBegin,
            DropComplete,
            DropPosition,

            // Audio hotplug Events
            AudioDeviceAdded = 0x1100,
            AudioDeviceRemoved,
            AudioDeviceFormatChanged,

            // Sensor Events
            SensorUpdate = 0x1200,

            // Pressure-sensitive Pen Events
            PenProximityIn = 0x1300,
            PenProximityOut,
            PenDown,
            PenUp,
            PenButtonDown,
            PenButtonUp,
            PenMotion,
            PenAxis,

            // Camera hotplug Events
            CameraDeviceAdded = 0x1400,
            CameraDeviceRemoved,
            CameraDeviceApproved,
            CameraDeviceDenied,

            // Render Events
            RenderTargetsReset = 0x2000,
            RenderDeviceReset,
            RenderDeviceLost,

            Private0 = 0x400,
            Private1,
            Private2,
            Private3,

            // Internal Events
            PollSentinel = 0x7F00,

            User = 0x8000,

            /// <summary>Last event is used for bounding internal arrays </summary>
            Last = 0xFFFF,
        }

        /// <summary>Fields shared by every Event.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CommonEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
        }

        /// <summary>Display state change event data.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DisplayEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint displayID;
            public int data1;
            public int data2;
        }

        /// <summary>Window state change event data. </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public int data1;
            public int data2;
        }

        /// <summary>Keyboard device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which;
        }

        /// <summary>Keybard button event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint which;
            public ScanCode scancode;
            public KeyCode key;
            public KeyMod mod;
            public short raw;
            public bool down;
            public bool repeat;
        }

        public const int TextEditingEventSize = 32;

        /// <summary>Keyboard text editing event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TextEditingEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public fixed byte text[TextEditingEventSize];
            public int start;
            public int length;
        }

        /// <summary>Keyboard IME candidates event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TextEditingCandidatesEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public IntPtr candidates;
            public int numCandidates;
            public int selectedCandidate;
            public bool horizontal;
            byte padding1;
            byte padding2;
            byte padding3;
        }

        public const int TextInputEventSize = 32;

        /// <summary>Keyboard text input event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TextInputEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public fixed byte text[TextInputEventSize];
        }

        /// <summary>Mouse device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The mouse instance ID
        }

        /// <summary>Mouse motion event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseMotionEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint which; // The mouse instance ID
            public uint state;
            public float x;
            public float y;
            public float xRel;
            public float yRel;
        }

        /// <summary>Mouse button event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseButtonEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint which; // The mouse instance ID
            public byte button;
            public bool down;
            public byte clicks;
            byte padding;
            public float x;
            public float y;
        }

        /// <summary>Mouse wheel event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseWheelEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint which; // The mouse instance ID
            public float x; // The horizontal scroll amount
            public float y; // The vertical scroll amount
            public uint direction;
            public float mouseX; // X coordinate, relative to window
            public float mouseY; // Y coordinate, relative to window
            public int integerX; // The amount scrolled horizontally, accumulated to whole scroll "ticks"
            public int integerY; // The amount scrolled vertically, accumulated to whole scroll "ticks"
        }

        /// <summary>Joystick axis motion event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyAxisEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte axis;
            byte padding1;
            byte padding2;
            byte padding3;
            public short value; // The axis value
            byte padding4;
        }

        /// <summary>Joystick trackball motion event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyBallEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte ball;
            byte padding1;
            byte padding2;
            byte padding3;
            public short xRel; // The axis value
            public short yRel;
        }

        /// <summary>Joystick hat position change event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyHatEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte hat;
            public byte value;
            byte padding1;
            byte padding2;
        }

        /// <summary>Joystick button event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyButtonEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte button;
            public bool down;
            byte padding1;
            byte padding2;
        }

        /// <summary>Joystick device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
        }

        // TODO check JoyBatteryEvent again >.<
        /// <summary>Joystick battery level change event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JoyBatteryEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public uint state;
            public int percent;
        }

        /// <summary>Gamepad axis motion event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GamepadAxisEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte axis;
            byte padding1;
            byte padding2;
            byte padding3;
            public short value;
            ushort padding4;
        }

        /// <summary>Gamepad button event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GamepadButtonEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public byte button;
            public bool down;
            byte padding1;
            byte padding2;
        }

        /// <summary>Gamepad device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GamepadDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
        }

        /// <summary>Gamepad touchpad event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GamepadTouchpadEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public int touchpad;
            public int finger;
            public float x;
            public float y;
            public float pressure;
        }

        /// <summary>Gamepad sensor event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GamepadSensorEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The joystick instance ID
            public int sensor;
            public fixed float data[3];
            public ulong sensorTimestamp;
        }

        /// <summary>Audio device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct AudioDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // The Audio Device ID
            public bool recording;
            byte padding1;
            byte padding2;
            byte padding3;
        }

        // TODO Look at this again >.<
        /// <summary>Camera device event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CameraDeviceEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public long which;
        }

        /// <summary>Renderer event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RenderEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
        }

        /// <summary>Touch finger event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TouchFingerEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public long touchID; // The touch device id
            public long fingerID;
            public float x;
            public float y;
            public float dx;
            public float dy;
            public float pressure;
            public uint windowID;
        }

        // TODO Look at this again >-<
        /// <summary>Pressure-sensitive pen proximity event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PenProximityEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public long which;
        }

        // TODO Look at this again >-<
        /// <summary>Pressure-sensitive pen motion event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PenMotionEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public long which;
            public long penState;
            public float x;
            public float y;
        }

        // TODO Look at this again >-<
        /// <summary>Pressure-sensitive pen touch event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PenTouchEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public long which;
            public long penState;
            public float x;
            public float y;
            public bool eraser;
            public bool down;
        }

        // TODO Look at this again >-<
        /// <summary>Pressure-sensitive pen button event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PenButtonEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public long which;
            public long penState;
            public float x;
            public float y;
            public uint button;
            public bool down;
        }

        // TODO Look at this again >-<
        /// <summary>Pressure-sensitive pen pressure / angle event structure.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PenAxisEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public long which;
            public long penState;
            public float x;
            public float y;
            public long penAxis;
            public float value;
        }

        /// <summary>An event used to drop text or request a file open by the system.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DropEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public float x;
            public float y;
            public IntPtr source;
            public IntPtr data;
        }

        /// <summary>An event trigged when the clipboard contens have changed.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ClipboardEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public bool owner;
            public int nMimeTypes;
            public IntPtr mimeTypes;
        }

        /// <summary>Sensor Event.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SensorEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint which; // Sensor ID
            public fixed float data[6];
            public ulong sensorTimestamp;
        }

        /// <summary>The "quit requested" event.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct QuitEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
        }

        /// <summary>User defined event type.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UserEvent
        {
            public EventType type;
            uint reserved;
            public ulong timestamp;
            public uint windowID;
            public int code; // User defined event code
            public IntPtr data1; // User defined data pointer
            public IntPtr data2; // User defined data pointer
        }

        /// <summary>The structure for all events in SDL.</summary>
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct Event
        {
            [FieldOffset(0)] public EventType type;
            [FieldOffset(0)] public CommonEvent common;
            [FieldOffset(0)] public DisplayEvent display;
            [FieldOffset(0)] public WindowEvent window;
            [FieldOffset(0)] public KeyboardDeviceEvent kDevice;
            [FieldOffset(0)] public KeyboardEvent key;
            [FieldOffset(0)] public TextEditingEvent edit;
            [FieldOffset(0)] public TextEditingCandidatesEvent editCandidates;
            [FieldOffset(0)] public TextInputEvent text;
            [FieldOffset(0)] public MouseDeviceEvent mDevice;
            [FieldOffset(0)] public MouseMotionEvent motion;
            [FieldOffset(0)] public MouseButtonEvent button;
            [FieldOffset(0)] public MouseWheelEvent wheel;
            [FieldOffset(0)] public JoyDeviceEvent jDevice;
            [FieldOffset(0)] public JoyAxisEvent jAxis;
            [FieldOffset(0)] public JoyBallEvent jBall;
            [FieldOffset(0)] public JoyHatEvent jHat;
            [FieldOffset(0)] public JoyButtonEvent jButton;
            [FieldOffset(0)] public JoyBatteryEvent jBattery;
            [FieldOffset(0)] public GamepadDeviceEvent gDevice;
            [FieldOffset(0)] public GamepadAxisEvent gAxis;
            [FieldOffset(0)] public GamepadButtonEvent gButton;
            [FieldOffset(0)] public GamepadTouchpadEvent gTouchpad;
            [FieldOffset(0)] public GamepadSensorEvent gSensor;
            [FieldOffset(0)] public AudioDeviceEvent aDevice;
            [FieldOffset(0)] public CameraDeviceEvent cDevice;
            [FieldOffset(0)] public SensorEvent sensor;
            [FieldOffset(0)] public QuitEvent quit;
            [FieldOffset(0)] public UserEvent user;
            [FieldOffset(0)] public TouchFingerEvent tFinger;
            [FieldOffset(0)] public PenProximityEvent pProximity;
            [FieldOffset(0)] public PenTouchEvent pTouch;
            [FieldOffset(0)] public PenMotionEvent pMotion;
            [FieldOffset(0)] public PenButtonEvent pButton;
            [FieldOffset(0)] public PenAxisEvent pAxis;
            [FieldOffset(0)] public RenderEvent render;
            [FieldOffset(0)] public DropEvent drop;
            [FieldOffset(0)] public ClipboardEvent clipboard;

            [FieldOffset(0)] fixed byte padding[128];
        }

        /// <summary>Pump the event loop, gathering events from the input devices.</summary>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_PumpEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PumpEvents();

        /// <summary>The type of action to request from "PeepEvents."</summary>
        public enum EventAction
        {
            /// <summary>Add events to the back of the queue.</summary>
            AddEvent,

            /// <summary>Check but don't remove events from the queue front.</summary>
            PeekEvent,

            /// <summary>Retrieve/remove events from the front of the queue.</summary>
            GetEvent
        }

        /// <summary>Check the event queue for messages and optionally return them.</summary>
        /// <param name="events">Destination buffer for the retieved events.</param>
        /// <param name="numEvents">The number of events to add back to the event queue, or the maximum number of events to retrieve.</param>
        /// <param name="action">Action to take.</param>
        /// <param name="minType">The minimum value of the event type to be considered.</param>
        /// <param name="maxType">The maximum value of the event type to be considered.</param>
        /// <returns>The number of events actually stored or -1 on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_PeepEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PeepEvents(Event* events, int numEvents, EventAction action, EventType minType, EventType maxType);

        /// <summary>Check the event queue for messages and optionally return them.</summary>
        /// <param name="events">Destination buffer for the retieved events.</param>
        /// <param name="numEvents">The number of events to add back to the event queue, or the maximum number of events to retrieve.</param>
        /// <param name="action">Action to take.</param>
        /// <param name="minType">The minimum value of the event type to be considered.</param>
        /// <param name="maxType">The maximum value of the event type to be considered.</param>
        /// <returns>The number of events actually stored or -1 on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_PeepEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PeepEvents([Out] Event[] events, int numEvents, EventAction action, EventType minType, EventType maxType);


        /// <summary>Check for the existence of a certain event type in the event queue.</summary>
        /// <param name="type">The type of event to be queried.</param>
        /// <returns>True if events matching `type` are present, or false if events matching `type` are not present.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasEvent(EventType type);

        /// <summary>Check for the existence of certain event types in the event queue.</summary>
        /// <param name="minType">The minimum value of the event type to be queried.</param>
        /// <param name="maxType">The maximum value of the event type to be queried.</param>
        /// <returns>True if events with type >= to `minType` and Less or Equal to `maxType` are present, or false if not.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_HasEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasEvents(EventType minType, EventType maxType);

        /// <summary>Clear events of a specific type from the event queue.</summary>
        /// <param name="type">The type of event to be cleared.</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_FlushEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FlushEvent(EventType type);

        /// <summary>Clear events of a range of types from the event queue.</summary>
        /// <param name="minType">The low end of event type to be cleared. (inclusive)</param>
        /// <param name="maxType">The high end of event type to be cleared. (inclusive)</param>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_FlushEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FlushEvents(EventType minType, EventType maxType);

        /// <summary>Poll for currently pending events.</summary>
        /// <param name="_event">The Event structure to be filled with the next event from the queue, or NULL.</param>
        /// <returns>True if this got an event or false if there are none available.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_PollEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PollEvent(out Event _event); // grr underscore bad :(

        /// <summary>Wait indefinetly for the next available event.</summary>
        /// <param name="_event">The Event structure to be filled with the next event from the queue, or NULL.</param>
        /// <returns>True on success or false if there was an error while waiting for events.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_WaitEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WaitEvent(out Event _event); // grr underscore bad :(

        /// <summary>Wait until the specified timeout (in milliseconds) for the next available event.</summary>
        /// <param name="_event">The Event structure to be fulled with the next event from the queue, or NULL.</param>
        /// <param name="timeout">The maximum number of milliseconds to wait for the next available event.</param>
        /// <returns>True if this got an event or false if the timout elapsed without any events availabe.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_WaitEventTimeout", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WaitEventTimeout(out Event _event, int timeout); // grr underscore bad :(

        /// <summary>Add an event to the event queue.</summary>
        /// <param name="_event">The Event to be added to the queue.</param>
        /// <returns>True on success, false if the event was filtered or on failure.</returns>
        [DllImport(nativeLibraryName, EntryPoint = "SDL_PushEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PushEvent(ref Event _event); // grr underscore bad :(

        /// <summary>Function pointer used for callbacks that watch the event queue.</summary>
        /// <param name="userdata">What was passed as userdata.</param>
        /// <param name="_event">The Event that triggered the callback.</param>
        /// <returns>True to permit event to be added to the queue, and false to disallow it.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool EventFilter(IntPtr userdata, Event _event);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEventFilter(EventFilter filter, IntPtr userData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetEventFilter(EventFilter filter, ref IntPtr userData); // void*, Event*

        [DllImport(nativeLibraryName, EntryPoint = "SDL_AddEventWatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddEventWatch(EventFilter filter, IntPtr userData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RemoveEventWatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveEventWatch(EventFilter filter, IntPtr userData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_FilterEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FilterEvents(EventFilter filter, IntPtr userData);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_SetEventEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEventEnabled(EventType type, bool enabled);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_EventEnabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EventEnabled(EventType type);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_RegisterEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RegisterEvents(int numEvents);

        [DllImport(nativeLibraryName, EntryPoint = "SDL_GetWindowFromEvent", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowFromEvent(ref Event _event);
    }
}
