using System;

namespace Assets._ReusableScripts
{
	// Token: 0x02000007 RID: 7
	[MemoriaDiccionario]
	public static class DiccionarioDeMemoria
	{
		// Token: 0x04000002 RID: 2
		public const string separador = "/";

		// Token: 0x04000003 RID: 3
		public const string separadorInData = ".";

		// Token: 0x04000004 RID: 4
		public const string root = "root";

		// Token: 0x04000005 RID: 5
		public const string personajes = "NPC";

		// Token: 0x04000006 RID: 6
		public const string aparienciaFisical = "AparienciaFisica";

		// Token: 0x04000007 RID: 7
		public const string portrait = "Portrait";

		// Token: 0x04000008 RID: 8
		public const string NPC = "NPC";

		// Token: 0x04000009 RID: 9
		public const string DATA = "DATA";

		// Token: 0x0400000A RID: 10
		public const string ID = "ID";

		// Token: 0x0400000B RID: 11
		public const string personalidad = "Personalidad";

		// Token: 0x0400000C RID: 12
		public const string conocidos = "Conocidos";

		// Token: 0x0400000D RID: 13
		public const string saludado = "Saludado";

		// Token: 0x0400000E RID: 14
		public const string favoritos = "Favoritos";

		// Token: 0x0400000F RID: 15
		public const string initialOutfitLoaded = "iniOutLoaded";

		// Token: 0x04000010 RID: 16
		public const string recuerdos = "Memorias";

		// Token: 0x04000011 RID: 17
		public const string fatiga = "Fatigue";

		// Token: 0x04000012 RID: 18
		public const string outfit = "Outfit";

		// Token: 0x04000013 RID: 19
		public const string referencias = "referencias";

		// Token: 0x04000014 RID: 20
		public const string rutaApariencia = "root/AparienciaFisica/";

		// Token: 0x04000015 RID: 21
		public const string rutaPersonalidad = "root/Personalidad/";

		// Token: 0x04000016 RID: 22
		public const string rutaNPCs = "root/NPC/";

		// Token: 0x04000017 RID: 23
		public const string rutaPersonajes = "root/NPC/";

		// Token: 0x04000018 RID: 24
		[Obsolete("", true)]
		public const string rutaPersonajesConocidos = "root/NPC/Conocidos/";

		// Token: 0x04000019 RID: 25
		public const string rutaPersonajesFavoritos = "root/NPC/Favoritos/";

		// Token: 0x0400001A RID: 26
		[Obsolete]
		public const string formatoDeRutaAparienciaFisical = "root/NPC/{0}/AparienciaFisica/";

		// Token: 0x0400001B RID: 27
		[Obsolete]
		public const string formatoDeRutaPersonalidad = "root/NPC/{0}/Personalidad/";
	}
}
