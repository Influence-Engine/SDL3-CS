using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3
{
    /// <summary>
    /// Bindings for SDL_shadercross 3.x. A shader cross-compilation library for SDL3.<br></br>
    /// Supports SPIRV to MSL/HLSL/DXBC/DXIL/GPU shader, and HLSL to SPIRV/DXBC/DXIL.
    /// </summary>
    public static partial class ShaderCross
    {
#if DEBUG
        private const string nativeLibraryName = "SDL3_shadercross-Debug.dll";
#else
        private const string nativeLibraryName = "SDL3_shadercross.dll";
#endif

        public const int MajorVersion = 3;
        public const int MinorVersion = 0;
        public const int MicroVersion = 0;

        #region Property Name Constants

        public const string PropShaderDebugEnableBoolean = "SDL_shadercross.spirv.debug.enable";
        public const string PropShaderDebugNameString = "SDL_shadercross.spirv.debug.name";
        public const string PropShaderCullUnusedBindingBoolean = "SDL_shadercross.cull_unused_bindings";
        public const string PropSpirvPsslCompatibilityBoolean = "SDL_shadercross.spirv.pssl.compatibility";
        public const string PropSpirvMslVersionString = "SDL_shadercross.spirv.msl.version";

        #endregion

        #region Enums

        /// <summary>The scalar/vector component type of a shader I/O variable.</summary>
        public enum IOVarType
        {
            Unknown = 0,
            Int8,
            UInt8,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Float16,
            Float32,
            Float64
        }

        /// <summary>The pipeline stage a shader belongs to.</summary>
        public enum ShaderStage
        {
            Vertex,
            Fragment,
            Compute
        }

        #endregion

        #region Structs

        /// <summary>Metadata for a single shader input or output variable.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct IOVarMetadata
        {
            /// <summary>UTF-8 name of the variable.</summary>
            public nint name; // char*
            /// <summary>The location of the variable.</summary>
            public uint location;
            /// <summary>The scalar/vector component type.</summary>
            public IOVarType vectorType;
            /// <summary>The number of components in the vector type.</summary>
            public uint vectorSize;
        }

        /// <summary>Resource binding counts for a graphic shader stage.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GraphicsShaderResourceInfo
        {
            public uint numSamplers;
            public uint numStorageTextures;
            public uint numStorageBuffers;
            public uint numUniformBuffers;
        }

        /// <summary>Full reflection metadata for a graphics shader (vertex or fragment).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GraphicsShaderMetadata
        {
            public GraphicsShaderResourceInfo resourceInfo;
            public uint numInputs;
            /// <summary>Pointer to an array of <see cref="IOVarMetadata"/>. Length is <see cref="numInputs"/>.</summary>
            public nint inputs; // SDL_ShaderCross_IOVarMetadata*
            public uint numOutputs;
            /// <summary>Pointer to an array of <see cref="IOVarMetadata"/>. Length is <see cref="numOutputs"/>.</summary>
            public nint outputs; // SDL_ShaderCross_IOVarMetadata*
        }

        /// <summary>Full reflection metadata for a compute shader pipeline.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ComputePipelineMetadata
        {
            public uint numSamplers;
            public uint numReadonlyStorageTextures;
            public uint numReadonlyStorageBuffers;
            public uint numReadwriteStorageTextures;
            public uint numReadwriteStorageBuffers;
            public uint numUniformBuffers;
            public uint threadcountX;
            public uint threadcountY;
            public uint threadcountZ;
        }

        /// <summary>Describes a SPIRV shader to compile or transpile.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SPIRV_Info
        {
            /// <summary>Pointer to the SPIRV bytecode.</summary>
            public nint bytecode; // const Uint8*
            /// <summary>Length of the SPIRV bytecode in bytes.</summary>
            public nuint bytecodeSize;
            /// <summary>Pointer to a UTF-8 entry point function name string.</summary>
            public nint entrypoint; // const char*
            /// <summary>The shader stage.</summary>
            public ShaderStage shaderStage;
            /// <summary>Optional properties ID for extensions. Pass 0 if not needed.</summary>
            public uint props;
        }

        /// <summary>A single HLSL preprocessor define (name = value pair).</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HLSL_Define
        {
            /// <summary>The define name.</summary>
            public nint name; // char*
            /// <summary>Optional value for the define. Can be NULL.</summary>
            public nint value; // char*
        }

        /// <summary>Describe HLSL source to compile or transpile.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HLSL_Info
        {
            /// <summary>Pointer to the HLSL source code string.</summary>
            public nint source; // char*
            /// <summary>Pointer to the entry point function name (UTF-8).</summary>
            public nint entrypoint; // char*
            /// <summary>Optional include directory. Can be NULL.</summary>
            public nint includeDir; // char*
            /// <summary>
            /// Pointer to a NULL-terminated array of <see cref="HLSL_Define"/> structs. Can be NULL.<br></br>
            /// The array must end with a fully zeroed struct.
            /// </summary>
            public nint defines;
            /// <summary>The shader stage.</summary>
            public ShaderStage shaderStage;
            /// <summary>Optional properties ID for extension. Pass 0 if not needed.</summary>
            public uint props;
        }

        #endregion

        #region Init / Quit

        /// <summary>Initialize ShaderCross. Call once from a single thread before any other functions.</summary>
        /// <returns>True on success, false on failure.</returns>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_Init")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool Init();

        /// <summary>De-initialize ShaderCross. Call once from a single thred when done.</summary>
        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_Quit")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Quit();

        #endregion

        #region Format Support Queries

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_GetSPIRVShaderFormats")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetSPIRVShaderFormats();

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_GetHLSLShaderFormats")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
        public static partial uint GetHLSLShaderFormats();

        #endregion

        #region SPIRV to text / bytecode Transpilation

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_TranspileMSLFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint TranspileMSLFromSPIRV(SPIRV_Info* info);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_TranspileHLSLFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint TranspileHLSLFromSPIRV(SPIRV_Info* info);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileDXBCFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileDXBCFromSPIRV(SPIRV_Info* info, out nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileDXILFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileDXILFromSPIRV(SPIRV_Info* info, out nuint size);

        #endregion

        #region SPIRV to SDL GPU objects

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileGraphicsShaderFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileGraphicsShaderFromSPIRV(nint device, SPIRV_Info* info, GraphicsShaderResourceInfo* resourceInfo, uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileComputePipelineFromSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileComputePipelineFromSPIRV(nint device, SPIRV_Info* info, ComputePipelineMetadata* metadata, uint props);

        #endregion

        #region SPIRV Reflection

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_ReflectGraphicsSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial GraphicsShaderMetadata* ReflectGraphicsSPIRV(byte* bytecode, nuint bytecodeSize, uint props);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_ReflectComputeSPIRV")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial ComputePipelineMetadata* ReflectComputeSPIRV(byte* bytecode, nuint bytecodeSize, uint props);

        #endregion

        #region HLSL to bytecode

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileDXBCFromHLSL")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileDXBCFromHLSL(HLSL_Info* info, out nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileDXILFromHLSL")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileDXILFromHLSL(HLSL_Info* info, out nuint size);

        [LibraryImport(nativeLibraryName, EntryPoint = "SDL_ShaderCross_CompileSPIRVFromHLSL")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial nint CompileSPIRVFromHLSL(HLSL_Info* info, out nuint size);

        #endregion
    }
}
