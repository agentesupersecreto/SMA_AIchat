using System;
using System.Text;

namespace Assets._ReusableScripts.Memorias.Archivos
{
	// Token: 0x02000014 RID: 20
	public static class SaveLoadJson
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000398C File Offset: 0x00001B8C
		[Obsolete("no quiro guardar a una version vieja", true)]
		public static void Guardar(string archivoNombre, string data)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.save, archivoNombre, ".sav");
			ArchivosEnDisco.DoBackUp(GameFolders.Tipo.save, archivoNombre, ".sav");
			byte[] array = Zipiry.Zip(data);
			ArchivosEnDisco.GuardarADisco(text, array);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000039C0 File Offset: 0x00001BC0
		[Obsolete("no quiro guardar a una version vieja", true)]
		public static void Guardar1(string archivoNombre, string data)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.saveV1, archivoNombre, ".sav");
			ArchivosEnDisco.DoBackUp(GameFolders.Tipo.saveV1, archivoNombre, ".sav");
			byte[] array = Zipiry.Zip(data);
			ArchivosEnDisco.GuardarADisco(text, array);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000039F4 File Offset: 0x00001BF4
		public static void Guardar2(string archivoNombre, string data)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.saveV2, archivoNombre, ".sav");
			ArchivosEnDisco.DoBackUp(GameFolders.Tipo.saveV2, archivoNombre, ".sav");
			byte[] array = Zipiry.Zip(data);
			ArchivosEnDisco.GuardarADisco(text, array);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003A26 File Offset: 0x00001C26
		[Obsolete("", true)]
		public static bool ExisteVerisonZeroOUno(string archivoNombre, out int version)
		{
			if (ArchivosEnDisco.Existe(GameFolders.Tipo.saveV1, archivoNombre, ".sav"))
			{
				version = 1;
				return true;
			}
			if (ArchivosEnDisco.Existe(GameFolders.Tipo.save, archivoNombre, ".sav"))
			{
				version = 0;
				return true;
			}
			version = -1;
			return false;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003A52 File Offset: 0x00001C52
		[Obsolete("", true)]
		public static bool ExisteAnyVerisonZeroOUno(out int version)
		{
			if (ArchivosEnDisco.ExisteAny(GameFolders.Tipo.saveV1, ".sav"))
			{
				version = 1;
				return true;
			}
			if (ArchivosEnDisco.ExisteAny(GameFolders.Tipo.save, ".sav"))
			{
				version = 0;
				return true;
			}
			version = -1;
			return false;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003A7C File Offset: 0x00001C7C
		public static bool ExisteAny_VerisonDos(out int version)
		{
			version = 2;
			return ArchivosEnDisco.ExisteAny(GameFolders.Tipo.saveV2, ".sav");
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003A8C File Offset: 0x00001C8C
		public static bool Existe_VerisonDos(string archivoNombre, out int version)
		{
			version = 2;
			return ArchivosEnDisco.Existe(GameFolders.Tipo.saveV2, archivoNombre, ".sav");
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003A9D File Offset: 0x00001C9D
		public static bool ExistenCharacters()
		{
			return ArchivosEnDisco.ExisteAny(GameFolders.Tipo.charactersV2, ".png") || ArchivosEnDisco.ExisteAny(GameFolders.Tipo.characters, ".png");
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003ABC File Offset: 0x00001CBC
		public static string CargarDebugInyect(string relativePath)
		{
			byte[] array = ArchivosEnDisco.LeerDesdeDisco(ArchivosEnDisco.ObtenerFilePathDEBUG(relativePath));
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003AE0 File Offset: 0x00001CE0
		[Obsolete("", true)]
		public static string CargarV0(string archivoNombre)
		{
			return Zipiry.Unzip(ArchivosEnDisco.LeerDesdeDisco(ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.save, archivoNombre, ".sav")));
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003AF8 File Offset: 0x00001CF8
		[Obsolete("", true)]
		public static string CargarV1(string archivoNombre)
		{
			return Zipiry.Unzip(ArchivosEnDisco.LeerDesdeDisco(ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.saveV1, archivoNombre, ".sav")));
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003B10 File Offset: 0x00001D10
		public static string CargarV2(string archivoNombre)
		{
			return Zipiry.Unzip(ArchivosEnDisco.LeerDesdeDisco(ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.saveV2, archivoNombre, ".sav")));
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003B28 File Offset: 0x00001D28
		public static string CargarMasReciente()
		{
			string text = ArchivosEnDisco.MasReciente(GameFolders.latestSave, ".sav");
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			return Zipiry.Unzip(ArchivosEnDisco.LeerDesdeDisco(text));
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003B5C File Offset: 0x00001D5C
		public static string CargarMasReciente(GameFolders.Tipo tipo)
		{
			string text = ArchivosEnDisco.MasReciente(tipo, ".sav");
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			return Zipiry.Unzip(ArchivosEnDisco.LeerDesdeDisco(text));
		}
	}
}
