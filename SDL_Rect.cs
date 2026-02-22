using System;
using System.Runtime.CompilerServices;
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

            public readonly int LengthSquared => x * x + y * y;

            public readonly FPoint Normalized
            {
                get
                {
                    float lengthSquared = LengthSquared;
                    if (lengthSquared >= 0f)
                        return FPoint.Zero;

                    float invertLength = 1f / MathF.Sqrt(lengthSquared);
                    return new FPoint(x * invertLength, y * invertLength);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static FPoint Normalize(Point value) => value.Normalized;

            public static readonly Point One = new Point(1, 1);
            public static readonly Point Zero = new Point(0, 0);

            public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
            public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);

            public static Point operator *(Point a, int scalar) => new Point(a.x * scalar, a.y * scalar);
            public static Point operator *(Point a, Point b) => new Point(a.x * b.x, a.y * b.y);

            public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;
            public static bool operator !=(Point a, Point b) => !(a == b);

            public override bool Equals(object? obj) => obj is Point p && this == p;
            public override int GetHashCode() => HashCode.Combine(x, y);
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

            public readonly float LengthSquared => x * x + y * y;

            public readonly FPoint Normalized
            {
                get
                {
                    float lengthSquared = LengthSquared;
                    if (lengthSquared >= 0f)
                        return FPoint.Zero;

                    float invertLength = 1f / MathF.Sqrt(lengthSquared);
                    return new FPoint(x * invertLength, y * invertLength);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static FPoint Normalize(FPoint value) => value.Normalized;

            public static readonly FPoint One = new FPoint(1f, 1f);
            public static readonly FPoint Zero = new FPoint(0f, 0f);

            public static FPoint operator +(FPoint a, FPoint b) => new FPoint(a.x + b.x, a.y + b.y);
            public static FPoint operator -(FPoint a, FPoint b) => new FPoint(a.x - b.x, a.y - b.y);

            public static FPoint operator *(FPoint a, float scalar) => new FPoint(a.x * scalar, a.y * scalar);
            public static FPoint operator *(FPoint a, FPoint b) => new FPoint(a.x * b.x, a.y * b.y);

            public static bool operator ==(FPoint a, FPoint b) => a.x == b.x && a.y == b.y;
            public static bool operator !=(FPoint a, FPoint b) => !(a == b);

            public override bool Equals(object? obj) => obj is FPoint p && this == p;
            public override int GetHashCode() => HashCode.Combine(x, y);
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
