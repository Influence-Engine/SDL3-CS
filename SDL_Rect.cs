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

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public static readonly Point One = new Point(1, 1);
            public static readonly Point Zero = new Point(0, 0);
        }

        /// <summary>Defines a point (using floats).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FPoint
        {
            public float x;
            public float y;

            public FPoint(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public static readonly FPoint One = new FPoint(1f, 1f);
            public static readonly FPoint Zero = new FPoint(0f, 0f);
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
