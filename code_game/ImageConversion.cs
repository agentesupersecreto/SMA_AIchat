using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine
{
	// Token: 0x02000002 RID: 2
	[NativeHeader("Modules/ImageConversion/ScriptBindings/ImageConversion.bindings.h")]
	public static class ImageConversion
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002067 File Offset: 0x00000267
		public static bool EnableLegacyPngGammaRuntimeLoadBehavior
		{
			get
			{
				return ImageConversion.GetEnableLegacyPngGammaRuntimeLoadBehavior();
			}
			set
			{
				ImageConversion.SetEnableLegacyPngGammaRuntimeLoadBehavior(value);
			}
		}

		// Token: 0x06000003 RID: 3
		[NativeMethod(Name = "ImageConversionBindings::GetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetEnableLegacyPngGammaRuntimeLoadBehavior();

		// Token: 0x06000004 RID: 4
		[NativeMethod(Name = "ImageConversionBindings::SetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetEnableLegacyPngGammaRuntimeLoadBehavior(bool enable);

		// Token: 0x06000005 RID: 5
		[NativeMethod(Name = "ImageConversionBindings::EncodeToTGA", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeToTGA(this Texture2D tex);

		// Token: 0x06000006 RID: 6
		[NativeMethod(Name = "ImageConversionBindings::EncodeToPNG", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeToPNG(this Texture2D tex);

		// Token: 0x06000007 RID: 7
		[NativeMethod(Name = "ImageConversionBindings::EncodeToJPG", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeToJPG(this Texture2D tex, int quality);

		// Token: 0x06000008 RID: 8 RVA: 0x00002074 File Offset: 0x00000274
		public static byte[] EncodeToJPG(this Texture2D tex)
		{
			return tex.EncodeToJPG(75);
		}

		// Token: 0x06000009 RID: 9
		[NativeMethod(Name = "ImageConversionBindings::EncodeToEXR", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeToEXR(this Texture2D tex, Texture2D.EXRFlags flags);

		// Token: 0x0600000A RID: 10 RVA: 0x00002090 File Offset: 0x00000290
		public static byte[] EncodeToEXR(this Texture2D tex)
		{
			return tex.EncodeToEXR(Texture2D.EXRFlags.None);
		}

		// Token: 0x0600000B RID: 11
		[NativeMethod(Name = "ImageConversionBindings::LoadImage", IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool LoadImage([NotNull("ArgumentNullException")] this Texture2D tex, byte[] data, bool markNonReadable);

		// Token: 0x0600000C RID: 12 RVA: 0x000020AC File Offset: 0x000002AC
		public static bool LoadImage(this Texture2D tex, byte[] data)
		{
			return tex.LoadImage(data, false);
		}

		// Token: 0x0600000D RID: 13
		[FreeFunction("ImageConversionBindings::EncodeArrayToTGA", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeArrayToTGA(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U);

		// Token: 0x0600000E RID: 14
		[FreeFunction("ImageConversionBindings::EncodeArrayToPNG", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeArrayToPNG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U);

		// Token: 0x0600000F RID: 15
		[FreeFunction("ImageConversionBindings::EncodeArrayToJPG", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeArrayToJPG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, int quality = 75);

		// Token: 0x06000010 RID: 16
		[FreeFunction("ImageConversionBindings::EncodeArrayToEXR", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] EncodeArrayToEXR(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None);

		// Token: 0x06000011 RID: 17 RVA: 0x000020C8 File Offset: 0x000002C8
		public unsafe static NativeArray<byte> EncodeNativeArrayToTGA<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U) where T : struct
		{
			int num = input.Length * UnsafeUtility.SizeOf<T>();
			void* ptr = ImageConversion.UnsafeEncodeNativeArrayToTGA(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref num, format, width, height, rowBytes);
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(ptr, num, Allocator.Persistent);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002108 File Offset: 0x00000308
		public unsafe static NativeArray<byte> EncodeNativeArrayToPNG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U) where T : struct
		{
			int num = input.Length * UnsafeUtility.SizeOf<T>();
			void* ptr = ImageConversion.UnsafeEncodeNativeArrayToPNG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref num, format, width, height, rowBytes);
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(ptr, num, Allocator.Persistent);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002148 File Offset: 0x00000348
		public unsafe static NativeArray<byte> EncodeNativeArrayToJPG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, int quality = 75) where T : struct
		{
			int num = input.Length * UnsafeUtility.SizeOf<T>();
			void* ptr = ImageConversion.UnsafeEncodeNativeArrayToJPG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref num, format, width, height, rowBytes, quality);
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(ptr, num, Allocator.Persistent);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002188 File Offset: 0x00000388
		public unsafe static NativeArray<byte> EncodeNativeArrayToEXR<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None) where T : struct
		{
			int num = input.Length * UnsafeUtility.SizeOf<T>();
			void* ptr = ImageConversion.UnsafeEncodeNativeArrayToEXR(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref num, format, width, height, rowBytes, flags);
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(ptr, num, Allocator.Persistent);
		}

		// Token: 0x06000015 RID: 21
		[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToTGA", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void* UnsafeEncodeNativeArrayToTGA(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U);

		// Token: 0x06000016 RID: 22
		[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToPNG", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void* UnsafeEncodeNativeArrayToPNG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U);

		// Token: 0x06000017 RID: 23
		[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToJPG", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void* UnsafeEncodeNativeArrayToJPG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, int quality = 75);

		// Token: 0x06000018 RID: 24
		[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToEXR", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void* UnsafeEncodeNativeArrayToEXR(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0U, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None);
	}
}
