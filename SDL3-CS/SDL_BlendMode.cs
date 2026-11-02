using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    public static partial class SDL
    {
        public enum BlendMode : uint
        {
            None = 0x00u,

            Blend = 0x01u,
            BlendPremultiplied = 0x10u,
            Add = 0x02u,
            AddPremultiplied = 0x20u,
            Mod = 0x04u,
            Mul = 0x08u,

            Invalid = 0x7FFFFFFFu
        }

        public enum BlendOperation
        {
            Add = 1,
            Subtract,
            RevSubtract,
            Minimum,
            Maximum
        }

        public enum BlendFactor
        {
            Zero = 1,
            One,
            SrcColor,
            OneMinusSrcColor,
            SrcAlpha,
            OneMinusSrcAlpha,
            DstColor,
            OneMinusDstColor,
            DstAlpha,
            OneMinusDstAlpha
        }

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ComposeCustomBlendMode")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial BlendMode ComposeCustomBlendMode(BlendFactor srcColorFactor, BlendFactor dstColorFactor, BlendOperation colorOperation, BlendFactor srcAlphaFactor, BlendFactor dstAlphaFactor, BlendOperation alphaOperation);
    }
}
