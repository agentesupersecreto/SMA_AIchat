using System;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x0200001A RID: 26
	public static class SaveLoadProfilePortraits
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00004193 File Offset: 0x00002393
		public static bool Existe(string archivoNombre)
		{
			return SaveLoadImagesWithData.Existe(GameFolders.Tipo.autoRatingPortraitsV2, archivoNombre);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000419C File Offset: 0x0000239C
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out extradata, SaveLoadProfilePortraits.separador, GameFolders.Tipo.autoRatingPortraitsV2);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000041AC File Offset: 0x000023AC
		public static void GetDataFromDisk(string archivoNombre, out byte[] data, out ValueTuple<int, int> size)
		{
			SaveLoadImagesWithData.GetDataFromDisk(archivoNombre, out data, out size, GameFolders.Tipo.autoRatingPortraitsV2);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000041B7 File Offset: 0x000023B7
		public static void Cargar(string archivoNombre, out Texture2D image)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, GameFolders.Tipo.autoRatingPortraitsV2);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000041C1 File Offset: 0x000023C1
		public static void Cargar(byte[] data, Texture2D result)
		{
			SaveLoadImagesWithData.Cargar(data, result);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000041CA File Offset: 0x000023CA
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image)
		{
			SaveLoadImagesWithData.CargarThumbnail(archivoNombre, ref image, GameFolders.Tipo.autoRatingPortraitsV2);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000041D4 File Offset: 0x000023D4
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			SaveLoadImagesWithData.Guardar(GameFolders.Tipo.autoRatingPortraitsV2, archivoNombre, image, extradata, SaveLoadProfilePortraits.separador);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000041E4 File Offset: 0x000023E4
		public static Texture2D Create(int width, int height, GraphicsFormat? format = null)
		{
			return SaveLoadImagesWithData.Create(width, height, format);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000041EE File Offset: 0x000023EE
		public static Texture2D CreateAndLoad(byte[] data, ValueTuple<int, int> size, GraphicsFormat? format = null)
		{
			return SaveLoadImagesWithData.CreateAndLoad(data, size, format);
		}

		// Token: 0x04000045 RID: 69
		public const string tvalledata = "TVallePortraitData";

		// Token: 0x04000046 RID: 70
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TVallePortraitData");
	}
}
