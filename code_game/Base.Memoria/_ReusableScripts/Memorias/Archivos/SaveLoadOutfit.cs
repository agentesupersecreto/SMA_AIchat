using System;
using System.Text;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000018 RID: 24
	public static class SaveLoadOutfit
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x000040B3 File Offset: 0x000022B3
		public static void Guardar(string archivoNombre, Texture2D image, byte[] extradata)
		{
			SaveLoadImagesWithData.Guardar(GameFolders.Tipo.ropa, archivoNombre, image, extradata, SaveLoadOutfit.separador);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000040C4 File Offset: 0x000022C4
		public static void Cargar(string archivoNombre, out Texture2D image, out byte[] extradata)
		{
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out extradata, SaveLoadOutfit.separador, GameFolders.Tipo.ropa);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000040D8 File Offset: 0x000022D8
		public static void Cargar(string archivoNombre, out Texture2D image, ref string data)
		{
			byte[] array;
			SaveLoadImagesWithData.Cargar(archivoNombre, out image, out array, SaveLoadOutfit.separador, GameFolders.Tipo.ropa);
			data = Encoding.UTF8.GetString(array);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004102 File Offset: 0x00002302
		public static void CargarThumbnail(string archivoNombre, ref Texture2D image)
		{
			SaveLoadImagesWithData.CargarThumbnail(archivoNombre, ref image, GameFolders.Tipo.ropa);
		}

		// Token: 0x04000041 RID: 65
		public const string tvalledata = "TValleOutfitData";

		// Token: 0x04000042 RID: 66
		private static readonly byte[] separador = Encoding.UTF8.GetBytes("TValleOutfitData");
	}
}
