using System;
namespace SDL3
{
    public static partial class SDL
    {
        public static partial class GPU
        {
            #region Enums

            public enum PrimitiveType
            {
                TriangleList,
                TriangleStrip,
                
                LineList,
                LineStrip,

                PointList
            }

            public enum LoadOp
            {
                Load,
                Clear,
                DontCare
            }

            public enum StoreOp
            {
                Store,
                DontCare,
                Resolve,
                ResolveAndStore
            }

            public enum IndexElementSize
            {
                /// <summary>16-bit index elements.</summary>
                Bit16,

                /// <summary>32-bit index elements.</summary>
                Bit32,
            }

            public enum TextureFormat
            {
                Invalid,

                // Unsigned Normalized Float Color Formats
                A8Unorm,
                R8Unorm,
                R8G8Unorm,
                R8G8B8A8Unorm,
                R16Unorm,
                R16G16Unorm,
                R16G16B16A16Unorm,
                R10G10B10A2Unorm,
                B5G6R5Unorm,
                B5G5R5A1Unorm,
                B4G4R4A4Unorm,
                R8G8R8A8Unorm,

                // Compressed Unsigned Normalized Float Color Formats
                BC1RgbaUnorm,
                BC2RgbaUnorm,
                BC3RgbaUnorm,
                BC4RUnorm,
                BC5RgUnorm,
                BC7RgbaUnorm,

                // Compressed Signed/Unsigned Float Color Formats
                BC6HRgbFloat,
                BC6HRgbUfloat,

                // Signed Normalized Float Color Formats
                R8Snorm,
                R8G8Snorm,
                R8G8B8A8Snorm,
                R16Snorm,
                R16G16Snorm,
                R16G16B16A16Snorm,

                // Signed Float Color Formats
                R16Float,
                R16G16Float,
                R16G16B16A16Float,
                R32Float,
                R32G32Float,
                R32G32B32A32Float,

                // Unsigned Float Color Formats
                R11G11B10Ufloat,

                // Unsigned Integer Color Formats
                R8Uint,
                R8G8Uint,
                R8G8B8A8Uint,
                R16Uint,
                R16G16Uint,
                R16G16B16A16Uint,
                R32Uint,
                R32G32Uint,
                R32G32B32A32Uint,

                // Signed Integer Color Formats
                R8Int,
                R8G8Int,
                R8G8B8A8Int,
                R16Int,
                R16G16Int,
                R16G16B16A16Int,
                R32Int,
                R32G32Int,
                R32G32B32A32Int,

                // SRGB Unsigned Normalized Color Formats
                R8G8B8A8UnormSrgb,
                B8G8R8A8UnormSrgb,

                // Compressed SRGB Unsigned Normalized Color Formats
                BC1RgbaUnormSrgb,
                BC2RgbaUnormSrgb,
                BC3RgbaUnormSrgb,
                BC7RgbaUnormSrgb,

                // Depth Formats
                D16Unorm,
                D24Unorm,
                D32Float,
                D24UnormS8Uint,
                D32FloatS8Uint,

                // Compressed ASTC Normalized Float Color Formats
                Astc4x4Unorm,
                Astc5x4Unorm,
                Astc5x5Unorm,
                Astc6x5Unorm,
                Astc6x6Unorm,
                Astc8x5Unorm,
                Astc8x6Unorm,
                Astc8x8Unorm,
                Astc10x5Unorm,
                Astc10x6Unorm,
                Astc10x8Unorm,
                Astc10x10Unorm,
                Astc12x10Unorm,
                Astc12x12Unorm,

                // Compressed SRGB ASTC Normalized Float Color Formats
                Astc4x4UnormSrgb,
                Astc5x4UnormSrgb,
                Astc5x5UnormSrgb,
                Astc6x5UnormSrgb,
                Astc6x6UnormSrgb,
                Astc8x5UnormSrgb,
                Astc8x6UnormSrgb,
                Astc8x8UnormSrgb,
                Astc10x5UnormSrgb,
                Astc10x6UnormSrgb,
                Astc10x8UnormSrgb,
                Astc10x10UnormSrgb,
                Astc12x10UnormSrgb,
                Astc12x12UnormSrgb,

                // Compressed ASTC Signed Float Color Formats
                Astc4x4Float,
                Astc5x4Float,
                Astc5x5Float,
                Astc6x5Float,
                Astc6x6Float,
                Astc8x5Float,
                Astc8x6Float,
                Astc8x8Float,
                Astc10x5Float,
                Astc10x6Float,
                Astc10x8Float,
                Astc10x10Float,
                Astc12x10Float,
                Astc12x12Float
            }

            [Flags]
            public enum TextureUsage : uint
            {
                Sampler = 1u << 0,
                ColorTarget = 1u << 1,
                DepthStencilTarget = 1u << 2,
                GraphicsStorageRead = 1u << 3,
                ComputeStorageRead = 1u << 4,
                ComputeStorageWrite = 1u << 5,
                ComputeStorageSimultaneousRW = 1u << 6
            }

