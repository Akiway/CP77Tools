﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WolvenKit.CR2W.Types
{
    public static partial class Enums
    {
        public enum GpuWrapApiVertexPackingEStreamType
        {
            ST_Invalid,
            ST_PerVertex,
            ST_PerInstance,
            ST_Max
        }
        public enum ETextureRawFormat
        {
            TRF_Invalid,
            TRF_TrueColor,
            TRF_DeepColor,
            TRF_Grayscale,
            TRF_HDRFloat,
            TRF_HDRHalf,
            TRF_HDRFloatGrayscale,
            TRF_Grayscale_Font,
            TRF_R8G8,
            TRF_R32UI,
            TRF_AlphaGrayscale
        }

        public enum GpuWrapApieTextureGroup
        {
            TEXG_Generic_Color,
            TEXG_Generic_Grayscale,
            TEXG_Generic_Normal,
            TEXG_Generic_Data,
            TEXG_Generic_UI,
            TEXG_Generic_Font,
            TEXG_Generic_LUT,
            TEXG_Generic_MorphBlend,
            TEXG_Multilayer_Color,
            TEXG_Multilayer_Normal,
            TEXG_Multilayer_Grayscale,
            TEXG_Multilayer_Microblend
        }
        public enum GpuWrapApieTextureType
        {
            TEXTYPE_2D,
            TEXTYPE_CUBE,
            TEXTYPE_ARRAY,
            TEXTYPE_3D
        }
        public enum GpuWrapApieTextureFormat
        {
            TEXFMT_A8_Unorm,
            XFMT_A8,
            TEXFMT_R8_Unorm,
            XFMT_R8,
            TEXFMT_L8_Unorm,
            XFMT_L8,
            TEXFMT_R8G8_Unorm,
            XFMT_R8G8,
            TEXFMT_R8G8B8X8_Unorm,
            XFMT_R8G8B8X8,
            TEXFMT_R8G8B8A8_Unorm,
            XFMT_R8G8B8A8,
            TEXFMT_R8G8B8A8_Unorm_SRGB,
            TEXFMT_R8G8B8A8_Snorm,
            TEXFMT_R16_Unorm,
            TEXFMT_Uint_16_norm,
            TEXFMT_R16_Uint,
            TEXFMT_Uint_16,
            TEXFMT_R32_Uint,
            TEXFMT_Uint_32,
            TEXFMT_R32G32B32A32_Uint,
            TEXFMT_Uint_R32G32B32A32,
            TEXFMT_R32G32_Uint,
            TEXFMT_R16G16B16A16_Unorm,
            TEXFMT_R16G16B16A16_Uint,
            TEXFMT_R16G16_Uint,
            TEXFMT_R10G10B10A2_Unorm,
            XFMT_R10G10B10A2,
            TEXFMT_R16G16B16A16_Float,
            TEXFMT_Float_R16G16B16A16,
            TEXFMT_R11G11B10_Float,
            TEXFMT_Float_R11G11B10,
            TEXFMT_R16G16_Float,
            TEXFMT_Float_R16G16,
            TEXFMT_R32G32_Float,
            TEXFMT_Float_R32G32,
            TEXFMT_R32G32B32A32_Float,
            TEXFMT_Float_R32G32B32A32,
            TEXFMT_R32_Float,
            TEXFMT_Float_R32,
            TEXFMT_R16_Float,
            TEXFMT_Float_R16,
            TEXFMT_D24S8,
            TEXFMT_D32FS8,
            TEXFMT_D32F,
            TEXFMT_D16U,
            TEXFMT_BC1,
            TEXFMT_BC1_SRGB,
            TEXFMT_BC2,
            TEXFMT_BC2_SRGB,
            TEXFMT_BC3,
            TEXFMT_BC3_SRGB,
            TEXFMT_BC4,
            TEXFMT_BC5,
            TEXFMT_BC6H_UNSIGNED,
            XFMT_BC6H,
            TEXFMT_BC6H_SIGNED,
            TEXFMT_BC7,
            TEXFMT_BC7_SRGB,
            TEXFMT_R8_Uint,
            TEXFMT_R16G16_Unorm,
            TEXFMT_R16G16_Sint,
            TEXFMT_R16G16_Snorm,
            TEXFMT_B5G6R5_Unorm
        }
        public enum EMeshChunkFlags
        {
            MCF_RenderInScene,
            MCF_RenderInShadows,
            MCF_IsTwoSided,
            MCF_IsRayTracedEmissive,
            MCF_IsPrefabProxy,
        }

        public enum ECookingPlatform
        {
            PLATFORM_None,
            PLATFORM_PC,
            PLATFORM_XboxOne,
            PLATFORM_PS4,
            PLATFORM_WindowsServer,
            PLATFORM_LinuxServer
        }

        public enum GpuWrapApieIndexBufferChunkType
        {
            IBCT_IndexUInt,
            IBCT_IndexUShort,
            IBCT_Max
        }

        public enum GpuWrapApiVertexPackingePackingType
        {
            PT_Invalid,
            PT_Float1,
            PT_Float2,
            PT_Float3,
            PT_Float4,
            PT_Float16_2,
            PT_Float16_4,
            PT_UShort1,
            PT_UShort2,
            PT_UShort4,
            PT_UShort4N,
            PT_Short1,
            PT_Short2,
            PT_Short4,
            PT_Short4N,
            PT_UInt1,
            PT_UInt2,
            PT_UInt3,
            PT_UInt4,
            PT_Int1,
            PT_Int2,
            PT_Int3,
            PT_Int4,
            PT_Color,
            PT_UByte1,
            PT_UByte1F,
            PT_UByte4,
            PT_UByte4N,
            PT_Byte4N,
            PT_Dec4,
            PT_Index16,
            PT_Index32,
            PT_MAx,
        }

        public enum GpuWrapApiVertexPackingePackingUsage
        {
            PS_Invalid,
            PS_SysPosition,
            PS_Position,
            PS_Normal,
            PS_Tangent,
            PS_Binormal,
            PS_TexCoord,
            PS_Color,
            PS_SkinIndices,
            PS_SkinWeights,
            PS_DestructionIndices,
            PS_MultilayerPaint,
            PS_InstanceTransform,
            PS_InstanceLODParams,
            PS_InstanceSkinningData,
            PS_PatchSize,
            PS_PatchBias,
            PS_ExtraData,
            PS_VehicleDmgNormal,
            PS_VehicleDmgPosition,
            PS_PositionDelta,
            PS_LightBlockerIntensity,
            PS_BoneIndex,
            PS_Padding,
            PS_PatchOffset,
            PS_Max
        }

        public enum ETextureCompression
        {
            TCM_None,
            TCM_DXTNoAlpha,
            TCM_DXTAlpha,
            TCM_RGBE,
            TCM_Normalmap,
            TCM_Normals_DEPRECATED,
            TCM_Normals,
            TCM_NormalsHigh_DEPRECATED,
            TCM_NormalsHigh,
            TCM_NormalsGloss_DEPRECATED,
            TCM_NormalsGloss,
            TCM_TileMap,
            TCM_DXTAlphaLinear,
            TCM_QualityR,
            TCM_QualityRG,
            TCM_QualityColor,
            TCM_HalfHDR_Unsigned,
            TCM_HalfHDR,
            TCM_HalfHDR_Signed,
            TCM_Max
        }
    }
}
