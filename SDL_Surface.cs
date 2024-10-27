using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SDL3
{
    public static partial class SDL
    {

        public enum ScaleMode
        {
            Nearest,
            Linear,
        }

        public enum FlipMode
        {
            None,
            Horizontal,
            Vertical
        }
    }
}
