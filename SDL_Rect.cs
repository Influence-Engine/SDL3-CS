using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        /// <summary>Defines a point (using integers).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x; 
            public int y;
        }

        /// <summary>Defines a point (using floats).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FPoint
        {
            public float x;
            public float y;
        }

        /// <summary>A rectangle, with the origin at the upper left (using integers).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int x;
            public int y;
            public int w;
            public int h;
        }

        /// <summary>A rectangle, with the origin at the upper left (using floats).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FRect
        {
            public float x;
            public float y;
            public float w;
            public float h;
        }
    }
}
