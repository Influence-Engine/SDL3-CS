using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

            #region Structs

            [StructLayout(LayoutKind.Sequential)]
            public struct Viewport
            {
                public float x;
                public float y;
                public float w;
                public float h;
                public float minDepth;
                public float maxDepth;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TextureTransferInfo
            {
                public IntPtr transferBuffer; // SDL_GPUTransferBuffer*
                public uint offset;
                public uint pixelsPerRow;
                public uint rowsPerLayer;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TransferBufferLocation
            {
                public IntPtr transferBuffer; // SDL_GPUTransferBuffer*
                public uint offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TextureLocation
            {
                public IntPtr texture; // SDL_GPUTexture*
                public uint mipLevel;
                public uint layer;
                public uint x;
                public uint y;
                public uint z;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TextureRegion
            {
                public IntPtr texture; // SDL_GPUTexture*
                public uint mipLevel;
                public uint layer;
                public uint x;
                public uint y;
                public uint z;
                public uint w;
                public uint h;
                public uint d;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BlitRegion
            {
                public IntPtr texture; // SDL_GPUTexture*
                public uint mipLevel;
                public uint layerOrDepthPlane;
                public uint x;
                public uint y;
                public uint w;
                public uint h;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BufferLocation
            {
                public IntPtr buffer; // SDL_GPUBuffer*
                public uint offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BufferRegion
            {
                public IntPtr buffer; // SDL_GPUBuffer*
                public uint offset;
                public uint size;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct IndirectDrawCommand
            {
                public uint numVertices;
                public uint numInstances;
                public uint firstVertex;
                public uint firstInstance;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct IndexedIndirectDrawCommand
            {
                public uint numIndices;
                public uint numInstances;
                public uint firstIndex;
                public int vertexOffset;
                public uint firstInstance;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct IndirectDispatchCommand
            {
                public uint groupcountX;
                public uint groupcountY;
                public uint groupcountZ;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct SamplerCreateInfo
            {
                public Filter minFilter;
                public Filter magFilter;
                public SamplerMipmapMode mipmapMode;
                public SamplerAddressMode addressModeU;
                public SamplerAddressMode addressModeV;
                public SamplerAddressMode addressModeW;
                public float mipLODBias;
                public float maxAnisotropy;
                public CompareOp compareOp;
                public float minLOD;
                public float maxLOD;
                [MarshalAs(UnmanagedType.I1)] public bool enableAnisotropy;
                [MarshalAs(UnmanagedType.I1)] public bool enableCompare;

                byte _pad1;
                byte _pad2;

                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct VertexBufferDescription
            {
                public uint slot;
                public uint pitch;
                public VertexInputRate inputRate;
                public uint instanceStepRate;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct VertexAttribute
            {
                public uint location;
                public uint bufferSlot;
                public VertexElementFormat format;
                public uint offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct VertexInputState
            {
                public IntPtr vertexBufferDescription;
                public uint numVertexBuffers;
                public IntPtr vertexAttributes;
                public uint numVertexAttributes;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct StencilIOpState
            {
                public StencilOp failOp;
                public StencilOp passOp;
                public StencilOp depthFailOp;
                public CompareOp compareOp;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ColorTargetBlendState
            {
                public BlendFactor srcColorBlendfactor;
                public BlendFactor dstColorBlendFactor;
                public BlendOp colorBlendOp;
                public BlendFactor srcAlphaBlendfactor;
                public BlendFactor dstAlphaBlendfactor;
                public BlendOp alphaBlendOp;
                public ColorComponent colorWriteMask;
                [MarshalAs(UnmanagedType.I1)] public bool enableBlend;
                [MarshalAs(UnmanagedType.I1)] public bool enableColorWriteMask;

                byte pad1;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ShaderCreateInfo
            {
                public nuint codeSize;
                public IntPtr code; // const uint8
                public IntPtr entrypoint; // const char*
                public ShaderFormat format;
                public ShaderStage stage;
                public uint numSamplers;
                public uint numStorageTextures;
                public uint numStorageBuffers;
                public uint numUniformBuffesr;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TextureCreateInfo
            {
                public TextureType type;
                public TextureFormat format;
                public TextureUsage usage;
                public uint width;
                public uint height;
                public uint layerCountOrDepth;
                public uint numLevels;
                public SampleCount sampleCount;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BufferCreateInfo
            {
                public BufferUsage usage;
                public uint size;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TransferBufferCreateInfo
            {
                public TransferBufferUsage usage;
                public uint size;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct RasterizerState
            {
                public FillMode fillMode;
                public CullMode cullMode;
                public FrontFace frontFace;
                public float depthBiasConstantFactor;
                public float depthBiasClamp;
                public float depthBiasSlopeFactor;
                [MarshalAs(UnmanagedType.I1)] public bool enableDepthBias;
                [MarshalAs(UnmanagedType.I1)] public bool enableDepthClip;

                byte pad1;
                byte pad2;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MultisampleState
            {
                public SampleCount sampelCount;
                public uint sampleMask;
                [MarshalAs(UnmanagedType.I1)] public bool enableMask;
                [MarshalAs(UnmanagedType.I1)] public bool enableAlphaToCoverage;

                byte pad1;
                byte pad2;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DepthStencilState
            {
                public CompareOp compareOp;
                public StencilIOpState backStencilState;
                public StencilIOpState frontStencilState;
                public byte compareMask;
                public byte writeMask;
                [MarshalAs(UnmanagedType.I1)] public bool enableDepthTest;
                [MarshalAs(UnmanagedType.I1)] public bool enableDepthWrite;
                [MarshalAs(UnmanagedType.I1)] public bool enableStencilTest;

                byte pad1;
                byte pad2;
                byte pad3;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ColorTargetDescription
            {
                public TextureFormat format;
                public ColorTargetBlendState blendState;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct GraphicsPipelineTargetInfo
            {
                public IntPtr colorTargetDescription;
                public uint numColorTargets;
                public TextureFormat depthStencilFormat;
                [MarshalAs(UnmanagedType.I1)] public bool hasDepthStencilTarget;

                byte pad1;
                byte pad2;
                byte pad3;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct GraphicsPipelineCreateInfo
            {
                public IntPtr vertexShader; // SDL_GPUShader*
                public IntPtr fragmentShader; // SDL_GPUShader*
                public VertexInputState vertexInputState;
                public PrimitiveType primitiveType;
                public RasterizerState rasterizerState;
                public MultisampleState multisampleState;
                public DepthStencilState depthStencilState;
                public GraphicsPipelineTargetInfo targetInfo;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ComputePipelineCreateInfo
            {
                public nuint codeSize;
                public IntPtr code; // const uint8*
                public IntPtr entrypoint; // const char*
                public ShaderFormat format;
                public uint numSamplers;
                public uint numReadonlyStorageTextures;
                public uint numReadonlyStorageBuffers;
                public uint numReadwriteStorageTextures;
                public uint numReadwriteStorageBuffers;
                public uint numUniformBuffers;
                public uint threadCountX;
                public uint threadCountY;
                public uint threadCountZ;
                public uint props;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ColorTargetInfo
            {
                public IntPtr texture; // SDL_GPUTexture*
                public uint mipLevel;
                public uint layerOrDepthPlane;
                public FColor clearColor;
                public LoadOp loadOp;
                public StoreOp storeOp;
                public IntPtr resolveTexture; // SDL_GPUTexture*
                public uint resolveMipLevel;
                public uint resolveLayer;
                [MarshalAs(UnmanagedType.I1)] public bool cycle;
                [MarshalAs(UnmanagedType.I1)] public bool cycleResolveTexture;

                byte pad1;
                byte pad2;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DepthStencilTargetInfo
            {
                public IntPtr texture; // SDL_GPUTexture*
                public float clearDepth;
                public LoadOp loadOp;
                public StoreOp storeOp;
                public LoadOp stencilLoadOp;
                public StoreOp stenctilStoreOp;
                [MarshalAs(UnmanagedType.I1)] public bool cycle;
                public byte clearStencil;
                public byte mipLevel;
                public byte layer;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BlitInfo
            {
                public BlitRegion source;
                public BlitRegion destination;
                public LoadOp loadOp;
                public FColor clearColor;
                public FlipMode flipMode;
                public Filter filter;
                [MarshalAs(UnmanagedType.I1)] public bool cycle;

                byte pad1;
                byte pad2;
                byte pad3;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BufferBinding
            {
                public IntPtr buffer; // SDL_GPUBuffer*
                public uint offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TextureSamplerBinding
            {
                public IntPtr texture; // SDL_GPUTexture*
                public IntPtr sampler; // SDL_GPUSampler*
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct StorageBufferReadWriteBinding
            {
                public IntPtr buffer; // SDL_GPUBuffer*
                [MarshalAs(UnmanagedType.I1)] public bool cycle;

                byte pad1;
                byte pad2;
                byte pad3;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct StorageTextureReadWriteBinding
            {
                public IntPtr texture; // SDL_GPUTexture*
                public uint mipLevel;
                public uint layer;
                [MarshalAs(UnmanagedType.I1)] public bool cycle;

                byte pad1;
                byte pad2;
                byte pad3;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct VulkanOptions
            {
                public uint vulkanApiVersion;
                public IntPtr featureList;
                public IntPtr vulkan10PhysicalDeviceFeatures;
                public uint deviceExtensionCount;
                public IntPtr deviceExtensionNames; // const char**
                public uint instanceExtensionCount;
                public IntPtr instaceExtensionNames; // const char**
            }

            #endregion

            #region Constant Strings

            public const string Device_Create_DebugMode_Boolean = "SDL.gpu.device.create.debugmode";
            public const string Device_Create_PreferLowPower_Boolean = "SDL.gpu.create.preferlowpower";
            public const string Device_Create_Verbose_Boolean = "SDL.gpu.device.create.verbose";
            public const string Device_Create_Name_String = "SDL.gpu.device.create.name";
            public const string Device_Create_Feature_Clip_Distance_Boolean = "SDL.gpu.device.create.feature.clip_distance";
            public const string Device_Create_Feature_Depth_Clamping_Boolean = "SDL.gpu.device.create.feature.depth_clamping";
            public const string Device_Create_Feature_Indirect_Draw_First_Instance_Boolean = "SDL.gpu.device.create.feature.indirect_draw_first_instance";
            public const string Device_Create_Feature_Anisotropy_Boolean = "SDL.gpu.device.create.feature.anisotropy";
            public const string Device_Create_Shaders_Private_Boolean = "SDL.gpu.device.create.shaders.private";
            public const string Device_Create_Shaders_Spirv_Boolean = "SDL.gpu.device.create.shaders.spirv";
            public const string Device_Create_Shaders_Dxbc_Boolean = "SDL.gpu.device.create.shaders.dxbc";
            public const string Device_Create_Shaders_Dxil_Boolean = "SDL.gpu.device.create.shaders.dxil";
            public const string Device_Create_Shaders_Msl_Boolean = "SDL.gpu.device.create.shaders.msl";
            public const string Device_Create_Shaders_Metallib_Boolean = "SDL.gpu.device.create.shaders.metallib";
            public const string Device_Create_D3D12_Allow_Fewer_Resource_Slots_Boolean = "SDL.gpu.device.create.d3d12.allowtier1resourcebinding";
            public const string Device_Create_D3D12_Semantic_Name_String = "SDL.gpu.device.create.d3d12.semantic";
            public const string Device_Create_D3D12_Agility_Sdk_Version_Number = "SDL.gpu.device.create.d3d12.agility_sdk_version";
            public const string Device_Create_D3D12_Agility_Sdk_Path_String = "SDL.gpu.device.create.d3d12.agility_sdk_path";
            public const string Device_Create_Vulkan_Require_Hardware_Acceleration_Boolean = "SDL.gpu.device.create.vulkan.requirehardwareacceleration";
            public const string Device_Create_Vulkan_Options_Pointer = "SDL.gpu.device.create.vulkan.options";
            public const string Device_Create_Metal_Allow_MacFamily1_Boolean = "SDL.gpu.device.create.metal.allowmacfamily1";

            // To add
            // XR

            public const string Device_Name_String = "SDL.gpu.device.name";
            public const string Device_Driver_Name_String = "SDL.gpu.device.driver_name";
            public const string Device_Driver_Version_String = "SDL.gpu.device.driver_version";
            public const string Device_Driver_Info_String = "SDL.gpu.device.driver_info";

            public const string ComputerPipeline_Create_Name_String = "SDL.gpu.computepipeline.create.name";
            public const string GraphicsPipeline_Create_Name_String = "SDL.gpu.graphicspipeline.create.name";
            public const string Sampler_Create_Name_String = "SDL.gpu.sampler.create.name";
            public const string Shader_Create_Name_String = "SDL.gpu.shader.create.name";
            public const string Buffer_Create_Name_String = "SDL.gpu.buffer.create.name";
            public const string TransferBuffer_Create_Name_String = "SDL.gpu.transferbuffer.create.name";

            public const string Texture_Create_D3D12_Clear_R_Float = "SDL.gpu.texture.create.d3d12.clear.r";
            public const string Texture_Create_D3D12_Clear_G_Float = "SDL.gpu.texture.create.d3d12.clear.g";
            public const string Texture_Create_D3D12_Clear_B_Float = "SDL.gpu.texture.create.d3d12.clear.b";
            public const string Texture_Create_D3D12_Clear_A_Float = "SDL.gpu.texture.create.d3d12.clear.a";
            public const string Texture_Create_D3D12_Clear_Depth_Float = "SDL.gpu.texture.create.d3d12.clear.depth";
            public const string Texture_Create_D3D12_Clear_Stencil_Number = "SDL.gpu.texture.create.d3d12.clear.stencil";
            public const string Texture_Create_Name_String = "SDL.gpu.texture.create.name";

            #endregion

            #region Device

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GPUSupportsShaderFormats")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GPUSupportsShaderFormats(ShaderFormat formatFlags, [MarshalAs(UnmanagedType.LPUTF8Str)] string? name);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GPUSupportsProperties")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.I1)]
            public static partial bool GPUSupportsProperties(uint props);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUDevice")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUDevice(ShaderFormat formatFlags, [MarshalAs(UnmanagedType.I1)] bool debugMode, [MarshalAs(UnmanagedType.LPUTF8Str)] string? name);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUDeviceWithProperties")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUDeviceWithProperties(uint props);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DestroyGPUDevice")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr DestroyGPUDevice(IntPtr device);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetNumGPUDrivers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial int GetNumGPUDrivers();

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGPUDriver")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.LPUTF8Str)]
            public static partial string? GetGPUDriver(int index);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGPUDeviceDriver")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            [return: MarshalAs(UnmanagedType.LPUTF8Str)]
            public static partial string? GetGPUDeviceDriver(IntPtr device);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGPUShaderFormats")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial ShaderFormat GetGPUShaderFormats(IntPtr device);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_GetGPUDeviceProperties")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial uint GetGPUDeviceProperties(IntPtr device);

            #endregion

            #region State Creation

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUComputePipeline")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUComputePipeline(IntPtr device, in ComputePipelineCreateInfo createInfo);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUGraphicsPipeline")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUGraphicsPipeline(IntPtr device, in GraphicsPipelineCreateInfo createInfo); 

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUSampler")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUSampler(IntPtr device, in SamplerCreateInfo createInfo); 

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUShader")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUShader(IntPtr device, in ShaderCreateInfo createInfo);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUTexture")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUTexture(IntPtr device, in TextureCreateInfo createInfo);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUBuffer(IntPtr device, in BufferCreateInfo createInfo);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_CreateGPUTransferBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr CreateGPUTransferBuffer(IntPtr device, in TransferBufferCreateInfo createInfo);

            #endregion

            #region Debug Naming

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUBufferName")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUBufferName(IntPtr device, IntPtr buffer, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUTextureName")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUTextureName(IntPtr device, IntPtr texture, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_InsertGPUDebugLabel")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void InsertGPUDebugLabel(IntPtr commandBuffer, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_PushGPUDebugGroup")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void PushGPUDebugGroup(IntPtr commandBuffer, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_PopGPUDebugGroup")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void PopGPUDebugGroup(IntPtr commandBuffer);

            #endregion

            #region Disposal

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUTexture")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUTexture(IntPtr device, IntPtr texture);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUSampler")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUSampler(IntPtr device, IntPtr sampler);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUBuffer(IntPtr device, IntPtr buffer);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUTransferBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUTransferBuffer(IntPtr device, IntPtr transferBuffer);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUComputePipeline")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUComputePipeline(IntPtr device, IntPtr computePipeline);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUShader")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUShader(IntPtr device, IntPtr shader);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ReleaseGPUGraphicsPipeline")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void ReleaseGPUGraphicsPipeline(IntPtr device, IntPtr graphicsPipeline);


            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_AcquireGPUCommandBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr AcquireGPUCommandBuffer(IntPtr device);

            #endregion

            #region Uniform Data

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_PushGPUVertexUniformData")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void PushGPUVertexUniformData(IntPtr commandBuffer, uint slotIndex, IntPtr data, uint length);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_PushGPUFragmentUniformData")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void PushGPUFragmentUniformData(IntPtr commandBuffer, uint slotIndex, IntPtr data, uint length);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_PushGPUComputeUniformData")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void PushGPUComputeUniformData(IntPtr commandBuffer, uint slotIndex, IntPtr data, uint length);

            #endregion

            #region Graphics State

            #region BeginGPURenderPass

            /// <summary>Begins a render pass on a command buffer.</summary>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_BeginGPURenderPass")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr BeginGPURenderPass(IntPtr commandBuffer, in ColorTargetInfo colorTargetInfos, uint numColorTargets, IntPtr depthStencilTargetInfo);

            /// <inheritdoc cref="BeginGPURenderPass(nint, in ColorTargetInfo, uint, nint)"/>
            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_BeginGPURenderPass")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr BeginGPURenderPassWithDepth(IntPtr commandBuffer, ref ColorTargetInfo colorTargetInfos, uint numColorTargets, ref DepthStencilTargetInfo depthStencilTargetInfo);

            /// <inheritdoc cref="BeginGPURenderPass(nint, in ColorTargetInfo, uint, nint)"/>
            /// <remarks>Use this overload when no depth-stencil target is needed.</remarks>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe IntPtr BeginGPURenderPass(IntPtr commandBuffer, ReadOnlySpan<ColorTargetInfo> colorTargets)
            {
                fixed (ColorTargetInfo* ptr = colorTargets)
                {
                    return BeginGPURenderPass(commandBuffer, ref *ptr, (uint)colorTargets.Length, IntPtr.Zero);
                }
            }

            /// <inheritdoc cref="BeginGPURenderPass(nint, in ColorTargetInfo, uint, nint)"/>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe IntPtr BeginGPURenderPass(IntPtr commandBuffer, ReadOnlySpan<ColorTargetInfo> colorTargets, in DepthStencilTargetInfo depthStencilTargetInfo)
            {
                fixed(ColorTargetInfo* cPtr = colorTargets)
                {
                    fixed(DepthStencilTargetInfo* dPtr = &depthStencilTargetInfo)
                    {
                        return BeginGPURenderPassWithDepth(commandBuffer, ref *cPtr, (uint)colorTargets.Length, ref *dPtr);
                    }
                }
            }

            #endregion

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_BindGPUGraphicsPipeline")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void BindGPUGraphicsPipeline(IntPtr renderPass, IntPtr graphicsPipeline);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUViewport")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUViewport(IntPtr renderPass, in Viewport viewport);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUScissor")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUScissor(IntPtr renderPass, in Rect scissor);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetBlendConstants")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUBlendConstants(IntPtr renderPass, FColor blendConstants);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUStencilReference")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUStencilReference(IntPtr renderPass, byte reference);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUVertexBuffers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUVertexBuffers(IntPtr renderPass, uint firstSlot, in BufferBinding bindings, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUIndexBuffer")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUIndexBuffer(IntPtr renderPass, in BufferBinding binding, IndexElementSize indexElementSize);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUVertexSamplers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUVertexSamplers(IntPtr renderPass, uint firstSlot, in TextureSamplerBinding textureSamplerBinding, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUVertexStorageTextures")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUVertexStorageTextures(IntPtr renderPass, uint firstSlot, in IntPtr storageTextures, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUVertextStorageBuffers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUVertexStorageBuffers(IntPtr renderPass, uint firstSlot, in IntPtr storageBuffers, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUFragmentSamplers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUFragmentSamplers(IntPtr renderPass, uint firstSlot, in TextureSamplerBinding textureSamplerBinding, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUFragmentStorageTextures")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUFragmentStorageTextures(IntPtr renderPass, uint firstSlot, in IntPtr storageTextures, uint numBindings);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_SetGPUFragmentStorageBuffers")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void SetGPUFragmentStorageBuffers(IntPtr renderPass, uint firstSlot, in IntPtr storageBuffers, uint numBindings);

            #endregion

            #region Drawing

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DrawGPUIndexedPrimitives")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void DrawGPUIndexedPrimitives(IntPtr renderPass, uint numIndex, uint numInstances, uint firstIndex, int vertexOffset, uint firstInstance);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DrawGPUPrimitives")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void DrawGPUPrimitives(IntPtr renderPass, uint numVertices, uint numInstances, uint firstVertex, uint firstInstance);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DrawGPUPrimitivesIndirect")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void DrawGPUPrimitivesIndirect(IntPtr renderPass, IntPtr buffer, uint offset, uint drawCount);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_DrawGPUIndexedPrimitivesIndirect")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void DrawGPUIndexedPrimitivesIndirect(IntPtr renderPass, IntPtr buffer, uint offset, uint drawCount);

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_EndGPURenderPass")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial void EndGPURenderPass(IntPtr renderPass);

            #endregion

            #region Compute Pass

            [LibraryImport(nativeLibraryName, EntryPoint = "SDL_BeginGPUComputePass")]
            [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
            public static partial IntPtr BeginGPUComputePass(IntPtr commandBuffer, in StorageTextureReadWriteBinding storageTextureBindings, uint numStorageTextureBindings, in StorageBufferReadWriteBinding storageBufferBindings, uint numStorageBufferBindings);


            #endregion
        }
    }
}