            public enum TextureType
            {
                /// <summary>2D image.</summary>
                TwoDimensional,
                /// <summary>2D array image.</summary>
                TwoDimensionalArray,
                /// <summary>3D image.</summary>
                ThreeDimensional,
                /// <summary>Cube image.</summary>
                Cube,
                /// <summary>Cube array image.</summary>
                CubeArray
            }

            public enum SampleCount
            {
                /// <summary>No Mutlisampling</summary>
                One,
                /// <summary>MSAA 2x</summary>
                Two,
                /// <summary>MSAA 4x</summary>
                Four,
                /// <summary>MSAA 8x</summary>
                Eight
            }

            public enum CubeMapFace
            {
                PositiveX,
                NegativeX,
                PositiveY,
                NegativeY,
                PositiveZ,
                NegativeZ
            }

            [Flags]
            public enum BufferUsage : uint
            {
                Vertex = 1u << 0,
                Index = 1u << 1,
                Indirect = 1u << 2,
                GraphicsStorageRead = 1u << 3,
                ComputeStorageRead = 1u << 4,
                ComputerStorageWrite = 1u << 5
            }

            public enum TransferBufferUsage
            {
                Upload,
                Download
            }

            public enum ShaderStage
            {
                Vertex,
                Fragment
            }

            [Flags]
            public enum ShaderFormat : uint
            {
                Invalid = 0,
                /// <summary>Shaders for NDA's platforms.</summary>
                Private = 1u << 0,
                /// <summary>SPIR-V shaders for Vulkan.</summary>
                Spirv = 1u << 1,
                /// <summary>DXBC SM5_1 shaders for D3D12.</summary>
                Dxbc = 1u << 2,
                /// <summary>DXIL SM6_0 shaders for D3D12.</summary>
                Dxil = 1u << 3,
                /// <summary>MSL shaders for Metal.</summary>
                Msl = 1u << 4,
                /// <summary>Precompiled metallib shaders for Metal.</summary>
                Metallib = 1u << 5
            }

            public enum VertexElementFormat
            {
                Invalid,

                // 32-bit Signed Integers
                Int, Int2, Int3, Int4,

                // 32-bit Unsigned Integers
                UInt, UInt2, UInt3, UInt4,

                // 32-bit Floats
                Float, Float2, Float3, Float4,

                // 8-bit Signed Integers
                Byte2, Byte4,

                // 8-bit Unsigned Integers
                UByte2, UByte4,

                // 8-bit Signed Normalized
                Byte2Norm, Byte4Norm,

                // 8-bit Unsigned Normalized
                UByte2Norm, UByte4Norm,

                // 16-bit Signed Integers
                Short2, Short4,

                // 16-bit Unsigned Integers
                UShort2, UShort4,

                // 16-bit Signed Normalized
                Short2Norm, Short4Norm,

                // 16-bit Unsigned Normalized
                UShort2Norm, UShort4Norm,

                // 16-bit Floats
                Half2, Half4
            }

            public enum VertexInputRate
            {
                Vertex,
                Instance
            }

            public enum FillMode
            {
                Fill,
                Line
            }

            public enum CullMode
            {
                None,
                Front,
                Back
            }

            public enum FrontFace
            {
                CounterClockwise,
                Clockwise
            }

            public enum CompareOp
            {
                Invalid,
                Never,
                Less,
                Equal,
                LessOrEqual,
                Greater,
                NotEqual,
                GreaterOrEqual,
                Always
            }

            public enum StencilOp
            {
                Invalid,
                Keep,
                Zero,
                Replace,
                IncrementAndClamp,
                DecrementAndClamp,
                Invert,
                IncrementAndWrap,
                DecrementAndWrap
            }

            public enum BlendOp
            {
                Invalid,
                Add,
                Subtract,
                ReverseSubtract,
                Min,
                Max
            }

            public enum BlendFactor
            {
                Invalid,
                Zero,
                One,
                SrcColor,
                OneMinusSrcColor,
                DstColor,
                OneMinusDstColor,
                SrcAlpha,
                OneMinusSrcAlpha,
                DstAlpha,
                OneMinusDstAlpha,
                ConstantColor,
                OneMinusConstantColor,
                SrcAlphaSaturate
            }

            [Flags]
            public enum ColorComponent : byte
            {
                R = 1 << 0,
                G = 1 << 1,
                B = 1 << 2,
                A = 1 << 3
            }

            public enum Filter
            {
                Nearest,
                Linear
            }

            public enum SamplerMipmapMode
            {
                Nearest,
                Linear
            }

            public enum SamplerAddressMode
            {
                Repeat,
                MirroredRepeat,
                ClampToEdge
            }

            public enum PresentMode
            {
                VSync,
                Immediate,
                Mailbox
            }

            public enum SwapchainComposition
            {
                Sdr,
                SdrLinear,
                HdrExtendedLinear,
                Hdr10St2084
            }

            #endregion
        }
    }
}
