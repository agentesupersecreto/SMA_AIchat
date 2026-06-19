using System;
using System.Text;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000019 RID: 25
	public static class SaveLoadPoses
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x00004123 File Offset: 0x00002323
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			SaveLoadImagesWithData.Guardar(GameFolders.Tipo.poses, archivoNombre, image, extradata, SaveLoadPoses.separador);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004134 File Offset: 0x00002334
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out extradata, SaveLoadPoses.separador, GameFolders.Tipo.poses);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004148 File Offset: 0x00002348
		public static void Cargar(string archivoNombre, out Texture2D image, ref string data)
		{
			byte[] array;
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out array, SaveLoadPoses.separador, GameFolders.Tipo.poses);
			data = Encoding.UTF8.GetString(array);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004172 File Offset: 0x00002372
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image)
		{
			SaveLoadImagesWithData.CargarThumbnail(archivoNombre, ref image, GameFolders.Tipo.poses);
		}

		// Token: 0x04000043 RID: 67
		public const string tvalledata = "TVallePortraitData";

		// Token: 0x04000044 RID: 68
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TVallePortraitData");
	}
}
