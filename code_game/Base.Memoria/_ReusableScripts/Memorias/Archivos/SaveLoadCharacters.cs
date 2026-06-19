using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000015 RID: 21
	public static class SaveLoadCharacters
	{
		// Token: 0x060000DC RID: 220 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public static bool CustomDataIsZipped(byte[] extradata)
		{
			return !SaveLoadCharacters.startWith(SaveLoadCharacters.noZippedStartBytes, extradata);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003BC4 File Offset: 0x00001DC4
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			byte[] array;
			ValueTuple<int, int> valueTuple;
			SaveLoadCharacters.GetDataFromDisk(archivoNombre, out array, out valueTuple);
			image = SaveLoadCharacters.CreateAndLoad(array, valueTuple, null);
			int num = SaveLoadCharacters.findSequence(array, 0, SaveLoadCharacters.separador) + SaveLoadCharacters.separador.Length;
			extradata = new byte[array.Length - num];
			Array.Copy(array, num, extradata, 0, extradata.Length);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003C1C File Offset: 0x00001E1C
		public static void GetDataFromDisk(string archivoNombre, out byte[] data, out ValueTuple<int, int> size)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.charactersV2, archivoNombre, ".png");
			size = SaveLoadCharacters.GetImageSize(text);
			data = ArchivosEnDisco.LeerDesdeDisco(text);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003C4C File Offset: 0x00001E4C
		public static void Cargar(string archivoNombre, out Texture2D image)
		{
			byte[] array;
			ValueTuple<int, int> valueTuple;
			SaveLoadCharacters.GetDataFromDisk(archivoNombre, out array, out valueTuple);
			image = SaveLoadCharacters.CreateAndLoad(array, valueTuple, null);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003C75 File Offset: 0x00001E75
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

		// Token: 0x060000E1 RID: 225 RVA: 0x00003CA0 File Offset: 0x00001EA0
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image, bool canBeEmpty = false)
		{
			if (canBeEmpty && string.IsNullOrWhiteSpace(archivoNombre) && SaveLoadCharacters.defaultProtraitTexture != null)
			{
				image = Object.Instantiate<Texture2D>(SaveLoadCharacters.defaultProtraitTexture);
				return;
			}
			byte[] array = null;
			ValueTuple<int, int> valueTuple = new ValueTuple<int, int>(0, 0);
			SaveLoadCharacters.GetDataFromDisk(archivoNombre, out array, out valueTuple);
			Texture2D texture2D = SaveLoadCharacters.CreateAndLoad(array, valueTuple, null);
			try
			{
				SaveLoadCharacters.Resize(texture2D, ref image, valueTuple.Item1 / 2, valueTuple.Item2 / 2);
			}
			finally
			{
				Object.Destroy(texture2D);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003D28 File Offset: 0x00001F28
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			foreach (char c in Path.GetInvalidFileNameChars())
			{
				archivoNombre = archivoNombre.Replace(c.ToString(), "");
			}
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.charactersV2, archivoNombre, ".png");
			byte[] array = image.EncodeToPNG();
			if (extradata != null && extradata.Length != 0)
			{
				byte[] array2 = new byte[array.Length + SaveLoadCharacters.separador.Length + extradata.Length];
				array.CopyTo(array2, 0);
				SaveLoadCharacters.separador.CopyTo(array2, array.Length);
				extradata.CopyTo(array2, array.Length + SaveLoadCharacters.separador.Length);
				array = array2;
			}
			ArchivosEnDisco.GuardarADisco(text, array);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003DC8 File Offset: 0x00001FC8
		public static Texture2D Create(int width, int height, GraphicsFormat? format = null)
		{
			bool flag = false;
			if (format != null)
			{
				flag = !GraphicsFormatUtility.IsSRGBFormat(format.Value);
			}
			return new Texture2D(width, height, TextureFormat.RGB24, false, flag);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003DFA File Offset: 0x00001FFA
		public static Texture2D CreateAndLoad(byte[] data, ValueTuple<int, int> size, GraphicsFormat? format = null)
		{
			Texture2D texture2D = SaveLoadCharacters.Create(size.Item1, size.Item2, format);
			if (!texture2D.LoadImage(data))
			{
				throw new NotSupportedException();
			}
			return texture2D;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003E20 File Offset: 0x00002020
		private static void Resize(Texture2D sorce, ref Texture2D result, int targetX, int targetY)
		{
			RenderTexture renderTexture = new RenderTexture(targetX, targetY, 0);
			try
			{
				RenderTexture.active = renderTexture;
				Graphics.Blit(sorce, renderTexture);
				result = SaveLoadCharacters.Create(targetX, targetY, null);
				result.ReadPixels(new Rect(0f, 0f, (float)targetX, (float)targetY), 0, 0);
				result.Apply();
			}
			finally
			{
				RenderTexture.active = null;
				Object.Destroy(renderTexture);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003E98 File Offset: 0x00002098
		private static ValueTuple<int, int> GetImageSize(string Filename)
		{
			ValueTuple<int, int> valueTuple;
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
			return valueTuple;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003F40 File Offset: 0x00002140
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

		// Token: 0x060000E8 RID: 232 RVA: 0x00003F88 File Offset: 0x00002188
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

		// Token: 0x04000038 RID: 56
		public static Texture2D defaultProtraitTexture;

		// Token: 0x04000039 RID: 57
		public const string tvalledata = "TValle.Character.Data:";

		// Token: 0x0400003A RID: 58
		public const string noZippedStart = "{\"m_id\":\"root\",";

		// Token: 0x0400003B RID: 59
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TValle.Character.Data:");

		// Token: 0x0400003C RID: 60
		private static readonly byte[] noZippedStartBytes = Encoding.UTF8.GetBytes("{\"m_id\":\"root\",");
	}
}
