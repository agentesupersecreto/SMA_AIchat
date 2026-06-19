using System;
using System.Text;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000016 RID: 22
	public static class SaveLoadMakeover
	{
		// Token: 0x060000EA RID: 234 RVA: 0x00003FD4 File Offset: 0x000021D4
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			SaveLoadImagesWithData.Guardar(GameFolders.Tipo.makeover, archivoNombre, image, extradata, SaveLoadMakeover.separador);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003FE5 File Offset: 0x000021E5
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out extradata, SaveLoadMakeover.separador, GameFolders.Tipo.makeover);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003FF8 File Offset: 0x000021F8
		public static void Cargar(string archivoNombre, out Texture2D image, ref string data)
		{
			byte[] array;
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out array, SaveLoadMakeover.separador, GameFolders.Tipo.makeover);
			data = Encoding.UTF8.GetString(array);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004022 File Offset: 0x00002222
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image)
		{
			SaveLoadImagesWithData.CargarThumbnail(archivoNombre, ref image, GameFolders.Tipo.makeover);
		}

		// Token: 0x0400003D RID: 61
		public const string tvalledata = "TValleMakeoverData";

		// Token: 0x0400003E RID: 62
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TValleMakeoverData");
	}
}
