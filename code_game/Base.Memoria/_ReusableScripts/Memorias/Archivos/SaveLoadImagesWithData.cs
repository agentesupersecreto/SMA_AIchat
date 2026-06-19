using System;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x0200001B RID: 27
	public static class SaveLoadImagesWithData
	{
		// Token: 0x06000107 RID: 263 RVA: 0x000041F8 File Offset: 0x000023F8
		public static bool Existe(GameFolders.Tipo folder, string archivoNombre)
		{
			return ArchivosEnDisco.Existe(folder, archivoNombre, ".png");
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004208 File Offset: 0x00002408
		public static void Guardar(GameFolders.Tipo folder, string archivoNombre, Texture2D image, byte[] extradata, byte[] separador)
		{
			foreach (char c in Path.GetInvalidFileNameChars())
			{
				archivoNombre = archivoNombre.Replace(c.ToString(), "");
			}
			string text = ArchivosEnDisco.ObtenerFilePath(folder, archivoNombre, ".png");
			byte[] array = image.EncodeToPNG();
			if (extradata != null && extradata.Length != 0)
			{
				byte[] array2 = new byte[array.Length + separador.Length + extradata.Length];
				array.CopyTo(array2, 0);
				separador.CopyTo(array2, array.Length);
				extradata.CopyTo(array2, array.Length + separador.Length);
				array = array2;
			}
			ArchivosEnDisco.GuardarADisco(text, array);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000429C File Offset: 0x0000249C
		public static Texture2D Create(int width, int height, GraphicsFormat? format = null)
		{
			bool flag = false;
			if (format != null)
			{
				flag = !GraphicsFormatUtility.IsSRGBFormat(format.Value);
			}
			return new Texture2D(width, height, TextureFormat.RGB24, false, flag);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000042D0 File Offset: 0x000024D0
		public static void GetDataFromDisk(string archivoNombre, out byte[] data, out ValueTuple<int, int> size, GameFolders.Tipo folder)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(folder, archivoNombre, ".png");
			size = SaveLoadImagesWithData.GetImageSize(text);
			data = ArchivosEnDisco.LeerDesdeDisco(text);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000042FE File Offset: 0x000024FE
		public static Texture2D CreateAndLoad(byte[] data, ValueTuple<int, int> size, GraphicsFormat? format = null)
		{
			Texture2D texture2D = SaveLoadImagesWithData.Create(size.Item1, size.Item2, format);
			if (!texture2D.LoadImage(data))
			{
				throw new NotSupportedException();
			}
			return texture2D;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00004324 File Offset: 0x00002524
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata, byte[] separador, GameFolders.Tipo folder)
		{
			byte[] array;
			ValueTuple<int, int> valueTuple;
			SaveLoadImagesWithData.GetDataFromDisk(archivoNombre, out array, out valueTuple, folder);
			image = SaveLoadImagesWithData.CreateAndLoad(array, valueTuple, null);
			int num = SaveLoadImagesWithData.findSequence(array, 0, separador) + separador.Length;
			extradata = new byte[array.Length - num];
			Array.Copy(array, num, extradata, 0, extradata.Length);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004378 File Offset: 0x00002578
		public static void Cargar(string archivoNombre, out Texture2D image, GameFolders.Tipo folder)
		{
			byte[] array;
			ValueTuple<int, int> valueTuple;
			SaveLoadImagesWithData.GetDataFromDisk(archivoNombre, out array, out valueTuple, folder);
			image = SaveLoadImagesWithData.CreateAndLoad(array, valueTuple, null);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000043A2 File Offset: 0x000025A2
		public static void Cargar(byte[] data, Texture2D result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (!result.LoadImage(data))
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000043CC File Offset: 0x000025CC
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image, GameFolders.Tipo folder)
		{
			byte[] array = null;
			ValueTuple<int, int> valueTuple = new ValueTuple<int, int>(0, 0);
			SaveLoadImagesWithData.GetDataFromDisk(archivoNombre, out array, out valueTuple, folder);
			Texture2D texture2D = SaveLoadImagesWithData.CreateAndLoad(array, valueTuple, null);
			try
			{
				SaveLoadImagesWithData.Resize(texture2D, ref image, valueTuple.Item1 / 2, valueTuple.Item2 / 2);
			}
			finally
			{
				Object.Destroy(texture2D);
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004430 File Offset: 0x00002630
		public static void Resize(Texture2D sorce, ref Texture2D result, int targetX, int targetY)
		{
			RenderTexture renderTexture = new RenderTexture(targetX, targetY, 0);
			try
			{
				RenderTexture.active = renderTexture;
				Graphics.Blit(sorce, renderTexture);
				result = SaveLoadImagesWithData.Create(targetX, targetY, null);
				result.ReadPixels(new Rect(0f, 0f, (float)targetX, (float)targetY), 0, 0);
				result.Apply();
			}
			finally
			{
				RenderTexture.active = null;
				Object.Destroy(renderTexture);
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000044A8 File Offset: 0x000026A8
		private static ValueTuple<int, int> GetImageSize(string Filename)
		{
			ValueTuple<int, int> valueTuple;
			try
			{
				using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(Filename)))
				{
					binaryReader.BaseStream.Position = 16L;
					byte[] array = new byte[4];
					for (int i = 0; i < 4; i++)
					{
						array[3 - i] = binaryReader.ReadByte();
					}
					int num = BitConverter.ToInt32(array, 0);
					byte[] array2 = new byte[4];
					for (int j = 0; j < 4; j++)
					{
						array2[3 - j] = binaryReader.ReadByte();
					}
					int num2 = BitConverter.ToInt32(array2, 0);
					valueTuple = new ValueTuple<int, int>(num, num2);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return valueTuple;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00004560 File Offset: 0x00002760
		private static int findSequence(byte[] array, int start, byte[] sequence)
		{
			int num = array.Length - sequence.Length;
			byte b = sequence[0];
			while (start <= num)
			{
				if (array[start] == b)
				{
					for (int num2 = 1; num2 != sequence.Length; num2++)
					{
						if (array[start + num2] != sequence[num2])
						{
							goto IL_002E;
						}
					}
					return start;
				}
				IL_002E:
				start++;
			}
			return -1;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000045A8 File Offset: 0x000027A8
		private static bool startWith(byte[] start, byte[] sequence)
		{
			if (start.Length == 0)
			{
				return false;
			}
			if (start.Length > sequence.Length)
			{
				return false;
			}
			for (int i = 0; i < start.Length; i++)
			{
				if (start[i] != sequence[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
