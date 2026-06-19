using System;
using System.Text;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000017 RID: 23
	public static class SaveLoadGestos
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00004043 File Offset: 0x00002243
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			SaveLoadImagesWithData.Guardar(GameFolders.Tipo.gestos, archivoNombre, image, extradata, SaveLoadGestos.separador);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004054 File Offset: 0x00002254
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out extradata, SaveLoadGestos.separador, GameFolders.Tipo.gestos);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004068 File Offset: 0x00002268
		public static void Cargar(string archivoNombre, out Texture2D image, ref string data)
		{
			byte[] array;
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out array, SaveLoadGestos.separador, GameFolders.Tipo.gestos);
			data = Encoding.UTF8.GetString(array);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004092 File Offset: 0x00002292
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image)
		{
			SaveLoadImagesWithData.CargarThumbnail(archivoNombre, ref image, GameFolders.Tipo.gestos);
		}

		// Token: 0x0400003F RID: 63
		public const string tvalledata = "TValleGestosData";

		// Token: 0x04000040 RID: 64
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TValleGestosData");
	}
}
